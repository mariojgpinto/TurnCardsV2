using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

[Prefab("GUI_Controller", true)]
public class GUI_Controller : Singleton<GUI_Controller> {
	#region VARIABLES
	public GameObject gui_Main;
	public GameObject gui_Settings;
	public GameObject gui_Levels;
	public GameObject gui_Time;
	public GameObject gui_Boards;
	public GameObject gui_GameRegular;
	public GameObject gui_GameTimed;

	public static event EventHandler<ButtonPressedEventArgs> GUI_Main_ButtonPressed;

	public static event EventHandler<ButtonPressedEventArgs> GUI_Settings_ButtonPressed;
	public static event EventHandler<TogglePressedEventArgs> GUI_Settings_TogglePressed;

	public static event EventHandler<ButtonPressedEventArgs> GUI_Levels_ButtonPressed;

	public static event EventHandler<ButtonPressedEventArgs> GUI_Time_ButtonPressed;

	public static event EventHandler<ButtonPressedEventArgs> GUI_Boards_ButtonPressed;

	public static event EventHandler<ButtonPressedEventArgs> GUI_GameRegular_ButtonPressed;

	public static event EventHandler<ButtonPressedEventArgs> GUI_GameTimed_ButtonPressed;

	#endregion

	#region SETUP
	void FindGameObjects(){
		for(int i = 0 ; i < this.transform.childCount ; ++i){
			GameObject go = this.transform.GetChild(i).gameObject;

			switch(go.name){
				case "Panel_Main":
					gui_Main = go;
					break;
				case "Panel_Settings":
					gui_Settings = go;
					break;
				case "Panel_Levels":
					gui_Levels = go;
					break;
				case "Panel_Time":
					gui_Time = go;
					break;
				case "Panel_Boards":
					gui_Boards = go;
					break;
				case "Panel_GameRegular":
					gui_GameRegular = go;
					break;
				case "Panel_GameTimed":
					gui_GameTimed = go;
					break;
				default: break;
			}
		}
	}

	void InitializeClasses(){
		gui_Main.GetComponent<RectTransform>().localPosition = Vector3.zero;
		gui_Settings.GetComponent<RectTransform>().localPosition = Vector3.zero;
		gui_Levels.GetComponent<RectTransform>().localPosition = Vector3.zero;
		gui_Time.GetComponent<RectTransform>().localPosition = Vector3.zero;
		gui_Boards.GetComponent<RectTransform>().localPosition = Vector3.zero;
		gui_GameRegular.GetComponent<RectTransform>().localPosition = Vector3.zero;
		gui_GameTimed.GetComponent<RectTransform>().localPosition = Vector3.zero;

		GUI_Main.UpdateValues(gui_Main);
		GUI_Settings.UpdateValues(gui_Settings);
		GUI_Levels.UpdateValues(gui_Levels);
		GUI_Time.UpdateValues(gui_Time);
		GUI_Boards.UpdateValues(gui_Boards);
		GUI_GameRegular.UpdateValues(gui_GameRegular);
		GUI_GameTimed.UpdateValues(gui_GameTimed);
		gui_Main.gameObject.SetActive(true);
		gui_Settings.gameObject.SetActive(false);
		gui_Levels.gameObject.SetActive(false);
		gui_Time.gameObject.SetActive(false);
		gui_Boards.gameObject.SetActive(false);
		gui_GameRegular.gameObject.SetActive(false);
		gui_GameTimed.gameObject.SetActive(false);
	}

