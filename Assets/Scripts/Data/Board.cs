using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board {
	/// <summary>
	/// Current boards' matrix.
	/// - 0 -> Blank cell.
	/// - 1 -> White cell.
	/// </summary>
	public string matrix;
	/// <summary>
	/// Minimum number of plays to complete the current board.
	/// </summary>
	public int minMoves;

	/// <summary>
	/// Width of the current board.
	/// </summary>
	public int width;
	/// <summary>
	/// Height of the current board.
	/// </summary>
	public int height;
}


[System.Serializable]
public class GameBoard {
	public Board board;

	public int userMoves = 0;

	public bool played = false;
}
