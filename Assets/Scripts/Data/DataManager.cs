using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPAssets;
using System;

public class Macros {
	public enum DATA_STATE {
		NOT_LOADED,
		LOADED,
		ERROR
	}

	public const string _id = "MACRO_ID";
	public const string _n_moves = "MACRO_N_MOVES";
	public const string _time = "MACRO_TIME";
	public const string _moves = "MACRO_MOVES";

	public static string wwwGetBoardInfo = "http://www.binteractive.pt/ricardo/jogomario/getjogo.php?id=MACRO_ID";
	public static string wwwGetAllBoardsInfo = "http://www.binteractive.pt/ricardo/jogomario/getjogo.php";
	public static string wwwSendBoardInfo = "http://www.binteractive.pt/ricardo/jogomario/insert-jogada.php?jogo=MACRO_ID&movimentos=MACRO_N_MOVES&tempo=MACRO_TIME&jogadas=MACRO_MOVES";


	public const string dataFile = "data.dat";
	public const string boardsFolder = "Packs/";

	public static string msg_error_server = "Error fetching information.";

}

public class BoardArgs : EventArgs {
	public bool status;
	public string message;

	public bool hasChanged;
}

[Prefab("DataManager", true)]
public class DataManager : Singleton<DataManager> {
	#region VARIABLES
	public Data data = new Data();

	string pathToFolder;
	string pathToFile;
	string localTempFile;
	#endregion

	#region EVENTS
	public static event EventHandler<BoardArgs> event_LoadInfo;
	#endregion

	#region SETUP
	public void InitializeData() {
		pathToFolder = System.IO.Path.Combine(Application.persistentDataPath + "/", Macros.boardsFolder);
		pathToFile = System.IO.Path.Combine(pathToFolder, Macros.dataFile);
		localTempFile = Application.persistentDataPath + "/tempInfo.dat";
		StartCheck();

		//Debug.Log(Application.persistentDataPath);
		Debug.Log(pathToFolder);
		Debug.Log(pathToFile);

		if (!System.IO.Directory.Exists(pathToFolder)) {
			System.IO.Directory.CreateDirectory(pathToFolder);
		}

		if (!System.IO.File.Exists(pathToFile)) {
			InitializeStaticInfo();
		}
		else {
			LoadLocalInfo();
		}

		data.CreatePacks();
		//LoadRemoteInfo();
	}


	#endregion

	#region LOAD_INFO
	public void InitializeStaticInfo() {
		Debug.Log("InitializeStaticInfo");

		TextAsset text = Resources.Load("Boards\\MainBoards") as TextAsset;

		data = JsonUtility.FromJson<Data>(text.text);

		if (data == null) {
			Debug.Log("Error Initializing Static Info");
			data.boards_state = Macros.DATA_STATE.NOT_LOADED;
		}
		else {
			SaveLocalInfo();
			data.boards_state = Macros.DATA_STATE.LOADED;
		}
	}

	public void LoadLocalInfo() {
		Debug.Log("LoadLocalInfo");

		data = MyJSON.LoadInfo<Data>(pathToFile);

		if (data == null) {
			Debug.Log("Error Loading Local Data");
		}
		else {
			SaveLocalInfo();
		}
	}

	public void LoadRemoteInfo() {
		StartCoroutine(LoadRemoteInfo_routine());
	}

	IEnumerator LoadRemoteInfo_routine() {
		WWW www = new WWW(Macros.wwwGetAllBoardsInfo);
		yield return www;
		
		try {
			if (www.error != null && www.error != "") {
				Debug.Log("Error: " + www.error);
				Debug.Log("Text: [" + www.text + "]");
				string message = "";
				if (www.text != null && www.text != "")
					try {
						message = JSONNode.Parse(www.text)[0]["error_message"];
					}
					catch (Exception) {
						message = www.error;
					}
				else
					message = Macros.msg_error_server;

				if (event_LoadInfo != null)
					event_LoadInfo(null, new BoardArgs() { status = false, message = message });
			}
			else {
				JSONNode js = JSONNode.Parse(www.text);
				bool changes = false;
				for (int i = 0; i < js.Count; ++i) {
					string boardID = js[i]["id"].ToString().Replace("\"", "");
					string strMin = js[i]["minimo"].ToString().Replace("\"", "");

					int min = System.Convert.ToInt32(strMin);

					Board b = new Board();
					b.matrix = boardID;
					b.minMoves = min;
					b.packID = "";

					changes = changes || data.UpdateBoard(b);


					//if (min > 0) {
					//	//int tempIdx = GameData.GetBoardIndex(boardID);

					//	//if (tempIdx >= 0 && tempIdx < GameData.allBoards.Count) {
					//	//	if (min < GameData.allBoards[tempIdx].minMoves || GameData.allBoards[tempIdx].minMoves == 0) {
					//	//		GameData.allBoards[tempIdx].minMoves = min;
					//	//	}
					//	//	//                            else
					//	//	//                            if (min > GameData.allBoards[tempIdx].minMoves) {
					//	//	//                                GameDataWWW.UpdateBoardInfo(
					//	//	//                                    GameData.allBoards[tempIdx].matrix,
					//	//	//                                    GameData.allBoards[tempIdx].minMoves,
					//	//	//                                    -1);
					//	//	//                            }
					//	//}
					//}
				}

				if (event_LoadInfo != null)
					event_LoadInfo(null, new BoardArgs() { status = true, hasChanged = changes });
			}
		}
		catch (System.Exception e) {
			Debug.Log("Exception: " + e.ToString());
		}
	}
	#endregion

