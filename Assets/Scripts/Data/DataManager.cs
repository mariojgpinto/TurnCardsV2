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
	#endregion

	#region EVENTS
	public static event EventHandler<BoardArgs> event_LoadInfo;
	#endregion

	#region SETUP
	public void InitializeData() {
		pathToFolder = System.IO.Path.Combine(Application.persistentDataPath + "/", Macros.boardsFolder);
		pathToFile = System.IO.Path.Combine(pathToFolder, Macros.dataFile);

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

	#region	UNITY_CALLBACKS
	//void Start() {
	//	//InitializeData();

	//	//Invoke("SaveData", 2);
	//}
	#endregion
}
