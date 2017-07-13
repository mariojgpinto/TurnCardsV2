using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRegular_Script : MonoBehaviour {
	#region VARIABLES
	public const int maxSize = 8;

	public GameObject cardPrefab;

	public GameObject panelBoard;

	Board currentBoard;
	int currentLevel;

	GridLayoutGroup gridLayout;
	DynamicGrid gridController;

	float waitTimeStep = .1f;

	int currentBoardMinWidth;
	int currentBoardMaxWidth;
	int currentBoardMinHeight;
	int currentBoardMaxHeight;
	public TurnCardUI[,] cards;

	int scoreCount = 0;

	bool isBusy = false;

	Coroutine routine_waitNext;
	#endregion

	#region SETUP
	public void Initialize() {
		gridController = panelBoard.GetComponent<DynamicGrid>();
		gridLayout = panelBoard.GetComponent<GridLayoutGroup>();

		int size = maxSize;

		cards = new TurnCardUI[size, size];

		for (int i = 0; i < size; ++i) {
			for (int j = 0; j < size; ++j) {
				GameObject go = Instantiate(cardPrefab, panelBoard.transform, false);
				cards[i, j] = go.GetComponent<TurnCardUI>();
				cards[i, j].Init(i, j);
			}
		}
	}

	public void InitializeNewBoard(int _level, Board _board) {
		currentBoard = _board;
		currentLevel = _level;

		InitializeBoard(currentBoard);

		UIStartGame();

		UISetLevel(currentLevel, currentBoard.minMoves);

		UIUpdateCurrentResult();
	}

	void InitializeBoard(Board _board) {
		currentBoard = _board;

		int boardSize = currentBoard.GetBoardSize();

		for (int i = 0; i < maxSize; ++i) {
			for (int j = 0; j < maxSize; ++j) {
				if (i < boardSize && j < boardSize)
					cards[i, j].gameObject.SetActive(true);
				else
					cards[i, j].gameObject.SetActive(false);
			}
		}

		gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
		gridLayout.constraintCount = boardSize;
		float spaceSize = (panelBoard.GetComponent<RectTransform>().rect.size.x / (float)boardSize) * .125f;
		gridLayout.spacing = Vector2.one * spaceSize;

		//Debug.Log();
		gridController.AdjustCellSize(boardSize, boardSize);

		LoadBoardFromID(currentBoard.matrix);
	}

	void GenerateRandomMatrix(int size) {
		currentBoardMaxWidth = size;
		currentBoardMaxHeight = size;
		currentBoardMinWidth = 0;
		currentBoardMinHeight = 0;

		scoreCount = 0;

		string str = "";

		for (int j = 0; j < size; ++j) {
			for (int i = 0; i < size; ++i) {
				cards[i, j].ResetCard();
				if (Random.Range(0, 100) > 70) {
					cards[i, j].SetFront();
					str += "1";
				}
				else {
					cards[i, j].SetBack();
					str += "0";
				}
			}
		}

		if (!CheckIfIsValid()) {
			GenerateRandomMatrix(size);
		}
		else {
			StartCoroutine(ResizeBorders(.5f));
		}

		GameLog.StartGame(str, size, size);
		
		isBusy = false;
	}

	bool CheckIfIsValid() {
		int ac = 0;
		int size = currentBoard.GetBoardSize();

		for (int j = 0; j < size; ++j) {
			if (cards[0, j].isBack)
				ac++;
			else
				break;
		}
		if (ac == size)
			return false;

		ac = 0;
		for (int j = 0; j < size; ++j) {
			if (cards[size - 1, j].isBack)
				ac++;
			else
				break;
		}
		if (ac == size)
			return false;

		ac = 0;
		for (int i = 0; i < size; ++i) {
			if (cards[i, 0].isBack)
				ac++;
			else
				break;
		}
		if (ac == size)
			return false;

		ac = 0;
		for (int i = 0; i < size; ++i) {
			if (cards[i, size - 1].isBack)
				ac++;
			else
				break;
		}
		if (ac == size)
			return false;

		return true;
	}

	void LoadBoardFromID(string id) {
		int size = currentBoard.GetBoardSize();

		currentBoardMaxWidth = size;
		currentBoardMaxHeight = size;
		currentBoardMinWidth = 0;
		currentBoardMinHeight = 0;

		scoreCount = 0;

		int x = 0;
		int y = 0;
		for (int i = 0; i < id.Length; ++i) {
			cards[x, y].ResetCard(true);
			if (id[i] == '0') {
				cards[x, y].SetBack();
			}
			else {
				cards[x, y].SetFront();
			}

			x++;

			if (x >= size) {
				x = 0;
				y++;
			}
		}

		//TODO: Update Board Info
		//GameDataWWW.GetBoardInfo(id, true);

		GameLog.StartGame(id, size, size);
		
		isBusy = false;

		StartCoroutine(ResizeBorders(.5f));
	}
	#endregion

	#region UI
	void UIStartGame() {
		if(routine_waitNext != null) {
			StopCoroutine(routine_waitNext);
			routine_waitNext = null;
		}
		GUI_GameRegular.running_Panel_gameObject.SetActive(true);
		GUI_GameRegular.running_info_Panel_gameObject.SetActive(true);

		GUI_GameRegular.finish_Panel_gameObject.SetActive(false);

		UIEnableBoard(true);
	}

	void UIEnableBoard(bool enable) {
		GUI_GameRegular.board_Panel_gameObject.SetActive(enable);
	}

	void UISetLevel(int level, int min) {
		GUI_GameRegular.running_info_currentScore_Text.text = "0";
		GUI_GameRegular.running_info_minimum_label_Text.text = "" + min;
		GUI_GameRegular.running_info_level_Text.text = "LEVEL " + level;
	}

	public void UIUpdateMinimum(int min) {
		GUI_GameRegular.running_info_minimum_label_Text.text = "" + min;
	}

	void UIUpdateCurrentResult() {
		GUI_GameRegular.running_info_currentScore_Text.text = "" + scoreCount;
	}

	void UIFinishGame() {
		GUI_GameRegular.finish_Panel_gameObject.SetActive(true);
		GUI_GameRegular.running_Panel_gameObject.SetActive(false);

		GUI_GameRegular.finish_score_currentScore_Text.text = "" + scoreCount;

		if (scoreCount > currentBoard.minMoves) {
			GUI_GameRegular.finish_message_Text.text = "level completed";
			GUI_GameRegular.finish_score_diamond_Image_gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
		}
		else {
			GUI_GameRegular.finish_message_Text.text = "perfect";
			GUI_GameRegular.finish_score_diamond_Image_gameObject.transform.eulerAngles = new Vector3(0, 0, 45);
		}

		routine_waitNext = StartCoroutine(UIFinishCounter());
	}

	IEnumerator UIFinishCounter() {
		int secondsLeft = 5;
		string text = "Next in\n";
		GUI_GameRegular.finish_next_label_Text.text = text + secondsLeft;

		do {			
			yield return new WaitForSeconds(1);
			secondsLeft--;
			GUI_GameRegular.finish_next_label_Text.text = text + secondsLeft;
		}
		while (secondsLeft != 0);

		yield return new WaitForSeconds(.2f);

		Debug.Log("Wait Ended");
		InitializeNextBoard();

		routine_waitNext = null;
	}
	#endregion

	#region GAME_ACTIONS
	public void InitializeSameBoard() {
		InitializeNewBoard(currentLevel, currentBoard);
	}

	public void InitializeNextBoard() {
		Board newBoard = Controller.instance.dataManager.data.GetNextBoard(currentBoard);

		if (newBoard == null) {
			GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_GameRegular, GUI_Controller.instance.gui_Boards);
			GUI_Controller.instance.gui_Boards.GetComponent<Boards_Script>().Initialize();
		}
		else {
			InitializeNewBoard(currentLevel + 1, newBoard);
		}
	}


	public void InitializePreviousBoard() {
		Board newBoard = Controller.instance.dataManager.data.GetPreviousBoard(currentBoard);

		if (newBoard == null) {
			GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_GameRegular, GUI_Controller.instance.gui_Boards);
			GUI_Controller.instance.gui_Boards.GetComponent<Boards_Script>().Initialize();
		}
		else {
			InitializeNewBoard(currentLevel - 1, newBoard);
		}
	}
	#endregion

	#region GAME_LOGIC
	public void ProcessTouch(TurnCardUI card) {
		if (!isBusy) {
			int x = card.posX;
			int y = card.posY;

			if (x < currentBoardMaxWidth && x >= currentBoardMinWidth &&
				y < currentBoardMaxHeight && y >= currentBoardMinHeight) {
				Debug.Log("Flip(" + x + "," + y + ")");
				isBusy = true;

				card.FlipCard();

				PropagateTouch(x + 1, y, 1, waitTimeStep);
				PropagateTouch(x, y + 1, 3, waitTimeStep);
				PropagateTouch(x - 1, y, 5, waitTimeStep);
				PropagateTouch(x, y - 1, 7, waitTimeStep);

				StartCoroutine(ResizeBorders());

				StartCoroutine(WaitNext());

				++scoreCount;

				UIUpdateCurrentResult();
				GameLog.AddMove(x, y);
			}
		}
	}

	void PropagateTouch(int x, int y, int direction, float waitTime) {
		if (x < currentBoardMaxWidth &&
		   x >= currentBoardMinWidth &&
		   y < currentBoardMaxHeight &&
		   y >= currentBoardMinHeight &&
		   cards[x, y].isActive) {
			cards[x, y].FlipCard(waitTime);

			switch (direction) {
				case 1: //UP
					PropagateTouch(x + 1, y, 1, waitTime + waitTimeStep);
					break;
				case 3: //RIGHT
					PropagateTouch(x, y + 1, 3, waitTime + waitTimeStep);
					break;
				case 5: //DOWN
					PropagateTouch(x - 1, y, 5, waitTime + waitTimeStep);
					break;
				case 7: //LEFT
					PropagateTouch(x, y - 1, 7, waitTime + waitTimeStep);
					break;
				default:
					break;
			}
		}
	}

	IEnumerator ResizeBorders(float waitTime = 0) {
		yield return new WaitForSeconds(waitTime);

		int size = currentBoard.GetBoardSize();

		Init:
		for (int i = currentBoardMinWidth; i < currentBoardMaxWidth; ++i) {
			for (int j = currentBoardMinHeight; j < currentBoardMaxHeight; ++j) {
				if (cards[i, j].isBusy) {
					yield return new WaitForSeconds(waitTimeStep);
					goto Init;
				}
			}
		}

		int ac;

		if (currentBoardMinHeight >= currentBoardMaxHeight || currentBoardMinWidth >= currentBoardMaxWidth) {
			goto EndGame;
		}

		InitBottom:
		ac = 0;
		//BOTTOM LINE
		for (int i = currentBoardMinWidth; i < currentBoardMaxWidth; ++i) {
			if (!cards[i, currentBoardMinHeight].isBack)
				break;
			else
				ac++;
		}
		if (ac == (currentBoardMaxWidth - currentBoardMinWidth)) {
			for (int i = currentBoardMinWidth; i < currentBoardMaxWidth; ++i) {
				cards[i, currentBoardMinHeight].HideCard();
			}
			currentBoardMinHeight++;
			if (currentBoardMinHeight >= currentBoardMaxHeight) {
				goto EndGame;
			}
			else {
				goto InitBottom;
			}
		}

		InitTop:
		ac = 0;
		//TOP LINE
		for (int i = currentBoardMinWidth; i < currentBoardMaxWidth; ++i) {
			if (!cards[i, currentBoardMaxHeight - 1].isBack)
				break;
			else
				ac++;
		}
		if (ac == (currentBoardMaxWidth - currentBoardMinWidth)) {
			for (int i = currentBoardMinWidth; i < currentBoardMaxWidth; ++i) {
				cards[i, currentBoardMaxHeight - 1].HideCard();
			}
			currentBoardMaxHeight--;
			if (currentBoardMaxHeight <= currentBoardMinHeight) {
				goto EndGame;
			}
			else {
				goto InitTop;
			}
		}

		InitLeft:
		ac = 0;
		//LEFT COLUMN
		for (int i = currentBoardMinHeight; i < currentBoardMaxHeight; ++i) {
			if (!cards[currentBoardMinWidth, i].isBack)
				break;
			else
				ac++;
		}
		if (ac == (currentBoardMaxHeight - currentBoardMinHeight)) {
			for (int i = currentBoardMinHeight; i < currentBoardMaxHeight; ++i) {
				cards[currentBoardMinWidth, i].HideCard();
			}
			currentBoardMinWidth++;
			if (currentBoardMinWidth >= currentBoardMaxWidth) {
				goto EndGame;
			}
			else {
				goto InitLeft;
			}
		}

		InitRight:
		//RIGHT COLUMN
		ac = 0;
		for (int i = currentBoardMinHeight; i < currentBoardMaxHeight; ++i) {
			if (!cards[currentBoardMaxWidth - 1, i].isBack)
				break;
			else
				ac++;
		}
		if (ac == (currentBoardMaxHeight - currentBoardMinHeight)) {
			for (int i = currentBoardMinHeight; i < currentBoardMaxHeight; ++i) {
				cards[currentBoardMaxWidth - 1, i].HideCard();
			}
			currentBoardMaxWidth--;
			if (currentBoardMaxWidth <= currentBoardMinWidth) {
				goto EndGame;
			}
			else {
				goto InitRight;
			}
		}
		yield break;

		EndGame:

		FinishGame();
	}

	IEnumerator WaitNext() {
		//yield return new WaitForSeconds(1);

		Init:
		for (int i = currentBoardMinWidth; i < currentBoardMaxWidth; ++i) {
			for (int j = currentBoardMinHeight; j < currentBoardMaxHeight; ++j) {
				if (cards[i, j].isBusy) {
					yield return new WaitForSeconds(waitTimeStep);
					goto Init;
				}
			}
		}

		isBusy = false;
	}

	void FinishGame() {
		Invoke("UIFinishGame", TurnCardUI.animationTime);

		if (currentBoard.userMoves <= 0 || currentBoard.userMoves > scoreCount) {
			currentBoard.userMoves = scoreCount;
		}

		GameLog.EndGame();
		Controller.instance.dataManager.UpdateBoardInfo(
			currentBoard.matrix,
			scoreCount,
			GameLog.GetTime(),
			GameLog.GetMoves()
		);

		//TODO: Save current board ONLY
		//Controller.instance.dataManager.SaveLocalInfo(boardLevel, boardID);
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	//void Start () {
	//	//Initialize();
	//}
	#endregion
}
