using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPAssets;


[Prefab("Controller", true)]
public class Controller : Singleton<Controller> {
	#region VARIABLES
	public DataManager dataManager;

	public GUIManager uiManager;

	public AdmobManager admob;

	public GameRegular_Script gameRegular;
	public GameTimed_Script gameTimed;
	#endregion

	#region SETUP
	public void Initialize() {
		dataManager = this.GetComponent<DataManager>();
		uiManager = this.GetComponent<GUIManager>();
		admob = this.GetComponent<AdmobManager>();

		dataManager.InitializeData();

		dataManager.LoadRemoteInfo();

		gameRegular = GUI_Controller.instance.gui_GameRegular.GetComponent<GameRegular_Script>();
		gameRegular.Initialize();

		gameTimed = GUI_Controller.instance.gui_GameTimed.GetComponent<GameTimed_Script>();
		gameTimed.Initialize();

		//admob.Initialize();

		StartCoroutine(WaitLoading());
	}

	IEnumerator WaitLoading() {
		float startTime = Time.realtimeSinceStartup;

		while (dataManager.data.boards_state == Macros.DATA_STATE.NOT_LOADED &&
				dataManager.data.packs_state == Macros.DATA_STATE.NOT_LOADED) {

			yield return new WaitForSeconds(.1f);
		}

		uiManager.InitializeGUI();

		while (Time.realtimeSinceStartup - startTime < 2) {
			yield return new WaitForSeconds(.2f);
		}

		Debug.Log("Finish Wait Loading");

	}

	public void OnButtonPressed() {
		Debug.Log("Pressed");
	}
	#endregion

	#region CALLBACKS
	public void StartRegularGame(string level, Board board) {
		Debug.Log("Start Game - " + board.matrix);
		GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Boards, GUI_Controller.instance.gui_GameRegular);

		int lvl = System.Convert.ToInt32(level);
		gameRegular.InitializeNewBoard(lvl, board);
	}

	public void StartTimedGame(TimePack pack, int time) {
		Debug.Log("Start Timed Game (" + pack.boardSize + "," + pack.boardSize + ") - " + time + "seconds");
		GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Time, GUI_Controller.instance.gui_GameTimed);

		gameTimed.InitializeTimedGame(pack, time);
		//gameRegular.InitializeTimedGame(pack, time);
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start() {
		Initialize();

		//GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Main, GUI_Controller.instance.gui_Game);

		//TimePack t = new TimePack(4);
		//t.records.Add(new TimePackRecord() { time = 30, score = 0 });
		//t.records.Add(new TimePackRecord() { time = 60, score = 0 });
		//t.records.Add(new TimePackRecord() { time = 90, score = 0 });
		//t.records.Add(new TimePackRecord() { time = 120, score = 0 });
		//t.records.Add(new TimePackRecord() { time = 180, score = 0 });
		//DataManager.instance.data.timePacks.Add(t);
		//DataManager.instance.data.timePacks.Add(new TimePack(6));
		//DataManager.instance.data.timePacks.Add(new TimePack(8));

		//dataManager.SaveLocalInfo();
	}
	#endregion
}
