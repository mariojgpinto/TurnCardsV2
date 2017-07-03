using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPAssets;

[Prefab("GUIManager", true)]
public class GUIManager : Singleton<GUIManager> {
	#region VARIABLES
	
	#endregion

	#region SETUP
	void AssignEvents() {
		GUI_Controller.GUI_Main_ButtonPressed += OnButton_Main;
		GUI_Controller.GUI_Settings_ButtonPressed += OnButton_Settings;
		GUI_Controller.GUI_Levels_ButtonPressed += OnButton_Levels;
		GUI_Controller.GUI_Time_ButtonPressed += OnButton_Time;
		GUI_Controller.GUI_Boards_ButtonPressed += OnButton_Boards;
		GUI_Controller.GUI_Game_ButtonPressed += OnButton_Game;

		GUI_Controller.GUI_Settings_TogglePressed += OnToggle_Settings;

		//Debug.Log("Assign Events");
	}

	public void InitializeGUI() {
		//INITIALIZE GAME TYPE MENUS
		GUI_Controller.instance.gui_Levels.GetComponent<Packs_Script>().Initialize();

		//INITIALIZE BOARDS PAGES
	}
	#endregion

	#region GUI_CALLBACKS
	void OnButton_Main(object sender, ButtonPressedEventArgs e) {
		switch (e.id) {
			case "freePlay_Button": //MAIN - FREEPLAY
				Debug.Log(e.id + " - MAIN - BUTTON FREEPLAY");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Main, GUI_Controller.instance.gui_Levels);
				break;
			case "timePlay_Button": //MAIN - TIMEPLAY
				Debug.Log(e.id + " - MAIN - BUTTON TIMEPLAY");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Main, GUI_Controller.instance.gui_Time);
				GUI_Controller.instance.gui_Time.GetComponent<Time_Script>().Initialize();
				break;
			case "settings_Button": //MAIN - SETTINGS
				Debug.Log(e.id + " - MAIN - BUTTON SETTINGS");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Main, GUI_Controller.instance.gui_Settings);
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().Initialize();
				break;
			default:
				break;
		}
	}

	void OnButton_Settings(object sender, ButtonPressedEventArgs e) {
		switch (e.id) {
			case "top_back_Button": //SETTINGS - BACK
				Debug.Log(e.id + " - SETTINGS - BUTTON BACK");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Settings, GUI_Controller.instance.gui_Main);
				break;
			case "buttons_themes_Button": //SETTINGS - THEMES
				Debug.Log(e.id + " - SETTINGS - BUTTON THEMES");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelThemes(true);
				break;
			case "buttons_language_Button": //SETTINGS - LANGUAGE
				Debug.Log(e.id + " - SETTINGS - BUTTON LANGUAGE");

				break;
			case "buttons_reset_Button": //SETTINGS - RESET
				Debug.Log(e.id + " - SETTINGS - BUTTON RESET");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelReset(true);
				break;
			case "buttons_remove_Button": //SETTINGS - REMOVE
				Debug.Log(e.id + " - SETTINGS - BUTTON REMOVE");

				break;
			case "buttons_about_Button": //SETTINGS - ABOUT
				Debug.Log(e.id + " - SETTINGS - BUTTON ABOUT");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelAbout(true);
				break;
			case "reset_sideClose_Button": //SETTINGS - SIDECLOSE
				Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelReset(false);
				break;
			case "reset_content_cancel_Button": //SETTINGS - CANCEL
				Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelReset(false);
				break;
			case "reset_content_ok_Button": //SETTINGS - OK
				Debug.Log(e.id + " - SETTINGS - BUTTON OK");

				break;
			case "reset_content_close_Button": //SETTINGS - CLOSE
				Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelReset(false);
				break;
			//case "language_sideClose_Button": //SETTINGS - SIDECLOSE
			//	Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");

			//	break;
			//case "language_content_cancel_Button": //SETTINGS - CANCEL
			//	Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");

			//	break;
			//case "language_content_ok_Button": //SETTINGS - OK
			//	Debug.Log(e.id + " - SETTINGS - BUTTON OK");

			//	break;
			//case "language_content_close_Button": //SETTINGS - CLOSE
			//	Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");

			//	break;
			case "themes_sideClose_Button": //SETTINGS - SIDECLOSE
				Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelThemes(false);
				break;
			case "themes_content_cancel_Button": //SETTINGS - CANCEL
				Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelThemes(false);
				break;
			case "themes_content_ok_Button": //SETTINGS - OK
				Debug.Log(e.id + " - SETTINGS - BUTTON OK");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelThemes(false);
				break;
			case "themes_content_close_Button": //SETTINGS - CLOSE
				Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelThemes(false);
				break;
			case "about_sideClose_Button": //SETTINGS - SIDECLOSE
				//Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");
			case "about_content_cancel_Button": //SETTINGS - CANCEL
				//Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");
			case "about_content_ok_Button": //SETTINGS - OK
				//Debug.Log(e.id + " - SETTINGS - BUTTON OK");
			case "about_content_close_Button": //SETTINGS - CLOSE
				Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");
				GUI_Controller.instance.gui_Settings.GetComponent<Settings_Script>().SetPanelAbout(false);
				break;
			default:
				break;
		}
	}

	void OnToggle_Settings(object sender, TogglePressedEventArgs e) {
		switch (e.id) {
			case "themes_content_listColors_white_Toggle": //SETTINGS - WHITE
				Debug.Log(e.id + " - SETTINGS - TOGGLE WHITE (" + e.value + ")");

				if (e.value) {

				}
				else {

				}

				break;
			case "themes_content_listColors_red_Toggle": //SETTINGS - RED
				Debug.Log(e.id + " - SETTINGS - TOGGLE RED (" + e.value + ")");

				if (e.value) {

				}
				else {

				}

				break;
			case "themes_content_listColors_blue_Toggle": //SETTINGS - BLUE
				Debug.Log(e.id + " - SETTINGS - TOGGLE BLUE (" + e.value + ")");

				if (e.value) {

				}
				else {

				}

				break;
			case "themes_content_listColors_green_Toggle": //SETTINGS - GREEN
				Debug.Log(e.id + " - SETTINGS - TOGGLE GREEN (" + e.value + ")");

				if (e.value) {

				}
				else {

				}

				break;
			case "themes_content_listColors_yellow_Toggle": //SETTINGS - YELLOW
				Debug.Log(e.id + " - SETTINGS - TOGGLE YELLOW (" + e.value + ")");

				if (e.value) {

				}
				else {

				}

				break;
			case "themes_content_listColors_pink_Toggle": //SETTINGS - PINK
				Debug.Log(e.id + " - SETTINGS - TOGGLE PINK (" + e.value + ")");

				if (e.value) {

				}
				else {

				}

				break;
			default:
				break;
		}
	}

	void OnButton_Levels(object sender, ButtonPressedEventArgs e) {
		switch (e.id) {
			case "top_back_Button": //LEVELS - BACK
				Debug.Log(e.id + " - LEVELS - BUTTON BACK");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Levels, GUI_Controller.instance.gui_Main);
				break;
			default:
				break;
		}
	}

	void OnButton_Time(object sender, ButtonPressedEventArgs e) {
		TimePack pack = GUI_Controller.instance.gui_Time.GetComponent<Time_Script>().currentPack;

		switch (e.id) {
			case "top_back_Button": //TIME - BACK
				Debug.Log(e.id + " - TIME - BUTTON BACK");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Time, GUI_Controller.instance.gui_Main);
				break;
			case "buttons_boards_Button": //TIME - BOARDS
				Debug.Log(e.id + " - TIME - BUTTON BOARDS");
				GUI_Time.boardSize_Panel_gameObject.SetActive(true);
				break;
			case "buttons_t30_Button": //TIME - T30
				Debug.Log(e.id + " - TIME - BUTTON T30");
				Controller.instance.StartTimedGame(pack, 30);
				break;
			case "buttons_t60_Button": //TIME - T60
				Debug.Log(e.id + " - TIME - BUTTON T60");				
				Controller.instance.StartTimedGame(pack, 60);
				break;
			case "buttons_t90_Button": //TIME - T90
				Debug.Log(e.id + " - TIME - BUTTON T90");
				Controller.instance.StartTimedGame(pack, 90);
				break;
			case "buttons_t120_Button": //TIME - T120
				Debug.Log(e.id + " - TIME - BUTTON T120");
				Controller.instance.StartTimedGame(pack, 120);
				break;
			case "buttons_t180_Button": //TIME - T180
				Debug.Log(e.id + " - TIME - BUTTON T180");
				Controller.instance.StartTimedGame(pack, 180);
				break;
			//case "buttons_t240_Button": //TIME - T240
			//	Debug.Log(e.id + " - TIME - BUTTON T240");
			//	Controller.instance.StartTimedGame(pack, 240);
			//	break;
			case "boardSize_sideClose_Button": //TIME - SIDECLOSE
				//Debug.Log(e.id + " - TIME - BUTTON SIDECLOSE");
			case "boardSize_content_ok_Button": //TIME - OK
				//Debug.Log(e.id + " - TIME - BUTTON OK");
			case "boardSize_content_close_Button": //TIME - CLOSE
				//Debug.Log(e.id + " - TIME - BUTTON CLOSE");
				GUI_Time.boardSize_Panel_gameObject.SetActive(false);
				break;
			default:
				break;
		}
	}
	
	void OnButton_Boards(object sender, ButtonPressedEventArgs e) {
		switch (e.id) {
			case "top_back_Button": //BOARDS - BACK
				Debug.Log(e.id + " - BOARDS - BUTTON BACK");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Boards, GUI_Controller.instance.gui_Levels);
				break;
			default:
				break;
		}
	}

	void OnButton_Game(object sender, ButtonPressedEventArgs e) {
		switch (e.id) {
			case "top_back_Button": //GAME - BACK
				Debug.Log(e.id + " - GAME - BUTTON BACK");
				GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Game, GUI_Controller.instance.gui_Boards);

				break;
			case "running_bottom_settings_Button": //GAME - SETTINGS
				Debug.Log(e.id + " - GAME - BUTTON SETTINGS");

				break;
			case "running_bottom_restart_Button": //GAME - RESTART
				Debug.Log(e.id + " - GAME - BUTTON RESTART");

				break;
			case "running_bottom_next_Button": //GAME - NEXT
				Debug.Log(e.id + " - GAME - BUTTON NEXT");

				break;
			case "finish_again_Button": //GAME - AGAIN
				Debug.Log(e.id + " - GAME - BUTTON AGAIN");

				break;
			case "finish_next_Button": //GAME - NEXT
				Debug.Log(e.id + " - GAME - BUTTON NEXT");

				break;
			case "finishTimed_again_Button": //GAME - AGAIN
				Debug.Log(e.id + " - GAME - BUTTON AGAIN");

				break;
			case "finishTimed_next_Button": //GAME - NEXT
				Debug.Log(e.id + " - GAME - BUTTON NEXT");

				break;
			case "pause_sideClose_Button": //GAME - SIDECLOSE
				Debug.Log(e.id + " - GAME - BUTTON SIDECLOSE");

				break;
			case "pause_content_close_Button": //GAME - CLOSE
				Debug.Log(e.id + " - GAME - BUTTON CLOSE");

				break;
			case "pause_content_settings_Button": //GAME - SETTINGS
				Debug.Log(e.id + " - GAME - BUTTON SETTINGS");

				break;
			case "pause_content_exit_Button": //GAME - EXIT
				Debug.Log(e.id + " - GAME - BUTTON EXIT");

				break;
			default:
				break;
		}
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		AssignEvents();
	}
	#endregion
}
