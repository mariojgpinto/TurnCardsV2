using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPAssets;


[Prefab("Controller", true)]
public class Controller : Singleton<Controller> {
	#region VARIABLES
	DataManager dataManager;

	GUIManager uiManager;

	AdmobManager admob;
	#endregion

	#region SETUP
	public void Initialize() {
		dataManager = this.GetComponent<DataManager>();
		uiManager = this.GetComponent<GUIManager>();
		admob = this.GetComponent<AdmobManager>();


		dataManager.InitializeData();

		dataManager.LoadRemoteInfo();

		StartCoroutine(WaitLoading());

		//admob.ShowBannerRelative();
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
	public void StartGame(Board board) {
		Debug.Log("Start Game - " + board.matrix);
	}

	public void StartTimedGame(TimePack pack, int time) {
		Debug.Log("Start Timed Game (" + pack.boardSize + "," + pack.boardSize + ") - " + time + "seconds");
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start() {
		Initialize();

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