	#region SAVE_INFO
	public void SaveLocalInfo() {
		MyJSON.SaveInfo<Data>(this.data, pathToFile);
	}
	#endregion

	#region UPDATE_INFO
	public void UpdateBoardInfo(string matrix, int n_moves, int time, string moves = "") {
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			SaveInFile(matrix, n_moves, time, moves);
			SaveLocalInfo();
		}
		else {
			instance.StartCoroutine(UpdateBoardInfo_routine(matrix, n_moves, time, moves));
			StartCheck();
		}
	}

	IEnumerator UpdateBoardInfo_routine(string matrix, int n_moves, int time, string moves) {
		WWW www = new WWW(Macros.wwwSendBoardInfo.
			Replace(Macros._id, matrix).
			Replace(Macros._n_moves, "" + n_moves).
			Replace(Macros._time, "" + time).
			Replace(Macros._moves, moves));

		yield return www;

		int id = data.GetBoardIndex(matrix);
		if (id >= 0) {
			if (www != null) {
				if (www.error != "") {
					Debug.Log("Informations Sent: " + www.text + " - " + www.url);

					if (data.boards[id].minMoves == 0 || data.boards[id].minMoves >= n_moves)
						data.boards[id].minMoves = n_moves;
				}
				else {
					Debug.Log("UpdateBoardInfo Error: " + www.error);
					SaveInFile(matrix, n_moves, time, moves);
				}
			}
			else {
				Debug.Log("UpdateBoardInfo Error: NULL");
				SaveInFile(matrix, n_moves, time, moves);
			}
		}

		if (time != -1)
			SaveLocalInfo();
	}

	static IEnumerator SendBoardInfo_routine(string url) {
		WWW www = new WWW(url);
		yield return www;

		if (www == null || www.error != null) {
			System.IO.File.AppendAllText(
				instance.localTempFile,
				url
			);
		}
	}

	public static void StartCheck() {
		if (System.IO.File.Exists(instance.localTempFile)) {
			if (Application.internetReachability != NetworkReachability.NotReachable) {
				string[] allText = System.IO.File.ReadAllLines(instance.localTempFile);
				System.IO.File.Delete(instance.localTempFile);
				if (allText != null && allText.Length > 0) {
					foreach (string url in allText) {
						instance.StartCoroutine(SendBoardInfo_routine(url));
					}
				}
			}
		}
	}

	void SaveInFile(string matrix, int n_moves, int time, string moves) {
		int id = data.GetBoardIndex(matrix);
		if (data.boards[id].minMoves == 0 || data.boards[id].minMoves >= n_moves)
			data.boards[id].minMoves = n_moves;

		System.IO.File.AppendAllText(
			localTempFile,
			Macros.wwwSendBoardInfo.
			Replace(Macros._id, matrix).
			Replace(Macros._n_moves, "" + n_moves).
			Replace(Macros._time, "" + time).
			Replace(Macros._moves, moves) + "\n"
		);
	}

	public void GetBoardInfo(string matrix, bool updateScreen = false) {
		if (Application.internetReachability != NetworkReachability.NotReachable) {
			instance.StartCoroutine(GetBoardInfo_routine(matrix, updateScreen));
		}
	}

	IEnumerator GetBoardInfo_routine(string matrix, bool updateScreen = false) {
		WWW www = new WWW(Macros.wwwGetBoardInfo.Replace(Macros._id, matrix));
		yield return www;

		if (www.text != "") {
			try {
				JSONNode js = JSONNode.Parse(www.text);

				for (int i = 0; i < js.Count; ++i) {
					string boardID = js[i]["id"].ToString().Replace("\"", "");
					string strMin = js[i]["minimo"].ToString().Replace("\"", "");

					int min = System.Convert.ToInt32(strMin);

					if (min > 0) {
						int tempIdx = data.GetBoardIndex(boardID);

						if (tempIdx >= 0 && tempIdx < data.boards.Count) {
							if (data.boards[tempIdx].minMoves == 0 || min < data.boards[tempIdx].minMoves) {
								data.boards[tempIdx].minMoves = min;

								if (updateScreen) {
									Controller.instance.gameRegular.UIUpdateMinimum(min);
								}
							}
						}
					}
				}

				Debug.Log(www.text);
			}
			catch (System.Exception e) {
				Debug.Log("Exception: " + e.ToString());
			}
		}
	}
	#endregion

	#region	UNITY_CALLBACKS
	void Start() {
		//InitializeData();

		//Invoke("SaveData", 2);
	}
	#endregion
}
