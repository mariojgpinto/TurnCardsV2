using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Script : MonoBehaviour {
	#region VARIABLES
	public GameObject cardPrefab;

	public GameObject panelBoard;

	Board board;

	DynamicGrid grid;
	#endregion

	#region SETUP
	public void Initialize() {
		grid = this.GetComponent<DynamicGrid>();

		int size = GameManager.maxSize;

		GameManager.instance.cards = new TurnCardUI[size, size];

		for (int i = 0; i < size; ++i) {
			for (int j = 0; j < size; ++j) {
				GameObject go = Instantiate(cardPrefab, panelBoard.transform, false);
				GameManager.instance.cards[i, j] = go.GetComponent<TurnCardUI>();
				GameManager.instance.cards[i, j].Init(i, j);
			}
		}

	}

	public void InitializeBoard(Board _board) {

	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		Initialize();
	}
	#endregion
}
