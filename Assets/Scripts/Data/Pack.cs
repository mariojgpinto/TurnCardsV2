using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackPage {
	public string title;
	public int startIdx = -1;
	public int endIdx = -1;
}
[System.Serializable]
public class TimePackRecord {
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

	public int GetRecord(int time) {
		for(int i = 0; i < records.Count; ++i) {
			if (records[i].time == time) {
				return records[i].score;
			}
		}

		return 0;
	}

	public void SetRecord(int time, int record) {
		for (int i = 0; i < records.Count; ++i) {
			if (records[i].time == time) {
				records[i].score = record;
			}
		}
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

	public Board GetNextBoard(Board previousBoard) {
		for(int i = 0 ; i < boards.Count; ++i) {
			if(boards[i].matrix == previousBoard.matrix) {
				if (i + 1 < boards.Count)
					return boards[i + 1];
				else
					return null;
			}
		}
		return null;
	}

	public Board GetPreviousBoard(Board previousBoard) {
		for (int i = 0; i < boards.Count; ++i) {
			if (boards[i].matrix == previousBoard.matrix) {
				if (i - 1 > 0)
					return boards[i + 1];
				else
					return null;
			}
		}
		return null;
	}
}
