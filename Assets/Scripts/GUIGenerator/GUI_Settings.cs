using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_Settings : MonoBehaviour {
	// SETTINGS ---------------------------------------------
	public static GameObject				settings_Panel_gameObject;
	public static UnityEngine.UI.Image		settings_Panel;


	// TOP ---------------------------------------------
	public static GameObject				top_Panel_gameObject;
	public static UnityEngine.UI.Image		top_Panel;

	public static GameObject				top_back_Button_gameObject;
	public static UnityEngine.UI.Button		top_back_Button;

	public static GameObject				top_title_Text_gameObject;
	public static UnityEngine.UI.Text		top_title_Text;

	// BUTTONS ---------------------------------------------
	public static GameObject				buttons_Panel_gameObject;
	public static UnityEngine.UI.Image		buttons_Panel;

	public static GameObject				buttons_themes_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_themes_Button;

	public static GameObject				buttons_themes_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_themes_title_Text;

	public static GameObject				buttons_language_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_language_Button;

	public static GameObject				buttons_language_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_language_title_Text;

	public static GameObject				buttons_reset_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_reset_Button;

	public static GameObject				buttons_reset_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_reset_title_Text;

	public static GameObject				buttons_remove_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_remove_Button;

	public static GameObject				buttons_remove_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_remove_title_Text;

	public static GameObject				buttons_about_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_about_Button;

	public static GameObject				buttons_about_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_about_title_Text;

	// RESET ---------------------------------------------
	public static GameObject				reset_Panel_gameObject;
	public static UnityEngine.UI.Image		reset_Panel;

	public static GameObject				reset_sideClose_Button_gameObject;
	public static UnityEngine.UI.Button		reset_sideClose_Button;

	public static GameObject				reset_content_Panel_gameObject;
	public static UnityEngine.UI.Image		reset_content_Panel;

	public static GameObject				reset_content_background_Image_gameObject;
	public static UnityEngine.UI.Image		reset_content_background_Image;

	public static GameObject				reset_content_title_Text_gameObject;
	public static UnityEngine.UI.Text		reset_content_title_Text;

	public static GameObject				reset_content_description_Text_gameObject;
	public static UnityEngine.UI.Text		reset_content_description_Text;

	public static GameObject				reset_content_cancel_Button_gameObject;
	public static UnityEngine.UI.Button		reset_content_cancel_Button;

	public static GameObject				reset_content_cancel_title_Text_gameObject;
	public static UnityEngine.UI.Text		reset_content_cancel_title_Text;

	public static GameObject				reset_content_ok_Button_gameObject;
	public static UnityEngine.UI.Button		reset_content_ok_Button;

	public static GameObject				reset_content_ok_title_Text_gameObject;
	public static UnityEngine.UI.Text		reset_content_ok_title_Text;

	public static GameObject				reset_content_close_Button_gameObject;
	public static UnityEngine.UI.Button		reset_content_close_Button;

	// LANGUAGE ---------------------------------------------
	public static GameObject				language_Panel_gameObject;
	public static UnityEngine.UI.Image		language_Panel;

	public static GameObject				language_sideClose_Button_gameObject;
	public static UnityEngine.UI.Button		language_sideClose_Button;

	public static GameObject				language_content_Panel_gameObject;
	public static UnityEngine.UI.Image		language_content_Panel;

	public static GameObject				language_content_background_Image_gameObject;
	public static UnityEngine.UI.Image		language_content_background_Image;

	public static GameObject				language_content_title_Text_gameObject;
	public static UnityEngine.UI.Text		language_content_title_Text;

	public static GameObject				language_content_description_Text_gameObject;
	public static UnityEngine.UI.Text		language_content_description_Text;

	public static GameObject				language_content_cancel_Button_gameObject;
	public static UnityEngine.UI.Button		language_content_cancel_Button;

	public static GameObject				language_content_cancel_title_Text_gameObject;
	public static UnityEngine.UI.Text		language_content_cancel_title_Text;

	public static GameObject				language_content_ok_Button_gameObject;
	public static UnityEngine.UI.Button		language_content_ok_Button;

	public static GameObject				language_content_ok_title_Text_gameObject;
	public static UnityEngine.UI.Text		language_content_ok_title_Text;

	public static GameObject				language_content_close_Button_gameObject;
	public static UnityEngine.UI.Button		language_content_close_Button;

	// THEMES ---------------------------------------------
	public static GameObject				themes_Panel_gameObject;
	public static UnityEngine.UI.Image		themes_Panel;

	public static GameObject				themes_sideClose_Button_gameObject;
	public static UnityEngine.UI.Button		themes_sideClose_Button;

	public static GameObject				themes_content_Panel_gameObject;
	public static UnityEngine.UI.Image		themes_content_Panel;

	public static GameObject				themes_content_background_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_background_Image;

	public static GameObject				themes_content_title_Text_gameObject;
	public static UnityEngine.UI.Text		themes_content_title_Text;

	public static GameObject				themes_content_description_Text_gameObject;
	public static UnityEngine.UI.Text		themes_content_description_Text;

	public static GameObject				themes_content_listColors_Panel_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_Panel;

	public static GameObject				themes_content_listColors_white_Toggle_gameObject;
	public static UnityEngine.UI.Toggle		themes_content_listColors_white_Toggle;

	public static GameObject				themes_content_listColors_white_background_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_white_background_Image;

	public static GameObject				themes_content_listColors_white_background_checkmark_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_white_background_checkmark_Image;

	public static GameObject				themes_content_listColors_red_Toggle_gameObject;
	public static UnityEngine.UI.Toggle		themes_content_listColors_red_Toggle;

	public static GameObject				themes_content_listColors_red_background_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_red_background_Image;

	public static GameObject				themes_content_listColors_red_background_checkmark_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_red_background_checkmark_Image;

	public static GameObject				themes_content_listColors_blue_Toggle_gameObject;
	public static UnityEngine.UI.Toggle		themes_content_listColors_blue_Toggle;

	public static GameObject				themes_content_listColors_blue_background_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_blue_background_Image;

	public static GameObject				themes_content_listColors_blue_background_checkmark_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_blue_background_checkmark_Image;

	public static GameObject				themes_content_listColors_green_Toggle_gameObject;
	public static UnityEngine.UI.Toggle		themes_content_listColors_green_Toggle;

	public static GameObject				themes_content_listColors_green_background_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_green_background_Image;

	public static GameObject				themes_content_listColors_green_background_checkmark_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_green_background_checkmark_Image;

	public static GameObject				themes_content_listColors_yellow_Toggle_gameObject;
	public static UnityEngine.UI.Toggle		themes_content_listColors_yellow_Toggle;

	public static GameObject				themes_content_listColors_yellow_background_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_yellow_background_Image;

	public static GameObject				themes_content_listColors_yellow_background_checkmark_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_yellow_background_checkmark_Image;

	public static GameObject				themes_content_listColors_pink_Toggle_gameObject;
	public static UnityEngine.UI.Toggle		themes_content_listColors_pink_Toggle;

	public static GameObject				themes_content_listColors_pink_background_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_pink_background_Image;

	public static GameObject				themes_content_listColors_pink_background_checkmark_Image_gameObject;
	public static UnityEngine.UI.Image		themes_content_listColors_pink_background_checkmark_Image;

	public static GameObject				themes_content_cancel_Button_gameObject;
	public static UnityEngine.UI.Button		themes_content_cancel_Button;

	public static GameObject				themes_content_cancel_title_Text_gameObject;
	public static UnityEngine.UI.Text		themes_content_cancel_title_Text;

	public static GameObject				themes_content_ok_Button_gameObject;
	public static UnityEngine.UI.Button		themes_content_ok_Button;

	public static GameObject				themes_content_ok_title_Text_gameObject;
	public static UnityEngine.UI.Text		themes_content_ok_title_Text;

	public static GameObject				themes_content_close_Button_gameObject;
	public static UnityEngine.UI.Button		themes_content_close_Button;

	// ABOUT ---------------------------------------------
	public static GameObject				about_Panel_gameObject;
	public static UnityEngine.UI.Image		about_Panel;

	public static GameObject				about_sideClose_Button_gameObject;
	public static UnityEngine.UI.Button		about_sideClose_Button;

	public static GameObject				about_content_Panel_gameObject;
	public static UnityEngine.UI.Image		about_content_Panel;

	public static GameObject				about_content_background_Image_gameObject;
	public static UnityEngine.UI.Image		about_content_background_Image;

	public static GameObject				about_content_title_Text_gameObject;
	public static UnityEngine.UI.Text		about_content_title_Text;

	public static GameObject				about_content_description_Text_gameObject;
	public static UnityEngine.UI.Text		about_content_description_Text;

	public static GameObject				about_content_cancel_Button_gameObject;
	public static UnityEngine.UI.Button		about_content_cancel_Button;

	public static GameObject				about_content_cancel_title_Text_gameObject;
	public static UnityEngine.UI.Text		about_content_cancel_title_Text;

	public static GameObject				about_content_ok_Button_gameObject;
	public static UnityEngine.UI.Button		about_content_ok_Button;

	public static GameObject				about_content_ok_title_Text_gameObject;
	public static UnityEngine.UI.Text		about_content_ok_title_Text;

	public static GameObject				about_content_close_Button_gameObject;
	public static UnityEngine.UI.Button		about_content_close_Button;



	public static void UpdateValues(GameObject panel){
		settings_Panel_gameObject = panel.gameObject;
		settings_Panel = settings_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_Panel_gameObject = settings_Panel_gameObject.transform.Find("Panel_Top").gameObject;
		top_Panel = top_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_back_Button_gameObject = top_Panel_gameObject.transform.Find("Button_Back").gameObject;
		top_back_Button = top_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		top_title_Text_gameObject = top_Panel_gameObject.transform.Find("Text_Title").gameObject;
		top_title_Text = top_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_Panel_gameObject = settings_Panel_gameObject.transform.Find("Panel_Buttons").gameObject;
		buttons_Panel = buttons_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_themes_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_Themes").gameObject;
		buttons_themes_Button = buttons_themes_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_themes_title_Text_gameObject = buttons_themes_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_themes_title_Text = buttons_themes_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_language_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_Language").gameObject;
		buttons_language_Button = buttons_language_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_language_title_Text_gameObject = buttons_language_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_language_title_Text = buttons_language_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_reset_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_Reset").gameObject;
		buttons_reset_Button = buttons_reset_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_reset_title_Text_gameObject = buttons_reset_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_reset_title_Text = buttons_reset_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_remove_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_Remove").gameObject;
		buttons_remove_Button = buttons_remove_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_remove_title_Text_gameObject = buttons_remove_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_remove_title_Text = buttons_remove_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_about_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_About").gameObject;
		buttons_about_Button = buttons_about_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_about_title_Text_gameObject = buttons_about_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_about_title_Text = buttons_about_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		reset_Panel_gameObject = settings_Panel_gameObject.transform.Find("Panel_Reset").gameObject;
		reset_Panel = reset_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		reset_sideClose_Button_gameObject = reset_Panel_gameObject.transform.Find("Button_SideClose").gameObject;
		reset_sideClose_Button = reset_sideClose_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		reset_content_Panel_gameObject = reset_Panel_gameObject.transform.Find("Panel_Content").gameObject;
		reset_content_Panel = reset_content_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		reset_content_background_Image_gameObject = reset_content_Panel_gameObject.transform.Find("Image_Background").gameObject;
		reset_content_background_Image = reset_content_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		reset_content_title_Text_gameObject = reset_content_Panel_gameObject.transform.Find("Text_Title").gameObject;
		reset_content_title_Text = reset_content_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		reset_content_description_Text_gameObject = reset_content_Panel_gameObject.transform.Find("Text_Description").gameObject;
		reset_content_description_Text = reset_content_description_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		reset_content_cancel_Button_gameObject = reset_content_Panel_gameObject.transform.Find("Button_Cancel").gameObject;
		reset_content_cancel_Button = reset_content_cancel_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		reset_content_cancel_title_Text_gameObject = reset_content_cancel_Button_gameObject.transform.Find("Text_Title").gameObject;
		reset_content_cancel_title_Text = reset_content_cancel_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		reset_content_ok_Button_gameObject = reset_content_Panel_gameObject.transform.Find("Button_Ok").gameObject;
		reset_content_ok_Button = reset_content_ok_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		reset_content_ok_title_Text_gameObject = reset_content_ok_Button_gameObject.transform.Find("Text_Title").gameObject;
		reset_content_ok_title_Text = reset_content_ok_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		reset_content_close_Button_gameObject = reset_content_Panel_gameObject.transform.Find("Button_Close").gameObject;
		reset_content_close_Button = reset_content_close_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		language_Panel_gameObject = settings_Panel_gameObject.transform.Find("Panel_Language").gameObject;
		language_Panel = language_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		language_sideClose_Button_gameObject = language_Panel_gameObject.transform.Find("Button_SideClose").gameObject;
		language_sideClose_Button = language_sideClose_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		language_content_Panel_gameObject = language_Panel_gameObject.transform.Find("Panel_Content").gameObject;
		language_content_Panel = language_content_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		language_content_background_Image_gameObject = language_content_Panel_gameObject.transform.Find("Image_Background").gameObject;
		language_content_background_Image = language_content_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		language_content_title_Text_gameObject = language_content_Panel_gameObject.transform.Find("Text_Title").gameObject;
		language_content_title_Text = language_content_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		language_content_description_Text_gameObject = language_content_Panel_gameObject.transform.Find("Text_Description").gameObject;
		language_content_description_Text = language_content_description_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		language_content_cancel_Button_gameObject = language_content_Panel_gameObject.transform.Find("Button_Cancel").gameObject;
		language_content_cancel_Button = language_content_cancel_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		language_content_cancel_title_Text_gameObject = language_content_cancel_Button_gameObject.transform.Find("Text_Title").gameObject;
		language_content_cancel_title_Text = language_content_cancel_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		language_content_ok_Button_gameObject = language_content_Panel_gameObject.transform.Find("Button_Ok").gameObject;
		language_content_ok_Button = language_content_ok_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		language_content_ok_title_Text_gameObject = language_content_ok_Button_gameObject.transform.Find("Text_Title").gameObject;
		language_content_ok_title_Text = language_content_ok_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		language_content_close_Button_gameObject = language_content_Panel_gameObject.transform.Find("Button_Close").gameObject;
		language_content_close_Button = language_content_close_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		themes_Panel_gameObject = settings_Panel_gameObject.transform.Find("Panel_Themes").gameObject;
		themes_Panel = themes_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_sideClose_Button_gameObject = themes_Panel_gameObject.transform.Find("Button_SideClose").gameObject;
		themes_sideClose_Button = themes_sideClose_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		themes_content_Panel_gameObject = themes_Panel_gameObject.transform.Find("Panel_Content").gameObject;
		themes_content_Panel = themes_content_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_background_Image_gameObject = themes_content_Panel_gameObject.transform.Find("Image_Background").gameObject;
		themes_content_background_Image = themes_content_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_title_Text_gameObject = themes_content_Panel_gameObject.transform.Find("Text_Title").gameObject;
		themes_content_title_Text = themes_content_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		themes_content_description_Text_gameObject = themes_content_Panel_gameObject.transform.Find("Text_Description").gameObject;
		themes_content_description_Text = themes_content_description_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		themes_content_listColors_Panel_gameObject = themes_content_Panel_gameObject.transform.Find("Panel_ListColors").gameObject;
		themes_content_listColors_Panel = themes_content_listColors_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_white_Toggle_gameObject = themes_content_listColors_Panel_gameObject.transform.Find("Toggle_White").gameObject;
		themes_content_listColors_white_Toggle = themes_content_listColors_white_Toggle_gameObject.GetComponent<UnityEngine.UI.Toggle>();

		themes_content_listColors_white_background_Image_gameObject = themes_content_listColors_white_Toggle_gameObject.transform.Find("Image_Background").gameObject;
		themes_content_listColors_white_background_Image = themes_content_listColors_white_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_white_background_checkmark_Image_gameObject = themes_content_listColors_white_background_Image_gameObject.transform.Find("Image_Checkmark").gameObject;
		themes_content_listColors_white_background_checkmark_Image = themes_content_listColors_white_background_checkmark_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_red_Toggle_gameObject = themes_content_listColors_Panel_gameObject.transform.Find("Toggle_Red").gameObject;
		themes_content_listColors_red_Toggle = themes_content_listColors_red_Toggle_gameObject.GetComponent<UnityEngine.UI.Toggle>();

		themes_content_listColors_red_background_Image_gameObject = themes_content_listColors_red_Toggle_gameObject.transform.Find("Image_Background").gameObject;
		themes_content_listColors_red_background_Image = themes_content_listColors_red_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_red_background_checkmark_Image_gameObject = themes_content_listColors_red_background_Image_gameObject.transform.Find("Image_Checkmark").gameObject;
		themes_content_listColors_red_background_checkmark_Image = themes_content_listColors_red_background_checkmark_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_blue_Toggle_gameObject = themes_content_listColors_Panel_gameObject.transform.Find("Toggle_Blue").gameObject;
		themes_content_listColors_blue_Toggle = themes_content_listColors_blue_Toggle_gameObject.GetComponent<UnityEngine.UI.Toggle>();

		themes_content_listColors_blue_background_Image_gameObject = themes_content_listColors_blue_Toggle_gameObject.transform.Find("Image_Background").gameObject;
		themes_content_listColors_blue_background_Image = themes_content_listColors_blue_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_blue_background_checkmark_Image_gameObject = themes_content_listColors_blue_background_Image_gameObject.transform.Find("Image_Checkmark").gameObject;
		themes_content_listColors_blue_background_checkmark_Image = themes_content_listColors_blue_background_checkmark_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_green_Toggle_gameObject = themes_content_listColors_Panel_gameObject.transform.Find("Toggle_Green").gameObject;
		themes_content_listColors_green_Toggle = themes_content_listColors_green_Toggle_gameObject.GetComponent<UnityEngine.UI.Toggle>();

		themes_content_listColors_green_background_Image_gameObject = themes_content_listColors_green_Toggle_gameObject.transform.Find("Image_Background").gameObject;
		themes_content_listColors_green_background_Image = themes_content_listColors_green_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_green_background_checkmark_Image_gameObject = themes_content_listColors_green_background_Image_gameObject.transform.Find("Image_Checkmark").gameObject;
		themes_content_listColors_green_background_checkmark_Image = themes_content_listColors_green_background_checkmark_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_yellow_Toggle_gameObject = themes_content_listColors_Panel_gameObject.transform.Find("Toggle_Yellow").gameObject;
		themes_content_listColors_yellow_Toggle = themes_content_listColors_yellow_Toggle_gameObject.GetComponent<UnityEngine.UI.Toggle>();

		themes_content_listColors_yellow_background_Image_gameObject = themes_content_listColors_yellow_Toggle_gameObject.transform.Find("Image_Background").gameObject;
		themes_content_listColors_yellow_background_Image = themes_content_listColors_yellow_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_yellow_background_checkmark_Image_gameObject = themes_content_listColors_yellow_background_Image_gameObject.transform.Find("Image_Checkmark").gameObject;
		themes_content_listColors_yellow_background_checkmark_Image = themes_content_listColors_yellow_background_checkmark_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_pink_Toggle_gameObject = themes_content_listColors_Panel_gameObject.transform.Find("Toggle_Pink").gameObject;
		themes_content_listColors_pink_Toggle = themes_content_listColors_pink_Toggle_gameObject.GetComponent<UnityEngine.UI.Toggle>();

		themes_content_listColors_pink_background_Image_gameObject = themes_content_listColors_pink_Toggle_gameObject.transform.Find("Image_Background").gameObject;
		themes_content_listColors_pink_background_Image = themes_content_listColors_pink_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_listColors_pink_background_checkmark_Image_gameObject = themes_content_listColors_pink_background_Image_gameObject.transform.Find("Image_Checkmark").gameObject;
		themes_content_listColors_pink_background_checkmark_Image = themes_content_listColors_pink_background_checkmark_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		themes_content_cancel_Button_gameObject = themes_content_Panel_gameObject.transform.Find("Button_Cancel").gameObject;
		themes_content_cancel_Button = themes_content_cancel_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		themes_content_cancel_title_Text_gameObject = themes_content_cancel_Button_gameObject.transform.Find("Text_Title").gameObject;
		themes_content_cancel_title_Text = themes_content_cancel_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		themes_content_ok_Button_gameObject = themes_content_Panel_gameObject.transform.Find("Button_Ok").gameObject;
		themes_content_ok_Button = themes_content_ok_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		themes_content_ok_title_Text_gameObject = themes_content_ok_Button_gameObject.transform.Find("Text_Title").gameObject;
		themes_content_ok_title_Text = themes_content_ok_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		themes_content_close_Button_gameObject = themes_content_Panel_gameObject.transform.Find("Button_Close").gameObject;
		themes_content_close_Button = themes_content_close_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		about_Panel_gameObject = settings_Panel_gameObject.transform.Find("Panel_About").gameObject;
		about_Panel = about_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		about_sideClose_Button_gameObject = about_Panel_gameObject.transform.Find("Button_SideClose").gameObject;
		about_sideClose_Button = about_sideClose_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		about_content_Panel_gameObject = about_Panel_gameObject.transform.Find("Panel_Content").gameObject;
		about_content_Panel = about_content_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		about_content_background_Image_gameObject = about_content_Panel_gameObject.transform.Find("Image_Background").gameObject;
		about_content_background_Image = about_content_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		about_content_title_Text_gameObject = about_content_Panel_gameObject.transform.Find("Text_Title").gameObject;
		about_content_title_Text = about_content_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		about_content_description_Text_gameObject = about_content_Panel_gameObject.transform.Find("Text_Description").gameObject;
		about_content_description_Text = about_content_description_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		about_content_cancel_Button_gameObject = about_content_Panel_gameObject.transform.Find("Button_Cancel").gameObject;
		about_content_cancel_Button = about_content_cancel_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		about_content_cancel_title_Text_gameObject = about_content_cancel_Button_gameObject.transform.Find("Text_Title").gameObject;
		about_content_cancel_title_Text = about_content_cancel_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		about_content_ok_Button_gameObject = about_content_Panel_gameObject.transform.Find("Button_Ok").gameObject;
		about_content_ok_Button = about_content_ok_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		about_content_ok_title_Text_gameObject = about_content_ok_Button_gameObject.transform.Find("Text_Title").gameObject;
		about_content_ok_title_Text = about_content_ok_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		about_content_close_Button_gameObject = about_content_Panel_gameObject.transform.Find("Button_Close").gameObject;
		about_content_close_Button = about_content_close_Button_gameObject.GetComponent<UnityEngine.UI.Button>();
	}
}
