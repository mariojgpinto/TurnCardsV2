using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SizeBoardList {
	public int size;
	public List<Board> boards;
}

[System.Serializable]
public class Data {
	#region VARIABLES
	[System.NonSerialized]
	public Macros.DATA_STATE boards_state = Macros.DATA_STATE.NOT_LOADED;
	public List<Board> boards = new List<Board>();
	List<SizeBoardList> boardsPerSize = new List<SizeBoardList>();

	[System.NonSerialized]
	public Macros.DATA_STATE packs_state = Macros.DATA_STATE.NOT_LOADED;
	public List<Pack> packs = new List<Pack>();

	public List<TimePack> timePacks = new List<TimePack>();
	#endregion

	#region SETUP
	void InitializePerBoardLists() {
		for (int i = 0; i < boards.Count; ++i) {
			int boardSize = boards[i].GetBoardSize();
			int idx = GetBoardSizeListIdx(boardSize);

			if(idx >= 0) {
				boardsPerSize[idx].boards.Add(boards[i]);
			}
			else {
				SizeBoardList newList = new SizeBoardList();
				newList.size = boardSize;
				newList.boards = new List<Board>();
				newList.boards.Add(boards[i]);

				boardsPerSize.Add(newList);
			}
		}
	}

	public bool UpdateBoard(Board board) {
		bool hasChanged = false;
		int index = GetBoardIndex(board);

		if(board.packID == "") {
			if (board.matrix.Length == 16) {
				board.packID = "4x4";
			}
			else
			if (board.matrix.Length == 36) {
				board.packID = "6x6";
			}
			else
			if (board.matrix.Length == 64) {
				board.packID = "8x8";
			}
			else {
				return false;
			}
			
			hasChanged = true;
		}

		if(index > 0) {
			if(boards[index].minMoves <= 0 || boards[index].minMoves >= board.minMoves) {
				boards[index].minMoves = board.minMoves;
				hasChanged = true;
			}
			else {
				//TODO[DataManager] Update Score on server;
				Debug.Log("Local Score is Better than server.");
			}

			boards[index].userMoves = board.userMoves;
		}
		else {
			boards.Add(board);
			hasChanged = true;
		}

		return hasChanged;
	}

	public int GetBoardIndex(Board board) {
		for(int i = 0; i < boards.Count; ++i) {
			if(boards[i].matrix == board.matrix) {
				return i;
			}
		}

		return -1;
	}

	public int GetBoardIndex(string matrix) {
		for (int i = 0; i < boards.Count; ++i) {
			if (boards[i].matrix == matrix) {
				return i;
			}
		}

		return -1;
	}

	public int GetPackIndex(string title) {
		for (int i = 0; i < packs.Count; ++i) {
			if (packs[i].title == title) {
				return i;
			}
		}

		return -1;
	}

	public void CreatePacks() {
		List<string> packs_names = new List<string>();

		foreach(Pack p in packs) {
			packs_names.Add(p.title);
		}

		foreach (Board b in boards) {
			if (!MPAssets.Utils.ExistsInList<string>(packs_names, b.packID)) {
				packs_names.Add(b.packID);
				Pack pack = new Pack();
				pack.title = b.packID;
				packs.Add(pack);
			}
			else {
				packs[GetPackIndex(b.packID)].boards.Add(b);
				//pack.boards.Add(b);
			}
		}

		//packs.Sort((a,b) => return (a.title < b.title) ? 1 : 2);)

		//for(int i = 0; i < packs_names.Count; ++i) {
		//	Pack pack = new Pack();

		//	pack.title = packs_names[i];
		//	pack.
		//}

		packs_state = Macros.DATA_STATE.LOADED;

		DataManager.instance.SaveLocalInfo();
	}
	#endregion

	#region ACCESS
	public Board GetNextBoard(Board currentBoard) {
		int packIdx = GetPackIndex(currentBoard.packID);

		if(packIdx >= 0) {
			Pack pack = packs[packIdx];

			return pack.GetNextBoard(currentBoard);
		}

		return null;
	}

	public Board GetPreviousBoard(Board currentBoard) {
		int packIdx = GetPackIndex(currentBoard.packID);

		if (packIdx >= 0) {
			Pack pack = packs[packIdx];

			return pack.GetPreviousBoard(currentBoard);
		}

		return null;
	}

	public Board GetRandomBoard(int size) {
		if(boardsPerSize.Count == 0) {
			InitializePerBoardLists();
		}
		int idx = GetBoardSizeListIdx(size);

		if(idx >= 0) {
			int boardIdx = Random.Range(0, boardsPerSize[idx].boards.Count);
			return boardsPerSize[idx].boards[boardIdx];
		}
		else {
			return null;
		}
	}

	int GetBoardSizeListIdx(int size) {
		for(int i = 0; i < boardsPerSize.Count; ++i) {
			if (boardsPerSize[i].size == size)
				return i;
		}
		return -1;
	}
	#endregion
}
