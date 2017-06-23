using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boards_Script : MonoBehaviour {
	#region VARIABLES
	public GameObject prefabBoardSet;
	public GameObject prefabBoardElem;

	const int maxPerBoard = 30;

	public GameObject panelScroll;
	#endregion

	#region SETUP
	public void CreateBoards() {
		for(int i = 0; i < 100; ++i) {
			GameObject board = Instantiate(prefabBoardSet, panelScroll.transform);

			List<GameObject> elements = new List<GameObject>();
			for (int j = 0; j < maxPerBoard && i < 100; ++j, ++i) {
				GameObject boardElem = Instantiate(prefabBoardElem, board.transform.GetChild(1));
			}

			board.transform.localScale = Vector3.one;
		}
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		CreateBoards();
	}
	
	//// Update is called once per frame
	//void Update () {

	//}
	#endregion
}