	void InitializeListeners(){
		GUI_Main.freePlay_Button.onClick.AddListener(() => Event_OnButton_Main("freePlay_Button"));
		GUI_Main.timePlay_Button.onClick.AddListener(() => Event_OnButton_Main("timePlay_Button"));
		GUI_Main.settings_Button.onClick.AddListener(() => Event_OnButton_Main("settings_Button"));

		GUI_Settings.top_back_Button.onClick.AddListener(() => Event_OnButton_Settings("top_back_Button"));
		GUI_Settings.buttons_themes_Button.onClick.AddListener(() => Event_OnButton_Settings("buttons_themes_Button"));
		GUI_Settings.buttons_language_Button.onClick.AddListener(() => Event_OnButton_Settings("buttons_language_Button"));
		GUI_Settings.buttons_reset_Button.onClick.AddListener(() => Event_OnButton_Settings("buttons_reset_Button"));
		GUI_Settings.buttons_remove_Button.onClick.AddListener(() => Event_OnButton_Settings("buttons_remove_Button"));
		GUI_Settings.buttons_about_Button.onClick.AddListener(() => Event_OnButton_Settings("buttons_about_Button"));
		GUI_Settings.reset_sideClose_Button.onClick.AddListener(() => Event_OnButton_Settings("reset_sideClose_Button"));
		GUI_Settings.reset_content_cancel_Button.onClick.AddListener(() => Event_OnButton_Settings("reset_content_cancel_Button"));
		GUI_Settings.reset_content_ok_Button.onClick.AddListener(() => Event_OnButton_Settings("reset_content_ok_Button"));
		GUI_Settings.reset_content_close_Button.onClick.AddListener(() => Event_OnButton_Settings("reset_content_close_Button"));
		GUI_Settings.language_sideClose_Button.onClick.AddListener(() => Event_OnButton_Settings("language_sideClose_Button"));
		GUI_Settings.language_content_cancel_Button.onClick.AddListener(() => Event_OnButton_Settings("language_content_cancel_Button"));
		GUI_Settings.language_content_ok_Button.onClick.AddListener(() => Event_OnButton_Settings("language_content_ok_Button"));
		GUI_Settings.language_content_close_Button.onClick.AddListener(() => Event_OnButton_Settings("language_content_close_Button"));
		GUI_Settings.themes_sideClose_Button.onClick.AddListener(() => Event_OnButton_Settings("themes_sideClose_Button"));
		GUI_Settings.themes_content_cancel_Button.onClick.AddListener(() => Event_OnButton_Settings("themes_content_cancel_Button"));
		GUI_Settings.themes_content_ok_Button.onClick.AddListener(() => Event_OnButton_Settings("themes_content_ok_Button"));
		GUI_Settings.themes_content_close_Button.onClick.AddListener(() => Event_OnButton_Settings("themes_content_close_Button"));
		GUI_Settings.about_sideClose_Button.onClick.AddListener(() => Event_OnButton_Settings("about_sideClose_Button"));
		GUI_Settings.about_content_cancel_Button.onClick.AddListener(() => Event_OnButton_Settings("about_content_cancel_Button"));
		GUI_Settings.about_content_ok_Button.onClick.AddListener(() => Event_OnButton_Settings("about_content_ok_Button"));
		GUI_Settings.about_content_close_Button.onClick.AddListener(() => Event_OnButton_Settings("about_content_close_Button"));

		GUI_Settings.themes_content_listColors_white_Toggle.onValueChanged.AddListener((bool value) => Event_OnToggle_Settings("themes_content_listColors_white_Toggle", value));
		GUI_Settings.themes_content_listColors_red_Toggle.onValueChanged.AddListener((bool value) => Event_OnToggle_Settings("themes_content_listColors_red_Toggle", value));
		GUI_Settings.themes_content_listColors_blue_Toggle.onValueChanged.AddListener((bool value) => Event_OnToggle_Settings("themes_content_listColors_blue_Toggle", value));
		GUI_Settings.themes_content_listColors_green_Toggle.onValueChanged.AddListener((bool value) => Event_OnToggle_Settings("themes_content_listColors_green_Toggle", value));
		GUI_Settings.themes_content_listColors_yellow_Toggle.onValueChanged.AddListener((bool value) => Event_OnToggle_Settings("themes_content_listColors_yellow_Toggle", value));
		GUI_Settings.themes_content_listColors_pink_Toggle.onValueChanged.AddListener((bool value) => Event_OnToggle_Settings("themes_content_listColors_pink_Toggle", value));

		GUI_Levels.top_back_Button.onClick.AddListener(() => Event_OnButton_Levels("top_back_Button"));

		GUI_Time.top_back_Button.onClick.AddListener(() => Event_OnButton_Time("top_back_Button"));
		GUI_Time.buttons_boards_Button.onClick.AddListener(() => Event_OnButton_Time("buttons_boards_Button"));
		GUI_Time.buttons_t30_Button.onClick.AddListener(() => Event_OnButton_Time("buttons_t30_Button"));
		GUI_Time.buttons_t60_Button.onClick.AddListener(() => Event_OnButton_Time("buttons_t60_Button"));
		GUI_Time.buttons_t90_Button.onClick.AddListener(() => Event_OnButton_Time("buttons_t90_Button"));
		GUI_Time.buttons_t120_Button.onClick.AddListener(() => Event_OnButton_Time("buttons_t120_Button"));
		GUI_Time.buttons_t180_Button.onClick.AddListener(() => Event_OnButton_Time("buttons_t180_Button"));
		GUI_Time.buttons_t240_Button.onClick.AddListener(() => Event_OnButton_Time("buttons_t240_Button"));
		GUI_Time.boardSize_sideClose_Button.onClick.AddListener(() => Event_OnButton_Time("boardSize_sideClose_Button"));
		GUI_Time.boardSize_content_ok_Button.onClick.AddListener(() => Event_OnButton_Time("boardSize_content_ok_Button"));
		GUI_Time.boardSize_content_close_Button.onClick.AddListener(() => Event_OnButton_Time("boardSize_content_close_Button"));

		GUI_Boards.top_back_Button.onClick.AddListener(() => Event_OnButton_Boards("top_back_Button"));

		GUI_GameRegular.top_back_Button.onClick.AddListener(() => Event_OnButton_GameRegular("top_back_Button"));
		GUI_GameRegular.running_bottom_previous_Button.onClick.AddListener(() => Event_OnButton_GameRegular("running_bottom_previous_Button"));
		GUI_GameRegular.running_bottom_restart_Button.onClick.AddListener(() => Event_OnButton_GameRegular("running_bottom_restart_Button"));
		GUI_GameRegular.running_bottom_next_Button.onClick.AddListener(() => Event_OnButton_GameRegular("running_bottom_next_Button"));
		GUI_GameRegular.finish_again_Button.onClick.AddListener(() => Event_OnButton_GameRegular("finish_again_Button"));
		GUI_GameRegular.finish_next_Button.onClick.AddListener(() => Event_OnButton_GameRegular("finish_next_Button"));

		GUI_GameTimed.top_back_Button.onClick.AddListener(() => Event_OnButton_GameTimed("top_back_Button"));
		GUI_GameTimed.running_bottom_reset_Button.onClick.AddListener(() => Event_OnButton_GameTimed("running_bottom_reset_Button"));
		GUI_GameTimed.running_bottom_pause_Button.onClick.AddListener(() => Event_OnButton_GameTimed("running_bottom_pause_Button"));
		GUI_GameTimed.running_bottom_next_Button.onClick.AddListener(() => Event_OnButton_GameTimed("running_bottom_next_Button"));
		GUI_GameTimed.finish_again_Button.onClick.AddListener(() => Event_OnButton_GameTimed("finish_again_Button"));
		GUI_GameTimed.finish_back_Button.onClick.AddListener(() => Event_OnButton_GameTimed("finish_back_Button"));
		GUI_GameTimed.pause_sideClose_Button.onClick.AddListener(() => Event_OnButton_GameTimed("pause_sideClose_Button"));
		GUI_GameTimed.pause_content_close_Button.onClick.AddListener(() => Event_OnButton_GameTimed("pause_content_close_Button"));
		GUI_GameTimed.pause_content_continue_Button.onClick.AddListener(() => Event_OnButton_GameTimed("pause_content_continue_Button"));
		GUI_GameTimed.pause_content_exit_Button.onClick.AddListener(() => Event_OnButton_GameTimed("pause_content_exit_Button"));

	}

