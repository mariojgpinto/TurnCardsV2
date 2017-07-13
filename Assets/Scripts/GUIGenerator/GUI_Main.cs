using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_Main : MonoBehaviour {
	// MAIN ---------------------------------------------
	public static GameObject				main_Panel_gameObject;
	public static UnityEngine.UI.Image		main_Panel;


	// TITLE ---------------------------------------------
	public static GameObject				title_Image_gameObject;
	public static UnityEngine.UI.Image		title_Image;

	public static GameObject				title_title_Text_gameObject;
	public static UnityEngine.UI.Text		title_title_Text;

	// FREEPLAY ---------------------------------------------
	public static GameObject				freePlay_Button_gameObject;
	public static UnityEngine.UI.Button		freePlay_Button;

	public static GameObject				freePlay_title_Text_gameObject;
	public static UnityEngine.UI.Text		freePlay_title_Text;

	// TIMEPLAY ---------------------------------------------
	public static GameObject				timePlay_Button_gameObject;
	public static UnityEngine.UI.Button		timePlay_Button;

	public static GameObject				timePlay_title_Text_gameObject;
	public static UnityEngine.UI.Text		timePlay_title_Text;

	// SETTINGS ---------------------------------------------
	public static GameObject				settings_Button_gameObject;
	public static UnityEngine.UI.Button		settings_Button;

	public static GameObject				settings_title_Text_gameObject;
	public static UnityEngine.UI.Text		settings_title_Text;



	public static void UpdateValues(GameObject panel){
		main_Panel_gameObject = panel.gameObject;
		main_Panel = main_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		title_Image_gameObject = main_Panel_gameObject.transform.Find("Image_Title").gameObject;
		title_Image = title_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		title_title_Text_gameObject = title_Image_gameObject.transform.Find("Text_Title").gameObject;
		title_title_Text = title_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		freePlay_Button_gameObject = main_Panel_gameObject.transform.Find("Button_FreePlay").gameObject;
		freePlay_Button = freePlay_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		freePlay_title_Text_gameObject = freePlay_Button_gameObject.transform.Find("Text_Title").gameObject;
		freePlay_title_Text = freePlay_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		timePlay_Button_gameObject = main_Panel_gameObject.transform.Find("Button_TimePlay").gameObject;
		timePlay_Button = timePlay_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		timePlay_title_Text_gameObject = timePlay_Button_gameObject.transform.Find("Text_Title").gameObject;
		timePlay_title_Text = timePlay_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		settings_Button_gameObject = main_Panel_gameObject.transform.Find("Button_Settings").gameObject;
		settings_Button = settings_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		settings_title_Text_gameObject = settings_Button_gameObject.transform.Find("Text_Title").gameObject;
		settings_title_Text = settings_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();
	}
}
