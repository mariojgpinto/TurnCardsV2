using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardListElem_Script : MonoBehaviour {
	#region VARIABLES
	public Text elemNumber;
	public Text goal;
	public Image goalBG;
	
	Board board;
	#endregion

	#region SETUP
	public void Initialize(Board _board, int id) {
		board = _board;

		elemNumber.text = "" + id;
		goal.text = "" + board.minMoves;

		if(board.userMoves > 0) {
			if (board.userMoves == board.minMoves) {
				goalBG.color = Color.green;
			}
			else {
				goalBG.color = Color.yellow;
			}
		}
		else {
			goalBG.color = Color.white;
		}
		

		this.GetComponent<Button>().onClick.AddListener(() => OnButtonPressed());
	}
	#endregion

	#region CALLBACKS
	public void OnButtonPressed() {
		Controller.instance.StartGame(board);
	}
	#endregion
}
