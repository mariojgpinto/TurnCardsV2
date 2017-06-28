using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_Boards : MonoBehaviour {
	// BOARDS ---------------------------------------------
	public static GameObject				boards_Panel_gameObject;
	public static UnityEngine.UI.Image		boards_Panel;


	// TOP ---------------------------------------------
	public static GameObject				top_Panel_gameObject;
	public static UnityEngine.UI.Image		top_Panel;

	public static GameObject				top_back_Button_gameObject;
	public static UnityEngine.UI.Button		top_back_Button;

	public static GameObject				top_title_Text_gameObject;
	public static UnityEngine.UI.Text		top_title_Text;

	// SCROLL ---------------------------------------------
	public static GameObject				scroll_Panel_gameObject;
	public static UnityEngine.UI.Image		scroll_Panel;

	public static GameObject				scroll_list_Panel_gameObject;
	public static UnityEngine.UI.Image		scroll_list_Panel;



	public static void UpdateValues(GameObject panel){
		boards_Panel_gameObject = panel.gameObject;
		boards_Panel = boards_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_Panel_gameObject = boards_Panel_gameObject.transform.Find("Panel_Top").gameObject;
		top_Panel = top_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_back_Button_gameObject = top_Panel_gameObject.transform.Find("Button_Back").gameObject;
		top_back_Button = top_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		top_title_Text_gameObject = top_Panel_gameObject.transform.Find("Text_Title").gameObject;
		top_title_Text = top_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		scroll_Panel_gameObject = boards_Panel_gameObject.transform.Find("Panel_Scroll").gameObject;
		scroll_Panel = scroll_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		scroll_list_Panel_gameObject = scroll_Panel_gameObject.transform.Find("Panel_List").gameObject;
		scroll_list_Panel = scroll_list_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();
	}
}