	protected static void OnButtonPressed(string id, string desc, EventHandler<ButtonPressedEventArgs> handler){
		ButtonPressedEventArgs args = new ButtonPressedEventArgs();
		args.id = id;
		args.description = desc;

		if(handler != null){
			handler(GUI_Controller.instance, args);
		}
	}

	protected static void OnTogglePressed(string id, string desc, bool value, EventHandler<TogglePressedEventArgs> handler){
		TogglePressedEventArgs args = new TogglePressedEventArgs();
		args.id = id;
		args.description = desc;

		args.value = value;

		if(handler != null){
			handler(GUI_Controller.instance, args);
		}
	}
	#endregion

	#region CALLBACKS
	void Event_OnButton_Main(string id){
		switch(id){
			case "freePlay_Button" : //MAIN - FREEPLAY
				OnButtonPressed(id, "MAIN - BUTTON FREEPLAY",GUI_Main_ButtonPressed);
				break;
			case "timePlay_Button" : //MAIN - TIMEPLAY
				OnButtonPressed(id, "MAIN - BUTTON TIMEPLAY",GUI_Main_ButtonPressed);
				break;
			case "settings_Button" : //MAIN - SETTINGS
				OnButtonPressed(id, "MAIN - BUTTON SETTINGS",GUI_Main_ButtonPressed);
				break;
			default: break;
		}
	}

