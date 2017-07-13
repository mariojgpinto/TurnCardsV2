using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPAssets;

[Prefab("GameManager", true)]
public class GameManager : Singleton<GameManager> {
	#region VARIABLES
	public const int maxSize = 8;
	public GameObject cardPrefab;
	public GameObject cardParent;
	public GameObject gameCamera;

	Board currentBoard;

	float step = 2.5f;

	float waitTimeStep = .1f;

	int currentBoardMinWidth;
	int currentBoardMaxWidth;
	int currentBoardMinHeight;
	int currentBoardMaxHeight;
	public TurnCardUI[,] cards;

	int scoreCount = 0;

	bool isBusy = false;
	bool retry = false;
	bool gameEnded = false;
	#endregion
	
	#region SETUP
	public void Initialize() {
		InitializeCards();
	}

	void InitializeCards() {
		int size = maxSize;

		//cards = new TurnCard[size, size];

		for (int i = 0; i < size; ++i) {
			for (int j = 0; j < size; ++j) {
				GameObject go = Instantiate(cardPrefab, cardParent.transform, false);
				go.transform.position = new Vector3(i * step, j * step, 0);
				//cards[i, j] = go.GetComponent<TurnCard>();
				//cards[i, j].Init(i, j);
			}
		}
	}

	public void InitializeGame(Board _board) {
		currentBoard = _board;
		
		LoadBoardFromID(currentBoard.matrix);

		int size = currentBoard.GetBoardSize();
		for (int i = 0; i < maxSize; ++i) {
			for (int j = 0; j < maxSize; ++j) {
				if(i < size && j < size)
					cards[i, j].gameObject.SetActive(true);
				else
					cards[i, j].gameObject.SetActive(false);
			}
		}

		AdjustCamera();
	}

	void AdjustCamera() {
		Camera cam = gameCamera.GetComponent<Camera>();

		int size = currentBoard.GetBoardSize();

		cam.transform.position = new Vector3(((size - 1) * step) / 2,
											 size == 4 ? 4.5f : size == 6 ? 7.25f : 10f,
											 - 10);

		float orthograficStep = size == 4 ? 9.75f : size == 6 ? 14.925f : 20.03125f;
		cam.orthographicSize = orthograficStep;
	}

	void GenerateRandomMatrix(int size) {
		//int size = currentBoard.GetBoardSize();

		currentBoardMaxWidth = size;
		currentBoardMaxHeight = size;
		currentBoardMinWidth = 0;
		currentBoardMinHeight = 0;

		scoreCount = 0;
		//panelCurrentScore.SetActive(true);
		//UpdateGUI_MovesCount();

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
			//boardMatrix = str;
			//UpdateGUI_BoardID();

			StartCoroutine(ResizeBorders(.5f));
		}

		//GameLog.StartGame(str, boardWidth, boardHeight);

		gameEnded = false;
		isBusy = false;

		//panelScore.SetActive(false);
		//panelBottom.SetActive(true);
		//textBoardID.gameObject.SetActive(true);
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
		//panelCurrentScore.SetActive(true);
		//UpdateGUI_MovesCount();

		int x = 0;
		int y = 0;
		for (int i = 0; i < id.Length; ++i) {
			cards[x, y].ResetCard();
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

		//UpdateGUI_BoardID();

		//GameDataWWW.GetBoardInfo(id, true);

		//GameLog.StartGame(id, boardWidth, boardHeight);

		gameEnded = false;
		isBusy = false;

		//panelScore.SetActive(false);
		//panelBottom.SetActive(true);
		//textBoardID.gameObject.SetActive(true);

		StartCoroutine(ResizeBorders(.5f));
	}
	#endregion

	#region GAME_LOGIC
	void ProcessTouch(float touchX, float touchY) {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(touchX, touchY, 0));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name.StartsWith("Card")) {
			TurnCard card = hit.collider.GetComponent<TurnCard>();

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

				//UpdateGUI_MovesCount();

				//GameLog.AddMove(x, y);
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

		//		GameObject.Find("Text_Moves").GetComponent<Text>().text = "" + 
		//			 "Width[" + currentBoardMinWidth  + "," + currentBoardMaxWidth  + "]\n" + 
		//			"Height[" + currentBoardMinHeight + "," + currentBoardMaxHeight + "]\n";

		yield break;

		EndGame:
		gameEnded = true;

		//EndGame();

		//GameLog.EndGame();
		//GameDataWWW.UpdateBoardInfo(
		//	boardMatrix,
		//	scoreCount,
		//	GameLog.GetTime(),
		//	GameLog.GetMoves()
		//);

		//GameData.SaveBoard(boardLevel, boardID);


		//textTimerCountdown.text = "Next In 5";
		//if (retry)
		//	goto EndFunc;
		//yield return new WaitForSeconds(1);
		//if (retry)
		//	goto EndFunc;
		//textTimerCountdown.text = "Next In 4";
		//yield return new WaitForSeconds(1);
		//if (retry)
		//	goto EndFunc;
		//textTimerCountdown.text = "Next In 3";
		//yield return new WaitForSeconds(1);
		//if (retry)
		//	goto EndFunc;
		//textTimerCountdown.text = "Next In 2";
		//yield return new WaitForSeconds(1);
		//if (retry)
		//	goto EndFunc;
		//textTimerCountdown.text = "Next In 1";
		//yield return new WaitForSeconds(1);
		//if (retry)
		//	goto EndFunc;
		//textTimerCountdown.text = "Next\nIn 0";
		//yield return new WaitForSeconds(.2f);


		//if (retry) {
		//	goto EndFunc;
		//}
		//else {
		//	if (isRandom) {
		//		GenerateRandomMatrix();
		//	}
		//	else {
		//		GenerateNextMatrix();
		//	}
		//}

		EndFunc:
		retry = false;
		yield break;
	}

	IEnumerator WaitNext() {
		yield return new WaitForSeconds(1);
		isBusy = false;
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		//boardWidth = 8;
		//boardHeight = 8;

		//CreateCardMatrix();
		//GenerateRandomMatrix();


		//boardWidth = 6;
		//boardHeight = 6;

		//AdjustCamera();

		//for (int i = 0; i < 8; ++i) {
		//	for (int j = boardWidth; j < 8; ++j) {
		//		cards[i, j].HideCard();
		//		}
		//}
		//for (int j = 0; j < 8; ++j) {
		//	for (int i = boardWidth; i < 8; ++i) {
		//		cards[i, j].HideCard();
		//	}
		//}
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0)) {
			if (!isBusy)
				ProcessTouch(Input.mousePosition.x, Input.mousePosition.y);

		}
#else
		//if (Input.touchCount > 0/* && Input.touches[0].phase == TouchPhase.Began*/)
		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
		{
			if(!isBusy)
				ProcessTouch(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
		}
#endif
	}
	#endregion
}
