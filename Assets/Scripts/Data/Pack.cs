using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackPage {
	public string title;
	public int startIdx = -1;
	public int endIdx = -1;
}
[System.Serializable]
public struct TimePackRecord {
	public int time;
	public int score;
}

[System.Serializable]
public class TimePack {
	public string title;
	public int boardSize;
	public List<TimePackRecord> records = new List<TimePackRecord>();

	public TimePack(int _size) {
		boardSize = _size;
		title = "board (" + boardSize + "x" + boardSize + ")";
	}
}


[System.Serializable]
public class Pack {
	public string title;

	[System.NonSerialized]
	public List<Board> boards = new List<Board>();

	public List<PackPage> subTitles = new List<PackPage>();

	public int GetCompleted() {
		int ac = 0;

		foreach(Board b in boards) {
			if(b.userMoves > 0 && b.userMoves < 999) {
				ac++;
			}
		}

		return ac;
	}

	public int GetCompletedPerfect() {
		int ac = 0;

		foreach (Board b in boards) {
			if (b.userMoves == b.minMoves) {
				ac++;
			}
		}

		return ac;
	}
}