	void Event_OnButton_Settings(string id){
		switch(id){
			case "top_back_Button" : //SETTINGS - BACK
				OnButtonPressed(id, "SETTINGS - BUTTON BACK",GUI_Settings_ButtonPressed);
				break;
			case "buttons_themes_Button" : //SETTINGS - THEMES
				OnButtonPressed(id, "SETTINGS - BUTTON THEMES",GUI_Settings_ButtonPressed);
				break;
			case "buttons_language_Button" : //SETTINGS - LANGUAGE
				OnButtonPressed(id, "SETTINGS - BUTTON LANGUAGE",GUI_Settings_ButtonPressed);
				break;
			case "buttons_reset_Button" : //SETTINGS - RESET
				OnButtonPressed(id, "SETTINGS - BUTTON RESET",GUI_Settings_ButtonPressed);
				break;
			case "buttons_remove_Button" : //SETTINGS - REMOVE
				OnButtonPressed(id, "SETTINGS - BUTTON REMOVE",GUI_Settings_ButtonPressed);
				break;
			case "buttons_about_Button" : //SETTINGS - ABOUT
				OnButtonPressed(id, "SETTINGS - BUTTON ABOUT",GUI_Settings_ButtonPressed);
				break;
			case "reset_sideClose_Button" : //SETTINGS - SIDECLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON SIDECLOSE",GUI_Settings_ButtonPressed);
				break;
			case "reset_content_cancel_Button" : //SETTINGS - CANCEL
				OnButtonPressed(id, "SETTINGS - BUTTON CANCEL",GUI_Settings_ButtonPressed);
				break;
			case "reset_content_ok_Button" : //SETTINGS - OK
				OnButtonPressed(id, "SETTINGS - BUTTON OK",GUI_Settings_ButtonPressed);
				break;
			case "reset_content_close_Button" : //SETTINGS - CLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON CLOSE",GUI_Settings_ButtonPressed);
				break;
			case "language_sideClose_Button" : //SETTINGS - SIDECLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON SIDECLOSE",GUI_Settings_ButtonPressed);
				break;
			case "language_content_cancel_Button" : //SETTINGS - CANCEL
				OnButtonPressed(id, "SETTINGS - BUTTON CANCEL",GUI_Settings_ButtonPressed);
				break;
			case "language_content_ok_Button" : //SETTINGS - OK
				OnButtonPressed(id, "SETTINGS - BUTTON OK",GUI_Settings_ButtonPressed);
				break;
			case "language_content_close_Button" : //SETTINGS - CLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON CLOSE",GUI_Settings_ButtonPressed);
				break;
			case "themes_sideClose_Button" : //SETTINGS - SIDECLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON SIDECLOSE",GUI_Settings_ButtonPressed);
				break;
			case "themes_content_cancel_Button" : //SETTINGS - CANCEL
				OnButtonPressed(id, "SETTINGS - BUTTON CANCEL",GUI_Settings_ButtonPressed);
				break;
			case "themes_content_ok_Button" : //SETTINGS - OK
				OnButtonPressed(id, "SETTINGS - BUTTON OK",GUI_Settings_ButtonPressed);
				break;
			case "themes_content_close_Button" : //SETTINGS - CLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON CLOSE",GUI_Settings_ButtonPressed);
				break;
			case "about_sideClose_Button" : //SETTINGS - SIDECLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON SIDECLOSE",GUI_Settings_ButtonPressed);
				break;
			case "about_content_cancel_Button" : //SETTINGS - CANCEL
				OnButtonPressed(id, "SETTINGS - BUTTON CANCEL",GUI_Settings_ButtonPressed);
				break;
			case "about_content_ok_Button" : //SETTINGS - OK
				OnButtonPressed(id, "SETTINGS - BUTTON OK",GUI_Settings_ButtonPressed);
				break;
			case "about_content_close_Button" : //SETTINGS - CLOSE
				OnButtonPressed(id, "SETTINGS - BUTTON CLOSE",GUI_Settings_ButtonPressed);
				break;
			default: break;
		}
	}

	void Event_OnButton_Levels(string id){
		switch(id){
			case "top_back_Button" : //LEVELS - BACK
				OnButtonPressed(id, "LEVELS - BUTTON BACK",GUI_Levels_ButtonPressed);
				break;
			default: break;
		}
	}

