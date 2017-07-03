using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boards_Script : MonoBehaviour {
	#region VARIABLES
	public Text title;
	public GameObject prefabBoardSet;
	public GameObject prefabBoardElem;

	const int maxPerBoard = 30;

	public GameObject panelScroll;
	#endregion

	#region SETUP
	public void Initialize(Pack pack) {
		foreach (Transform t in panelScroll.transform)
			Destroy(t.gameObject);

		int ac = 0;

		title.text = pack.title;

		for (int i = 0; i < pack.boards.Count; ) {
			GameObject board = Instantiate(prefabBoardSet, panelScroll.transform);

			//List<GameObject> elements = new List<GameObject>();
			for (int j = 0; j < maxPerBoard && i < pack.boards.Count; ++j, ++i) {
				GameObject boardElem = Instantiate(prefabBoardElem, board.transform.GetChild(1));

				boardElem.GetComponent<BoardListElem_Script>().Initialize(pack.boards[ac], ac);

				ac++;
			}

			board.transform.localScale = Vector3.one;
		}

		//for(int i = 0; i < 100; ++i) {
		//	GameObject board = Instantiate(prefabBoardSet, panelScroll.transform);

		//	List<GameObject> elements = new List<GameObject>();
		//	for (int j = 0; j < maxPerBoard && i < 100; ++j, ++i) {
		//		GameObject boardElem = Instantiate(prefabBoardElem, board.transform.GetChild(1));
		//	}

		//	board.transform.localScale = Vector3.one;
		//}
	}
	#endregion

	#region UNITY_CALLBACKS
	//// Use this for initialization
	//void Start () {
	//	//Initialize();
	//}
	
	////// Update is called once per frame
	////void Update () {

	////}
	#endregion
}
