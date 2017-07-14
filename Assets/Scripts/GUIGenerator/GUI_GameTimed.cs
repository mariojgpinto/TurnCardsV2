using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_GameTimed : MonoBehaviour {
	// GAMETIMED ---------------------------------------------
	public static GameObject				gameTimed_Panel_gameObject;
	public static UnityEngine.UI.Image		gameTimed_Panel;


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

	public static GameObject				running_info_currentTime_Text_gameObject;
	public static UnityEngine.UI.Text		running_info_currentTime_Text;

	public static GameObject				running_info_text_Panel_gameObject;
	public static UnityEngine.UI.Image		running_info_text_Panel;

	public static GameObject				running_info_text_solved_Text_gameObject;
	public static UnityEngine.UI.Text		running_info_text_solved_Text;

	public static GameObject				running_info_text_best_Text_gameObject;
	public static UnityEngine.UI.Text		running_info_text_best_Text;

	public static GameObject				running_bottom_Panel_gameObject;
	public static UnityEngine.UI.Image		running_bottom_Panel;

	public static GameObject				running_bottom_reset_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_reset_Button;

	public static GameObject				running_bottom_pause_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_pause_Button;

	public static GameObject				running_bottom_next_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_next_Button;

	// BOARD ---------------------------------------------
	public static GameObject				board_Panel_gameObject;
	public static UnityEngine.UI.Image		board_Panel;

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

	public static GameObject				finish_message_Panel_gameObject;
	public static UnityEngine.UI.Image		finish_message_Panel;

	public static GameObject				finish_message_label_Text_gameObject;
	public static UnityEngine.UI.Text		finish_message_label_Text;

	public static GameObject				finish_newRecord_Panel_gameObject;
	public static UnityEngine.UI.Image		finish_newRecord_Panel;

	public static GameObject				finish_newRecord_time_Text_gameObject;
	public static UnityEngine.UI.Text		finish_newRecord_time_Text;

	public static GameObject				finish_newRecord_record_Text_gameObject;
	public static UnityEngine.UI.Text		finish_newRecord_record_Text;

	public static GameObject				finish_again_Button_gameObject;
	public static UnityEngine.UI.Button		finish_again_Button;

	public static GameObject				finish_again_label_Text_gameObject;
	public static UnityEngine.UI.Text		finish_again_label_Text;

	public static GameObject				finish_back_Button_gameObject;
	public static UnityEngine.UI.Button		finish_back_Button;

	public static GameObject				finish_back_label_Text_gameObject;
	public static UnityEngine.UI.Text		finish_back_label_Text;

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

	public static GameObject				pause_content_continue_Button_gameObject;
	public static UnityEngine.UI.Button		pause_content_continue_Button;

	public static GameObject				pause_content_continue_title_Text_gameObject;
	public static UnityEngine.UI.Text		pause_content_continue_title_Text;

	public static GameObject				pause_content_exit_Button_gameObject;
	public static UnityEngine.UI.Button		pause_content_exit_Button;

	public static GameObject				pause_content_exit_title_Text_gameObject;
	public static UnityEngine.UI.Text		pause_content_exit_title_Text;



	public static void UpdateValues(GameObject panel){
		gameTimed_Panel_gameObject = panel.gameObject;
		gameTimed_Panel = gameTimed_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_Panel_gameObject = gameTimed_Panel_gameObject.transform.Find("Panel_Top").gameObject;
		top_Panel = top_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_back_Button_gameObject = top_Panel_gameObject.transform.Find("Button_Back").gameObject;
		top_back_Button = top_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		top_title_Text_gameObject = top_Panel_gameObject.transform.Find("Text_Title").gameObject;
		top_title_Text = top_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_Panel_gameObject = gameTimed_Panel_gameObject.transform.Find("Panel_Running").gameObject;
		running_Panel = running_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_Panel_gameObject = running_Panel_gameObject.transform.Find("Panel_Info").gameObject;
		running_info_Panel = running_info_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_currentTime_Text_gameObject = running_info_Panel_gameObject.transform.Find("Text_CurrentTime").gameObject;
		running_info_currentTime_Text = running_info_currentTime_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_info_text_Panel_gameObject = running_info_Panel_gameObject.transform.Find("Panel_Text").gameObject;
		running_info_text_Panel = running_info_text_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_text_solved_Text_gameObject = running_info_text_Panel_gameObject.transform.Find("Text_Solved").gameObject;
		running_info_text_solved_Text = running_info_text_solved_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_info_text_best_Text_gameObject = running_info_text_Panel_gameObject.transform.Find("Text_Best").gameObject;
		running_info_text_best_Text = running_info_text_best_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_bottom_Panel_gameObject = running_Panel_gameObject.transform.Find("Panel_Bottom").gameObject;
		running_bottom_Panel = running_bottom_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_bottom_reset_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Reset").gameObject;
		running_bottom_reset_Button = running_bottom_reset_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		running_bottom_pause_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Pause").gameObject;
		running_bottom_pause_Button = running_bottom_pause_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		running_bottom_next_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Next").gameObject;
		running_bottom_next_Button = running_bottom_next_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		board_Panel_gameObject = gameTimed_Panel_gameObject.transform.Find("Panel_Board").gameObject;
		board_Panel = board_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_Panel_gameObject = gameTimed_Panel_gameObject.transform.Find("Panel_Finish").gameObject;
		finish_Panel = finish_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_score_Panel_gameObject = finish_Panel_gameObject.transform.Find("Panel_Score").gameObject;
		finish_score_Panel = finish_score_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_score_currentScore_Text_gameObject = finish_score_Panel_gameObject.transform.Find("Text_CurrentScore").gameObject;
		finish_score_currentScore_Text = finish_score_currentScore_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_score_square_Image_gameObject = finish_score_Panel_gameObject.transform.Find("Image_Square").gameObject;
		finish_score_square_Image = finish_score_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_score_diamond_Image_gameObject = finish_score_Panel_gameObject.transform.Find("Image_Diamond").gameObject;
		finish_score_diamond_Image = finish_score_diamond_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_message_Panel_gameObject = finish_Panel_gameObject.transform.Find("Panel_Message").gameObject;
		finish_message_Panel = finish_message_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_message_label_Text_gameObject = finish_message_Panel_gameObject.transform.Find("Text_Label").gameObject;
		finish_message_label_Text = finish_message_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_newRecord_Panel_gameObject = finish_Panel_gameObject.transform.Find("Panel_NewRecord").gameObject;
		finish_newRecord_Panel = finish_newRecord_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_newRecord_time_Text_gameObject = finish_newRecord_Panel_gameObject.transform.Find("Text_Time").gameObject;
		finish_newRecord_time_Text = finish_newRecord_time_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_newRecord_record_Text_gameObject = finish_newRecord_Panel_gameObject.transform.Find("Text_Record").gameObject;
		finish_newRecord_record_Text = finish_newRecord_record_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_again_Button_gameObject = finish_Panel_gameObject.transform.Find("Button_Again").gameObject;
		finish_again_Button = finish_again_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		finish_again_label_Text_gameObject = finish_again_Button_gameObject.transform.Find("Text_Label").gameObject;
		finish_again_label_Text = finish_again_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		finish_back_Button_gameObject = finish_Panel_gameObject.transform.Find("Button_Back").gameObject;
		finish_back_Button = finish_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		finish_back_label_Text_gameObject = finish_back_Button_gameObject.transform.Find("Text_Label").gameObject;
		finish_back_label_Text = finish_back_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		pause_Panel_gameObject = gameTimed_Panel_gameObject.transform.Find("Panel_Pause").gameObject;
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

		pause_content_continue_Button_gameObject = pause_content_Panel_gameObject.transform.Find("Button_Continue").gameObject;
		pause_content_continue_Button = pause_content_continue_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		pause_content_continue_title_Text_gameObject = pause_content_continue_Button_gameObject.transform.Find("Text_Title").gameObject;
		pause_content_continue_title_Text = pause_content_continue_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		pause_content_exit_Button_gameObject = pause_content_Panel_gameObject.transform.Find("Button_Exit").gameObject;
		pause_content_exit_Button = pause_content_exit_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		pause_content_exit_title_Text_gameObject = pause_content_exit_Button_gameObject.transform.Find("Text_Title").gameObject;
		pause_content_exit_title_Text = pause_content_exit_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();
	}
}