	void Event_OnButton_Time(string id){
		switch(id){
			case "top_back_Button" : //TIME - BACK
				OnButtonPressed(id, "TIME - BUTTON BACK",GUI_Time_ButtonPressed);
				break;
			case "buttons_boards_Button" : //TIME - BOARDS
				OnButtonPressed(id, "TIME - BUTTON BOARDS",GUI_Time_ButtonPressed);
				break;
			case "buttons_t30_Button" : //TIME - T30
				OnButtonPressed(id, "TIME - BUTTON T30",GUI_Time_ButtonPressed);
				break;
			case "buttons_t60_Button" : //TIME - T60
				OnButtonPressed(id, "TIME - BUTTON T60",GUI_Time_ButtonPressed);
				break;
			case "buttons_t90_Button" : //TIME - T90
				OnButtonPressed(id, "TIME - BUTTON T90",GUI_Time_ButtonPressed);
				break;
			case "buttons_t120_Button" : //TIME - T120
				OnButtonPressed(id, "TIME - BUTTON T120",GUI_Time_ButtonPressed);
				break;
			case "buttons_t180_Button" : //TIME - T180
				OnButtonPressed(id, "TIME - BUTTON T180",GUI_Time_ButtonPressed);
				break;
			case "buttons_t240_Button" : //TIME - T240
				OnButtonPressed(id, "TIME - BUTTON T240",GUI_Time_ButtonPressed);
				break;
			case "boardSize_sideClose_Button" : //TIME - SIDECLOSE
				OnButtonPressed(id, "TIME - BUTTON SIDECLOSE",GUI_Time_ButtonPressed);
				break;
			case "boardSize_content_ok_Button" : //TIME - OK
				OnButtonPressed(id, "TIME - BUTTON OK",GUI_Time_ButtonPressed);
				break;
			case "boardSize_content_close_Button" : //TIME - CLOSE
				OnButtonPressed(id, "TIME - BUTTON CLOSE",GUI_Time_ButtonPressed);
				break;
			default: break;
		}
	}

	void Event_OnButton_Boards(string id){
		switch(id){
			case "top_back_Button" : //BOARDS - BACK
				OnButtonPressed(id, "BOARDS - BUTTON BACK",GUI_Boards_ButtonPressed);
				break;
			default: break;
		}
	}

	void Event_OnButton_GameRegular(string id){
		switch(id){
			case "top_back_Button" : //GAMEREGULAR - BACK
				OnButtonPressed(id, "GAMEREGULAR - BUTTON BACK",GUI_GameRegular_ButtonPressed);
				break;
			case "running_bottom_previous_Button" : //GAMEREGULAR - PREVIOUS
				OnButtonPressed(id, "GAMEREGULAR - BUTTON PREVIOUS",GUI_GameRegular_ButtonPressed);
				break;
			case "running_bottom_restart_Button" : //GAMEREGULAR - RESTART
				OnButtonPressed(id, "GAMEREGULAR - BUTTON RESTART",GUI_GameRegular_ButtonPressed);
				break;
			case "running_bottom_next_Button" : //GAMEREGULAR - NEXT
				OnButtonPressed(id, "GAMEREGULAR - BUTTON NEXT",GUI_GameRegular_ButtonPressed);
				break;
			case "finish_again_Button" : //GAMEREGULAR - AGAIN
				OnButtonPressed(id, "GAMEREGULAR - BUTTON AGAIN",GUI_GameRegular_ButtonPressed);
				break;
			case "finish_next_Button" : //GAMEREGULAR - NEXT
				OnButtonPressed(id, "GAMEREGULAR - BUTTON NEXT",GUI_GameRegular_ButtonPressed);
				break;
			default: break;
		}
	}

	void Event_OnButton_GameTimed(string id){
		switch(id){
			case "top_back_Button" : //GAMETIMED - BACK
				OnButtonPressed(id, "GAMETIMED - BUTTON BACK",GUI_GameTimed_ButtonPressed);
				break;
			case "running_bottom_reset_Button" : //GAMETIMED - RESET
				OnButtonPressed(id, "GAMETIMED - BUTTON RESET",GUI_GameTimed_ButtonPressed);
				break;
			case "running_bottom_pause_Button" : //GAMETIMED - PAUSE
				OnButtonPressed(id, "GAMETIMED - BUTTON PAUSE",GUI_GameTimed_ButtonPressed);
				break;
			case "running_bottom_next_Button" : //GAMETIMED - NEXT
				OnButtonPressed(id, "GAMETIMED - BUTTON NEXT",GUI_GameTimed_ButtonPressed);
				break;
			case "finish_again_Button" : //GAMETIMED - AGAIN
				OnButtonPressed(id, "GAMETIMED - BUTTON AGAIN",GUI_GameTimed_ButtonPressed);
				break;
			case "finish_back_Button" : //GAMETIMED - BACK
				OnButtonPressed(id, "GAMETIMED - BUTTON BACK",GUI_GameTimed_ButtonPressed);
				break;
			case "pause_sideClose_Button" : //GAMETIMED - SIDECLOSE
				OnButtonPressed(id, "GAMETIMED - BUTTON SIDECLOSE",GUI_GameTimed_ButtonPressed);
				break;
			case "pause_content_close_Button" : //GAMETIMED - CLOSE
				OnButtonPressed(id, "GAMETIMED - BUTTON CLOSE",GUI_GameTimed_ButtonPressed);
				break;
			case "pause_content_continue_Button" : //GAMETIMED - CONTINUE
				OnButtonPressed(id, "GAMETIMED - BUTTON CONTINUE",GUI_GameTimed_ButtonPressed);
				break;
			case "pause_content_exit_Button" : //GAMETIMED - EXIT
				OnButtonPressed(id, "GAMETIMED - BUTTON EXIT",GUI_GameTimed_ButtonPressed);
				break;
			default: break;
		}
	}

