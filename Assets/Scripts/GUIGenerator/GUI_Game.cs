using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_Game : MonoBehaviour {
	// GAME ---------------------------------------------
	public static GameObject				game_Panel_gameObject;
	public static UnityEngine.UI.Image		game_Panel;


	// TOP ---------------------------------------------
	public static GameObject				top_Panel_gameObject;
	public static UnityEngine.UI.Image		top_Panel;

	public static GameObject				top_back_Button_gameObject;
	public static UnityEngine.UI.Button		top_back_Button;

	public static GameObject				top_title_Text_gameObject;
	public static UnityEngine.UI.Text		top_title_Text;

	// RUNNING ---------------------------------------------
	public static GameObject				running_Panel_gameObject;
	public static UnityEngine.UI.Image		running_Panel;

	public static GameObject				running_info_Panel_gameObject;
	public static UnityEngine.UI.Image		running_info_Panel;

	public static GameObject				running_info_currentScore_Text_gameObject;
	public static UnityEngine.UI.Text		running_info_currentScore_Text;

	public static GameObject				running_info_minimum_Panel_gameObject;
	public static UnityEngine.UI.Image		running_info_minimum_Panel;

	public static GameObject				running_info_minimum_label_Text_gameObject;
	public static UnityEngine.UI.Text		running_info_minimum_label_Text;

	public static GameObject				running_bottom_Panel_gameObject;
	public static UnityEngine.UI.Image		running_bottom_Panel;

	public static GameObject				running_bottom_settings_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_settings_Button;

	public static GameObject				running_bottom_restart_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_restart_Button;

	public static GameObject				running_bottom_next_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_next_Button;

	// FINISH ---------------------------------------------
	public static GameObject				finish_Panel_gameObject;
	public static UnityEngine.UI.Image		finish_Panel;

	public static GameObject				finish_score_Panel_gameObject;
	public static UnityEngine.UI.Image		finish_score_Panel;

	public static GameObject				finish_score_currentScore_Text_gameObject;
	public static UnityEngine.UI.Text		finish_score_currentScore_Text;

	public static GameObject				finish_score_square_Image_gameObject;
	public static UnityEngine.UI.Image		finish_score_square_Image;

	public static GameObject				finish_score_diamond_Image_gameObject;
	public static UnityEngine.UI.Image		finish_score_diamond_Image;

	public static GameObject				finish_message_Text_gameObject;
	public static UnityEngine.UI.Text		finish_message_Text;

	public static GameObject				finish_again_Button_gameObject;
	public static UnityEngine.UI.Button		finish_again_Button;

	public static GameObject				finish_again_label_Text_gameObject;
	public static UnityEngine.UI.Text		finish_again_label_Text;

	public static GameObject				finish_next_Button_gameObject;
	public static UnityEngine.UI.Button		finish_next_Button;

	public static GameObject				finish_next_label_Text_gameObject;
	public static UnityEngine.UI.Text		finish_next_label_Text;

	// FINISHTIMED ---------------------------------------------
	public static GameObject				finishTimed_Panel_gameObject;
	public static UnityEngine.UI.Image		finishTimed_Panel;

	public static GameObject				finishTimed_score_Panel_gameObject;
	public static UnityEngine.UI.Image		finishTimed_score_Panel;

	public static GameObject				finishTimed_score_currentScore_Text_gameObject;
	public static UnityEngine.UI.Text		finishTimed_score_currentScore_Text;

	public static GameObject				finishTimed_score_square_Image_gameObject;
	public static UnityEngine.UI.Image		finishTimed_score_square_Image;

	public static GameObject				finishTimed_score_diamond_Image_gameObject;
	public static UnityEngine.UI.Image		finishTimed_score_diamond_Image;

	public static GameObject				finishTimed_finish_Panel_gameObject;
	public static UnityEngine.UI.Image		finishTimed_finish_Panel;

	public static GameObject				finishTimed_finish_time_Text_gameObject;
	public static UnityEngine.UI.Text		finishTimed_finish_time_Text;

	public static GameObject				finishTimed_newRecord_Panel_gameObject;
	public static UnityEngine.UI.Image		finishTimed_newRecord_Panel;

	public static GameObject				finishTimed_newRecord_time_Text_gameObject;
	public static UnityEngine.UI.Text		finishTimed_newRecord_time_Text;

	public static GameObject				finishTimed_newRecord_record_Text_gameObject;
	public static UnityEngine.UI.Text		finishTimed_newRecord_record_Text;

	public static GameObject				finishTimed_again_Button_gameObject;
	public static UnityEngine.UI.Button		finishTimed_again_Button;

	public static GameObject				finishTimed_again_label_Text_gameObject;
	public static UnityEngine.UI.Text		finishTimed_again_label_Text;

	public static GameObject				finishTimed_next_Button_gameObject;
	public static UnityEngine.UI.Button		finishTimed_next_Button;

	public static GameObject				finishTimed_next_label_Text_gameObject;
	public static UnityEngine.UI.Text		finishTimed_next_label_Text;

	// PAUSE ---------------------------------------------
	public static GameObject				pause_Panel_gameObject;
	public static UnityEngine.UI.Image		pause_Panel;

	public static GameObject				pause_sideClose_Button_gameObject;
	public static UnityEngine.UI.Button		pause_sideClose_Button;

	public static GameObject				pause_content_Panel_gameObject;
	public static UnityEngine.UI.Image		pause_content_Panel;

	public static GameObject				pause_content_background_Image_gameObject;
	public static UnityEngine.UI.Image		pause_content_background_Image;

	public static GameObject				pause_content_close_Button_gameObject;
	public static UnityEngine.UI.Button		pause_content_close_Button;

	public static GameObject				pause_content_title_Text_gameObject;
	public static UnityEngine.UI.Text		pause_content_title_Text;

	public static GameObject				pause_content_description_Text_gameObject;
	public static UnityEngine.UI.Text		pause_content_description_Text;

	public static GameObject				pause_content_settings_Button_gameObject;
	public static UnityEngine.UI.Button		pause_content_settings_Button;

	public static GameObject				pause_content_settings_title_Text_gameObject;
	public static UnityEngine.UI.Text		pause_content_settings_title_Text;

	public static GameObject				pause_content_exit_Button_gameObject;
	public static UnityEngine.UI.Button		pause_content_exit_Button;

	public static GameObject				pause_content_exit_title_Text_gameObject;
	public static UnityEngine.UI.Text		pause_content_exit_title_Text;



	public static void UpdateValues(GameObject panel){
		game_Panel_gameObject = panel.gameObject;
		game_Panel = game_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_Panel_gameObject = game_Panel_gameObject.transform.Find("Panel_Top").gameObject;
		top_Panel = top_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_back_Button_gameObject = top_Panel_gameObject.transform.Find("Button_Back").gameObject;
		top_back_Button = top_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		top_title_Text_gameObject = top_Panel_gameObject.transform.Find("Text_Title").gameObject;
		top_title_Text = top_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_Panel_gameObject = game_Panel_gameObject.transform.Find("Panel_Running").gameObject;
		running_Panel = running_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_Panel_gameObject = running_Panel_gameObject.transform.Find("Panel_Info").gameObject;
		running_info_Panel = running_info_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_currentScore_Text_gameObject = running_info_Panel_gameObject.transform.Find("Text_CurrentScore").gameObject;
		running_info_currentScore_Text = running_info_currentScore_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_info_minimum_Panel_gameObject = running_info_Panel_gameObject.transform.Find("Panel_Minimum").gameObject;
		running_info_minimum_Panel = running_info_minimum_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_minimum_label_Text_gameObject = running_info_minimum_Panel_gameObject.transform.Find("Text_Label").gameObject;
		running_info_minimum_label_Text = running_info_minimum_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_bottom_Panel_gameObject = running_Panel_gameObject.transform.Find("Panel_Bottom").gameObject;
		running_bottom_Panel = running_bottom_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_bottom_settings_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Settings").gameObject;
		running_bottom_settings_Button = running_bottom_settings_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		running_bottom_restart_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Restart").gameObject;
		running_bottom_restart_Button = running_bottom_restart_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		running_bottom_next_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Next").gameObject;
		running_bottom_next_Button = running_bottom_next_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		finish_Panel_gameObject = game_Panel_gameObject.transform.Find("Panel_Finish").gameObject;
		finish_Panel = finish_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_score_Panel_gameObject = finish_Panel_gameObject.transform.Find("Panel_Score").gameObject;
		finish_score_Panel = finish_score_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_score_currentScore_Text_gameObject = finish_score_Panel_gameObject.transform.Find("Text_CurrentScore").gameObject;
		finish_score_currentScore_Text = finish_score_currentScore_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_score_square_Image_gameObject = finish_score_Panel_gameObject.transform.Find("Image_Square").gameObject;
		finish_score_square_Image = finish_score_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_score_diamond_Image_gameObject = finish_score_Panel_gameObject.transform.Find("Image_Diamond").gameObject;
		finish_score_diamond_Image = finish_score_diamond_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_message_Text_gameObject = finish_Panel_gameObject.transform.Find("Text_Message").gameObject;
		finish_message_Text = finish_message_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_again_Button_gameObject = finish_Panel_gameObject.transform.Find("Button_Again").gameObject;
		finish_again_Button = finish_again_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		finish_again_label_Text_gameObject = finish_again_Button_gameObject.transform.Find("Text_Label").gameObject;
		finish_again_label_Text = finish_again_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_next_Button_gameObject = finish_Panel_gameObject.transform.Find("Button_Next").gameObject;
		finish_next_Button = finish_next_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		finish_next_label_Text_gameObject = finish_next_Button_gameObject.transform.Find("Text_Label").gameObject;
		finish_next_label_Text = finish_next_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finishTimed_Panel_gameObject = game_Panel_gameObject.transform.Find("Panel_FinishTimed").gameObject;
		finishTimed_Panel = finishTimed_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finishTimed_score_Panel_gameObject = finishTimed_Panel_gameObject.transform.Find("Panel_Score").gameObject;
		finishTimed_score_Panel = finishTimed_score_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finishTimed_score_currentScore_Text_gameObject = finishTimed_score_Panel_gameObject.transform.Find("Text_CurrentScore").gameObject;
		finishTimed_score_currentScore_Text = finishTimed_score_currentScore_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finishTimed_score_square_Image_gameObject = finishTimed_score_Panel_gameObject.transform.Find("Image_Square").gameObject;
		finishTimed_score_square_Image = finishTimed_score_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		finishTimed_score_diamond_Image_gameObject = finishTimed_score_Panel_gameObject.transform.Find("Image_Diamond").gameObject;
		finishTimed_score_diamond_Image = finishTimed_score_diamond_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		finishTimed_finish_Panel_gameObject = finishTimed_Panel_gameObject.transform.Find("Panel_Finish").gameObject;
		finishTimed_finish_Panel = finishTimed_finish_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finishTimed_finish_time_Text_gameObject = finishTimed_finish_Panel_gameObject.transform.Find("Text_Time").gameObject;
		finishTimed_finish_time_Text = finishTimed_finish_time_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finishTimed_newRecord_Panel_gameObject = finishTimed_Panel_gameObject.transform.Find("Panel_NewRecord").gameObject;
		finishTimed_newRecord_Panel = finishTimed_newRecord_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finishTimed_newRecord_time_Text_gameObject = finishTimed_newRecord_Panel_gameObject.transform.Find("Text_Time").gameObject;
		finishTimed_newRecord_time_Text = finishTimed_newRecord_time_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finishTimed_newRecord_record_Text_gameObject = finishTimed_newRecord_Panel_gameObject.transform.Find("Text_Record").gameObject;
		finishTimed_newRecord_record_Text = finishTimed_newRecord_record_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finishTimed_again_Button_gameObject = finishTimed_Panel_gameObject.transform.Find("Button_Again").gameObject;
		finishTimed_again_Button = finishTimed_again_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		finishTimed_again_label_Text_gameObject = finishTimed_again_Button_gameObject.transform.Find("Text_Label").gameObject;
		finishTimed_again_label_Text = finishTimed_again_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finishTimed_next_Button_gameObject = finishTimed_Panel_gameObject.transform.Find("Button_Next").gameObject;
		finishTimed_next_Button = finishTimed_next_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		finishTimed_next_label_Text_gameObject = finishTimed_next_Button_gameObject.transform.Find("Text_Label").gameObject;
		finishTimed_next_label_Text = finishTimed_next_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		pause_Panel_gameObject = game_Panel_gameObject.transform.Find("Panel_Pause").gameObject;
		pause_Panel = pause_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		pause_sideClose_Button_gameObject = pause_Panel_gameObject.transform.Find("Button_SideClose").gameObject;
		pause_sideClose_Button = pause_sideClose_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		pause_content_Panel_gameObject = pause_Panel_gameObject.transform.Find("Panel_Content").gameObject;
		pause_content_Panel = pause_content_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		pause_content_background_Image_gameObject = pause_content_Panel_gameObject.transform.Find("Image_Background").gameObject;
		pause_content_background_Image = pause_content_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		pause_content_close_Button_gameObject = pause_content_Panel_gameObject.transform.Find("Button_Close").gameObject;
		pause_content_close_Button = pause_content_close_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		pause_content_title_Text_gameObject = pause_content_Panel_gameObject.transform.Find("Text_Title").gameObject;
		pause_content_title_Text = pause_content_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		pause_content_description_Text_gameObject = pause_content_Panel_gameObject.transform.Find("Text_Description").gameObject;
		pause_content_description_Text = pause_content_description_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		pause_content_settings_Button_gameObject = pause_content_Panel_gameObject.transform.Find("Button_Settings").gameObject;
		pause_content_settings_Button = pause_content_settings_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		pause_content_settings_title_Text_gameObject = pause_content_settings_Button_gameObject.transform.Find("Text_Title").gameObject;
		pause_content_settings_title_Text = pause_content_settings_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		pause_content_exit_Button_gameObject = pause_content_Panel_gameObject.transform.Find("Button_Exit").gameObject;
		pause_content_exit_Button = pause_content_exit_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		pause_content_exit_title_Text_gameObject = pause_content_exit_Button_gameObject.transform.Find("Text_Title").gameObject;
		pause_content_exit_title_Text = pause_content_exit_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();
	}
}
