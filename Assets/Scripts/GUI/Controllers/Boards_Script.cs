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

	List<BoardListElem_Script> elements = new List<BoardListElem_Script>();

	Pack currentPack;
	#endregion

	#region SETUP
	public void Initialize(Pack pack = null) {
		if(pack != null)
			currentPack = pack;
		title.text = currentPack.title;

		Debug.Log("Pack(" + currentPack.title + ") - " + currentPack.boards.Count);

		if (elements.Count == 0) {
			int ac = 0;

			for (int i = 0; i < currentPack.boards.Count;) {
				GameObject board = Instantiate(prefabBoardSet, panelScroll.transform);

				//List<GameObject> elements = new List<GameObject>();
				for (int j = 0; j < maxPerBoard && i < currentPack.boards.Count; ++j, ++i) {
					GameObject boardElem = Instantiate(prefabBoardElem, board.transform.GetChild(1));

					boardElem.GetComponent<BoardListElem_Script>().Initialize(currentPack.boards[ac], ac);
					elements.Add(boardElem.GetComponent<BoardListElem_Script>());

					ac++;
				}

				board.transform.localScale = Vector3.one;
			}
		}
		else {
			for (int i = 0; i < currentPack.boards.Count && i < elements.Count; ++i) {
				elements[i].Initialize(currentPack.boards[i], i);
			}
		}

		panelScroll.transform.parent.gameObject.GetComponent<UnityEngine.UI.Extensions.ScrollSnap>().ChangePage(0);


		int completed = currentPack.GetCompleted();
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