	void Event_OnToggle_Settings(string id, bool value){
		switch(id){
			case "themes_content_listColors_white_Toggle" : //SETTINGS - WHITE
				OnTogglePressed(id, "SETTINGS - TOGGLE WHITE", value,GUI_Settings_TogglePressed);
				break;
			case "themes_content_listColors_red_Toggle" : //SETTINGS - RED
				OnTogglePressed(id, "SETTINGS - TOGGLE RED", value,GUI_Settings_TogglePressed);
				break;
			case "themes_content_listColors_blue_Toggle" : //SETTINGS - BLUE
				OnTogglePressed(id, "SETTINGS - TOGGLE BLUE", value,GUI_Settings_TogglePressed);
				break;
			case "themes_content_listColors_green_Toggle" : //SETTINGS - GREEN
				OnTogglePressed(id, "SETTINGS - TOGGLE GREEN", value,GUI_Settings_TogglePressed);
				break;
			case "themes_content_listColors_yellow_Toggle" : //SETTINGS - YELLOW
				OnTogglePressed(id, "SETTINGS - TOGGLE YELLOW", value,GUI_Settings_TogglePressed);
				break;
			case "themes_content_listColors_pink_Toggle" : //SETTINGS - PINK
				OnTogglePressed(id, "SETTINGS - TOGGLE PINK", value,GUI_Settings_TogglePressed);
				break;
			default: break;
		}
	}

	#endregion

	#region UNITY_CALLBACKS
	protected override void Awake(){
		base.Awake();

		if (destroyed)
			return;

		FindGameObjects();

		InitializeClasses();
		InitializeListeners();
	}

//	void Update(){
//		
//		}

//	void OnGUI(){
//		
//		}
	#endregion

