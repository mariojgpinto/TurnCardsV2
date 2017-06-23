using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PackRequest {
	public string title = "New Pack";
	public int width = 4;
	public int height = 4;
	public int nBoards = 10;

	public string file = "boards.txt";
	public string folder = "C:/Dev/Data/";

	public PackRequest() {
		title = "New Pack";
		width = 4;
		height = 4;
		nBoards = 10;

		file = "boards.txt";
		folder = "C:/Dev/Data/";

	}
}
public class DataCreation : MonoBehaviour {
	#region VARIABLES	
	public List<PackRequest> requests = new List<PackRequest>();

	bool[,] cards;// = new bool[boardWidth, boardHeight];

	//public Text text_board;
	//public Text text_counter;

	#endregion

	#region SETUP	


	string fullStr = "";
	string path = "C:/Dev/Data/boards.txt";

	string GenerateRandomMatrix(int width, int height, ref Dictionary<string, int> dict) {
		string str = "";

		for (int j = 0; j < height; ++j) {
			for (int i = 0; i < width; ++i) {
				if (Random.Range(0, 100) > 70) {
					cards[i, j] = true;
					str += "1";
				}
				else {
					cards[i, j] = false;
					str += "0";
				}
			}
		}

		if (CheckIfIsValid(width, height)) {
			if (dict.ContainsKey(str)) {
				int temp = 0;
				dict.TryGetValue(str, out temp);

				dict.Remove(str);

				dict.Add(str, temp + 1);
				Debug.Log("Repeated");
			}
			else {
				//Board b = new Board();
				//b.matrix = str;
				dict.Add(str, 1);

				//fullStr += str + "\n";

				return str;
			}
		}

		return "";
	}

	bool CheckIfIsValid(int boardWidth, int boardHeight) {
		int ac = 0;

		ac = 0;
		for (int j = 0; j < boardHeight; ++j) {
			if (!cards[0, j])
				ac++;
			else
				break;
		}
		if (ac == boardHeight)
			return false;

		ac = 0;
		for (int j = 0; j < boardHeight; ++j) {
			if (!cards[boardWidth - 1, j])
				ac++;
			else
				break;
		}
		if (ac == boardHeight)
			return false;

		ac = 0;
		for (int i = 0; i < boardWidth; ++i) {
			if (!cards[i, 0])
				ac++;
			else
				break;
		}
		if (ac == boardWidth)
			return false;

		ac = 0;
		for (int i = 0; i < boardWidth; ++i) {
			if (!cards[i, boardHeight - 1])
				ac++;
			else
				break;
		}
		if (ac == boardWidth)
			return false;

		return true;
	}
	#endregion

	void CreateBoards() {
		for (int i = 0; i < requests.Count; ++i) {
			Dictionary<string, int> dict = new Dictionary<string, int>();
			Pack pack = new Pack();
			pack.title = requests[i].title;

			cards = new bool[requests[i].width, requests[i].height];

			while (dict.Count < requests[i].nBoards) {
				string matrix = GenerateRandomMatrix(requests[i].width, requests[i].height, ref dict);

				Board b = new Board();
				b.matrix = matrix;
				b.width = requests[i].width;
				b.height = requests[i].height;
				b.minMoves = 999;

				pack.boards.Add(b);
			}

			MPAssets.MyJSON.SaveInfo<Pack>(pack, requests[i].folder + requests[i].file);
		}
	}

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start() {
		CreateBoards();
	}

	// Update is called once per frame	
	//void OnGUI() {
	//	if (Input.GetKeyDown(KeyCode.Escape)) {
	//		Application.LoadLevel("00-Menu");
	//	}
	//}
	#endregion
}
