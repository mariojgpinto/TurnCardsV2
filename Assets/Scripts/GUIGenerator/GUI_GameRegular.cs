using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_GameRegular : MonoBehaviour {
	// GAMEREGULAR ---------------------------------------------
	public static GameObject				gameRegular_Panel_gameObject;
	public static UnityEngine.UI.Image		gameRegular_Panel;


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

	public static GameObject				running_info_level_Text_gameObject;
	public static UnityEngine.UI.Text		running_info_level_Text;

	public static GameObject				running_bottom_Panel_gameObject;
	public static UnityEngine.UI.Image		running_bottom_Panel;

	public static GameObject				running_bottom_previous_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_previous_Button;

	public static GameObject				running_bottom_restart_Button_gameObject;
	public static UnityEngine.UI.Button		running_bottom_restart_Button;

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



	public static void UpdateValues(GameObject panel){
		gameRegular_Panel_gameObject = panel.gameObject;
		gameRegular_Panel = gameRegular_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_Panel_gameObject = gameRegular_Panel_gameObject.transform.Find("Panel_Top").gameObject;
		top_Panel = top_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_back_Button_gameObject = top_Panel_gameObject.transform.Find("Button_Back").gameObject;
		top_back_Button = top_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		top_title_Text_gameObject = top_Panel_gameObject.transform.Find("Text_Title").gameObject;
		top_title_Text = top_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_Panel_gameObject = gameRegular_Panel_gameObject.transform.Find("Panel_Running").gameObject;
		running_Panel = running_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_Panel_gameObject = running_Panel_gameObject.transform.Find("Panel_Info").gameObject;
		running_info_Panel = running_info_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_currentScore_Text_gameObject = running_info_Panel_gameObject.transform.Find("Text_CurrentScore").gameObject;
		running_info_currentScore_Text = running_info_currentScore_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_info_minimum_Panel_gameObject = running_info_Panel_gameObject.transform.Find("Panel_Minimum").gameObject;
		running_info_minimum_Panel = running_info_minimum_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_info_minimum_label_Text_gameObject = running_info_minimum_Panel_gameObject.transform.Find("Text_Label").gameObject;
		running_info_minimum_label_Text = running_info_minimum_label_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_info_level_Text_gameObject = running_info_Panel_gameObject.transform.Find("Text_Level").gameObject;
		running_info_level_Text = running_info_level_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		running_bottom_Panel_gameObject = running_Panel_gameObject.transform.Find("Panel_Bottom").gameObject;
		running_bottom_Panel = running_bottom_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		running_bottom_previous_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Previous").gameObject;
		running_bottom_previous_Button = running_bottom_previous_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		running_bottom_restart_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Restart").gameObject;
		running_bottom_restart_Button = running_bottom_restart_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		running_bottom_next_Button_gameObject = running_bottom_Panel_gameObject.transform.Find("Button_Next").gameObject;
		running_bottom_next_Button = running_bottom_next_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		board_Panel_gameObject = gameRegular_Panel_gameObject.transform.Find("Panel_Board").gameObject;
		board_Panel = board_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		finish_Panel_gameObject = gameRegular_Panel_gameObject.transform.Find("Panel_Finish").gameObject;
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
	}
}