	#region COMMENTS
//	void OnButton_Main(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "freePlay_Button" : //MAIN - FREEPLAY
//				Debug.Log(e.id + " - MAIN - BUTTON FREEPLAY");

//				break;
//			case "timePlay_Button" : //MAIN - TIMEPLAY
//				Debug.Log(e.id + " - MAIN - BUTTON TIMEPLAY");

//				break;
//			case "settings_Button" : //MAIN - SETTINGS
//				Debug.Log(e.id + " - MAIN - BUTTON SETTINGS");

//				break;
//			default: break;
//		}
//	}

//	void OnButton_Settings(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "top_back_Button" : //SETTINGS - BACK
//				Debug.Log(e.id + " - SETTINGS - BUTTON BACK");

//				break;
//			case "buttons_themes_Button" : //SETTINGS - THEMES
//				Debug.Log(e.id + " - SETTINGS - BUTTON THEMES");

//				break;
//			case "buttons_language_Button" : //SETTINGS - LANGUAGE
//				Debug.Log(e.id + " - SETTINGS - BUTTON LANGUAGE");

//				break;
//			case "buttons_reset_Button" : //SETTINGS - RESET
//				Debug.Log(e.id + " - SETTINGS - BUTTON RESET");

//				break;
//			case "buttons_remove_Button" : //SETTINGS - REMOVE
//				Debug.Log(e.id + " - SETTINGS - BUTTON REMOVE");

//				break;
//			case "buttons_about_Button" : //SETTINGS - ABOUT
//				Debug.Log(e.id + " - SETTINGS - BUTTON ABOUT");

//				break;
//			case "reset_sideClose_Button" : //SETTINGS - SIDECLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");

//				break;
//			case "reset_content_cancel_Button" : //SETTINGS - CANCEL
//				Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");

//				break;
//			case "reset_content_ok_Button" : //SETTINGS - OK
//				Debug.Log(e.id + " - SETTINGS - BUTTON OK");

//				break;
//			case "reset_content_close_Button" : //SETTINGS - CLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");

//				break;
//			case "language_sideClose_Button" : //SETTINGS - SIDECLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");

//				break;
//			case "language_content_cancel_Button" : //SETTINGS - CANCEL
//				Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");

//				break;
//			case "language_content_ok_Button" : //SETTINGS - OK
//				Debug.Log(e.id + " - SETTINGS - BUTTON OK");

//				break;
//			case "language_content_close_Button" : //SETTINGS - CLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");

//				break;
//			case "themes_sideClose_Button" : //SETTINGS - SIDECLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");

//				break;
//			case "themes_content_cancel_Button" : //SETTINGS - CANCEL
//				Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");

//				break;
//			case "themes_content_ok_Button" : //SETTINGS - OK
//				Debug.Log(e.id + " - SETTINGS - BUTTON OK");

//				break;
//			case "themes_content_close_Button" : //SETTINGS - CLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");

//				break;
//			case "about_sideClose_Button" : //SETTINGS - SIDECLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON SIDECLOSE");

//				break;
//			case "about_content_cancel_Button" : //SETTINGS - CANCEL
//				Debug.Log(e.id + " - SETTINGS - BUTTON CANCEL");

//				break;
//			case "about_content_ok_Button" : //SETTINGS - OK
//				Debug.Log(e.id + " - SETTINGS - BUTTON OK");

//				break;
//			case "about_content_close_Button" : //SETTINGS - CLOSE
//				Debug.Log(e.id + " - SETTINGS - BUTTON CLOSE");

//				break;
//			default: break;
//		}
//	}

//	void OnToggle_Settings(object sender, TogglePressedEventArgs e){
//		switch(e.id){
//			case "themes_content_listColors_white_Toggle" : //SETTINGS - WHITE
//				Debug.Log(e.id + " - SETTINGS - TOGGLE WHITE (" + e.value + ")");
//				
//				if(e.value){
//					
//				} else{ 
//					
//				}

//				break;
//			case "themes_content_listColors_red_Toggle" : //SETTINGS - RED
//				Debug.Log(e.id + " - SETTINGS - TOGGLE RED (" + e.value + ")");
//				
//				if(e.value){
//					
//				} else{ 
//					
//				}

//				break;
//			case "themes_content_listColors_blue_Toggle" : //SETTINGS - BLUE
//				Debug.Log(e.id + " - SETTINGS - TOGGLE BLUE (" + e.value + ")");
//				
//				if(e.value){
//					
//				} else{ 
//					
//				}

//				break;
//			case "themes_content_listColors_green_Toggle" : //SETTINGS - GREEN
//				Debug.Log(e.id + " - SETTINGS - TOGGLE GREEN (" + e.value + ")");
//				
//				if(e.value){
//					
//				} else{ 
//					
//				}

//				break;
//			case "themes_content_listColors_yellow_Toggle" : //SETTINGS - YELLOW
//				Debug.Log(e.id + " - SETTINGS - TOGGLE YELLOW (" + e.value + ")");
//				
//				if(e.value){
//					
//				} else{ 
//					
//				}

//				break;
//			case "themes_content_listColors_pink_Toggle" : //SETTINGS - PINK
//				Debug.Log(e.id + " - SETTINGS - TOGGLE PINK (" + e.value + ")");
//				
//				if(e.value){
//					
//				} else{ 
//					
//				}

//				break;
//			default: break;
//		}
//	}

//	void OnButton_Levels(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "top_back_Button" : //LEVELS - BACK
//				Debug.Log(e.id + " - LEVELS - BUTTON BACK");

//				break;
//			default: break;
//		}
//	}

//	void OnButton_Time(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "top_back_Button" : //TIME - BACK
//				Debug.Log(e.id + " - TIME - BUTTON BACK");

//				break;
//			case "buttons_boards_Button" : //TIME - BOARDS
//				Debug.Log(e.id + " - TIME - BUTTON BOARDS");

//				break;
//			case "buttons_t30_Button" : //TIME - T30
//				Debug.Log(e.id + " - TIME - BUTTON T30");

//				break;
//			case "buttons_t60_Button" : //TIME - T60
//				Debug.Log(e.id + " - TIME - BUTTON T60");

//				break;
//			case "buttons_t90_Button" : //TIME - T90
//				Debug.Log(e.id + " - TIME - BUTTON T90");

//				break;
//			case "buttons_t120_Button" : //TIME - T120
//				Debug.Log(e.id + " - TIME - BUTTON T120");

//				break;
//			case "buttons_t180_Button" : //TIME - T180
//				Debug.Log(e.id + " - TIME - BUTTON T180");

//				break;
//			case "buttons_t240_Button" : //TIME - T240
//				Debug.Log(e.id + " - TIME - BUTTON T240");

//				break;
//			case "boardSize_sideClose_Button" : //TIME - SIDECLOSE
//				Debug.Log(e.id + " - TIME - BUTTON SIDECLOSE");

//				break;
//			case "boardSize_content_ok_Button" : //TIME - OK
//				Debug.Log(e.id + " - TIME - BUTTON OK");

//				break;
//			case "boardSize_content_close_Button" : //TIME - CLOSE
//				Debug.Log(e.id + " - TIME - BUTTON CLOSE");

//				break;
//			default: break;
//		}
//	}

//	void OnButton_Boards(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "top_back_Button" : //BOARDS - BACK
//				Debug.Log(e.id + " - BOARDS - BUTTON BACK");

//				break;
//			default: break;
//		}
//	}

//	void OnButton_GameRegular(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "top_back_Button" : //GAMEREGULAR - BACK
//				Debug.Log(e.id + " - GAMEREGULAR - BUTTON BACK");

//				break;
//			case "running_bottom_previous_Button" : //GAMEREGULAR - PREVIOUS
//				Debug.Log(e.id + " - GAMEREGULAR - BUTTON PREVIOUS");

//				break;
//			case "running_bottom_restart_Button" : //GAMEREGULAR - RESTART
//				Debug.Log(e.id + " - GAMEREGULAR - BUTTON RESTART");

//				break;
//			case "running_bottom_next_Button" : //GAMEREGULAR - NEXT
//				Debug.Log(e.id + " - GAMEREGULAR - BUTTON NEXT");

//				break;
//			case "finish_again_Button" : //GAMEREGULAR - AGAIN
//				Debug.Log(e.id + " - GAMEREGULAR - BUTTON AGAIN");

//				break;
//			case "finish_next_Button" : //GAMEREGULAR - NEXT
//				Debug.Log(e.id + " - GAMEREGULAR - BUTTON NEXT");

//				break;
//			default: break;
//		}
//	}

//	void OnButton_GameTimed(object sender, ButtonPressedEventArgs e){
//		switch(e.id){
//			case "top_back_Button" : //GAMETIMED - BACK
//				Debug.Log(e.id + " - GAMETIMED - BUTTON BACK");

//				break;
//			case "running_bottom_reset_Button" : //GAMETIMED - RESET
//				Debug.Log(e.id + " - GAMETIMED - BUTTON RESET");

//				break;
//			case "running_bottom_pause_Button" : //GAMETIMED - PAUSE
//				Debug.Log(e.id + " - GAMETIMED - BUTTON PAUSE");

//				break;
//			case "running_bottom_next_Button" : //GAMETIMED - NEXT
//				Debug.Log(e.id + " - GAMETIMED - BUTTON NEXT");

//				break;
//			case "finish_again_Button" : //GAMETIMED - AGAIN
//				Debug.Log(e.id + " - GAMETIMED - BUTTON AGAIN");

//				break;
//			case "finish_back_Button" : //GAMETIMED - BACK
//				Debug.Log(e.id + " - GAMETIMED - BUTTON BACK");

//				break;
//			case "pause_sideClose_Button" : //GAMETIMED - SIDECLOSE
//				Debug.Log(e.id + " - GAMETIMED - BUTTON SIDECLOSE");

//				break;
//			case "pause_content_close_Button" : //GAMETIMED - CLOSE
//				Debug.Log(e.id + " - GAMETIMED - BUTTON CLOSE");

//				break;
//			case "pause_content_continue_Button" : //GAMETIMED - CONTINUE
//				Debug.Log(e.id + " - GAMETIMED - BUTTON CONTINUE");

//				break;
//			case "pause_content_exit_Button" : //GAMETIMED - EXIT
//				Debug.Log(e.id + " - GAMETIMED - BUTTON EXIT");

//				break;
//			default: break;
//		}
//	}

//	void AssignEvents(){
//		GUI_Controller.GUI_Main_ButtonPressed += OnButton_Main;
//		GUI_Controller.GUI_Settings_ButtonPressed += OnButton_Settings;
//		GUI_Controller.GUI_Levels_ButtonPressed += OnButton_Levels;
//		GUI_Controller.GUI_Time_ButtonPressed += OnButton_Time;
//		GUI_Controller.GUI_Boards_ButtonPressed += OnButton_Boards;
//		GUI_Controller.GUI_GameRegular_ButtonPressed += OnButton_GameRegular;
//		GUI_Controller.GUI_GameTimed_ButtonPressed += OnButton_GameTimed;

//		GUI_Controller.GUI_Settings_TogglePressed += OnToggle_Settings;
//	}
	#endregion
}
