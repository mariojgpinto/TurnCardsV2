using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_Levels : MonoBehaviour {
	// LEVELS ---------------------------------------------
	public static GameObject				levels_Panel_gameObject;
	public static UnityEngine.UI.Image		levels_Panel;


	// TOP ---------------------------------------------
	public static GameObject				top_Panel_gameObject;
	public static UnityEngine.UI.Image		top_Panel;

	public static GameObject				top_back_Button_gameObject;
	public static UnityEngine.UI.Button		top_back_Button;

	public static GameObject				top_title_Text_gameObject;
	public static UnityEngine.UI.Text		top_title_Text;

	// BUTTONSSCROLL ---------------------------------------------
	public static GameObject				buttonsScroll_Panel_gameObject;
	public static UnityEngine.UI.Image		buttonsScroll_Panel;

	public static GameObject				buttonsScroll_list_Panel_gameObject;
	public static UnityEngine.UI.Image		buttonsScroll_list_Panel;



	public static void UpdateValues(GameObject panel){
		levels_Panel_gameObject = panel.gameObject;
		levels_Panel = levels_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_Panel_gameObject = levels_Panel_gameObject.transform.Find("Panel_Top").gameObject;
		top_Panel = top_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_back_Button_gameObject = top_Panel_gameObject.transform.Find("Button_Back").gameObject;
		top_back_Button = top_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		top_title_Text_gameObject = top_Panel_gameObject.transform.Find("Text_Title").gameObject;
		top_title_Text = top_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttonsScroll_Panel_gameObject = levels_Panel_gameObject.transform.Find("Panel_ButtonsScroll").gameObject;
		buttonsScroll_Panel = buttonsScroll_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttonsScroll_list_Panel_gameObject = buttonsScroll_Panel_gameObject.transform.Find("Panel_List").gameObject;
		buttonsScroll_list_Panel = buttonsScroll_list_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();
	}
}
