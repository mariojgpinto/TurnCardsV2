using UnityEngine;
using System;
using System.IO;
using System.Collections;

using MPAssets;

public class GUI_Time : MonoBehaviour {
	// TIME ---------------------------------------------
	public static GameObject				time_Panel_gameObject;
	public static UnityEngine.UI.Image		time_Panel;


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

	public static GameObject				buttons_boards_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_boards_Button;

	public static GameObject				buttons_boards_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_boards_title_Text;

	public static GameObject				buttons_t30_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_t30_Button;

	public static GameObject				buttons_t30_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t30_title_Text;

	public static GameObject				buttons_t30_square_Image_gameObject;
	public static UnityEngine.UI.Image		buttons_t30_square_Image;

	public static GameObject				buttons_t30_square_best_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t30_square_best_Text;

	public static GameObject				buttons_t60_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_t60_Button;

	public static GameObject				buttons_t60_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t60_title_Text;

	public static GameObject				buttons_t60_square_Image_gameObject;
	public static UnityEngine.UI.Image		buttons_t60_square_Image;

	public static GameObject				buttons_t60_square_best_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t60_square_best_Text;

	public static GameObject				buttons_t90_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_t90_Button;

	public static GameObject				buttons_t90_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t90_title_Text;

	public static GameObject				buttons_t90_square_Image_gameObject;
	public static UnityEngine.UI.Image		buttons_t90_square_Image;

	public static GameObject				buttons_t90_square_best_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t90_square_best_Text;

	public static GameObject				buttons_t120_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_t120_Button;

	public static GameObject				buttons_t120_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t120_title_Text;

	public static GameObject				buttons_t120_square_Image_gameObject;
	public static UnityEngine.UI.Image		buttons_t120_square_Image;

	public static GameObject				buttons_t120_square_best_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t120_square_best_Text;

	public static GameObject				buttons_t180_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_t180_Button;

	public static GameObject				buttons_t180_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t180_title_Text;

	public static GameObject				buttons_t180_square_Image_gameObject;
	public static UnityEngine.UI.Image		buttons_t180_square_Image;

	public static GameObject				buttons_t180_square_best_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t180_square_best_Text;

	public static GameObject				buttons_t240_Button_gameObject;
	public static UnityEngine.UI.Button		buttons_t240_Button;

	public static GameObject				buttons_t240_title_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t240_title_Text;

	public static GameObject				buttons_t240_square_Image_gameObject;
	public static UnityEngine.UI.Image		buttons_t240_square_Image;

	public static GameObject				buttons_t240_square_best_Text_gameObject;
	public static UnityEngine.UI.Text		buttons_t240_square_best_Text;

	// BOARDSIZE ---------------------------------------------
	public static GameObject				boardSize_Panel_gameObject;
	public static UnityEngine.UI.Image		boardSize_Panel;

	public static GameObject				boardSize_sideClose_Button_gameObject;
	public static UnityEngine.UI.Button		boardSize_sideClose_Button;

	public static GameObject				boardSize_content_Panel_gameObject;
	public static UnityEngine.UI.Image		boardSize_content_Panel;

	public static GameObject				boardSize_content_background_Image_gameObject;
	public static UnityEngine.UI.Image		boardSize_content_background_Image;

	public static GameObject				boardSize_content_title_Text_gameObject;
	public static UnityEngine.UI.Text		boardSize_content_title_Text;

	public static GameObject				boardSize_content_description_Text_gameObject;
	public static UnityEngine.UI.Text		boardSize_content_description_Text;

	public static GameObject				boardSize_content_listSizes_Panel_gameObject;
	public static UnityEngine.UI.Image		boardSize_content_listSizes_Panel;

	public static GameObject				boardSize_content_ok_Button_gameObject;
	public static UnityEngine.UI.Button		boardSize_content_ok_Button;

	public static GameObject				boardSize_content_ok_title_Text_gameObject;
	public static UnityEngine.UI.Text		boardSize_content_ok_title_Text;

	public static GameObject				boardSize_content_close_Button_gameObject;
	public static UnityEngine.UI.Button		boardSize_content_close_Button;



	public static void UpdateValues(GameObject panel){
		time_Panel_gameObject = panel.gameObject;
		time_Panel = time_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_Panel_gameObject = time_Panel_gameObject.transform.Find("Panel_Top").gameObject;
		top_Panel = top_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		top_back_Button_gameObject = top_Panel_gameObject.transform.Find("Button_Back").gameObject;
		top_back_Button = top_back_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		top_title_Text_gameObject = top_Panel_gameObject.transform.Find("Text_Title").gameObject;
		top_title_Text = top_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_Panel_gameObject = time_Panel_gameObject.transform.Find("Panel_Buttons").gameObject;
		buttons_Panel = buttons_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_boards_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_Boards").gameObject;
		buttons_boards_Button = buttons_boards_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_boards_title_Text_gameObject = buttons_boards_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_boards_title_Text = buttons_boards_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t30_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_T30").gameObject;
		buttons_t30_Button = buttons_t30_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_t30_title_Text_gameObject = buttons_t30_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_t30_title_Text = buttons_t30_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t30_square_Image_gameObject = buttons_t30_Button_gameObject.transform.Find("Image_Square").gameObject;
		buttons_t30_square_Image = buttons_t30_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_t30_square_best_Text_gameObject = buttons_t30_square_Image_gameObject.transform.Find("Text_Best").gameObject;
		buttons_t30_square_best_Text = buttons_t30_square_best_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t60_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_T60").gameObject;
		buttons_t60_Button = buttons_t60_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_t60_title_Text_gameObject = buttons_t60_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_t60_title_Text = buttons_t60_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t60_square_Image_gameObject = buttons_t60_Button_gameObject.transform.Find("Image_Square").gameObject;
		buttons_t60_square_Image = buttons_t60_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_t60_square_best_Text_gameObject = buttons_t60_square_Image_gameObject.transform.Find("Text_Best").gameObject;
		buttons_t60_square_best_Text = buttons_t60_square_best_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t90_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_T90").gameObject;
		buttons_t90_Button = buttons_t90_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_t90_title_Text_gameObject = buttons_t90_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_t90_title_Text = buttons_t90_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t90_square_Image_gameObject = buttons_t90_Button_gameObject.transform.Find("Image_Square").gameObject;
		buttons_t90_square_Image = buttons_t90_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_t90_square_best_Text_gameObject = buttons_t90_square_Image_gameObject.transform.Find("Text_Best").gameObject;
		buttons_t90_square_best_Text = buttons_t90_square_best_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t120_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_T120").gameObject;
		buttons_t120_Button = buttons_t120_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_t120_title_Text_gameObject = buttons_t120_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_t120_title_Text = buttons_t120_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t120_square_Image_gameObject = buttons_t120_Button_gameObject.transform.Find("Image_Square").gameObject;
		buttons_t120_square_Image = buttons_t120_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_t120_square_best_Text_gameObject = buttons_t120_square_Image_gameObject.transform.Find("Text_Best").gameObject;
		buttons_t120_square_best_Text = buttons_t120_square_best_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t180_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_T180").gameObject;
		buttons_t180_Button = buttons_t180_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_t180_title_Text_gameObject = buttons_t180_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_t180_title_Text = buttons_t180_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t180_square_Image_gameObject = buttons_t180_Button_gameObject.transform.Find("Image_Square").gameObject;
		buttons_t180_square_Image = buttons_t180_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_t180_square_best_Text_gameObject = buttons_t180_square_Image_gameObject.transform.Find("Text_Best").gameObject;
		buttons_t180_square_best_Text = buttons_t180_square_best_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t240_Button_gameObject = buttons_Panel_gameObject.transform.Find("Button_T240").gameObject;
		buttons_t240_Button = buttons_t240_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		buttons_t240_title_Text_gameObject = buttons_t240_Button_gameObject.transform.Find("Text_Title").gameObject;
		buttons_t240_title_Text = buttons_t240_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		buttons_t240_square_Image_gameObject = buttons_t240_Button_gameObject.transform.Find("Image_Square").gameObject;
		buttons_t240_square_Image = buttons_t240_square_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		buttons_t240_square_best_Text_gameObject = buttons_t240_square_Image_gameObject.transform.Find("Text_Best").gameObject;
		buttons_t240_square_best_Text = buttons_t240_square_best_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		boardSize_Panel_gameObject = time_Panel_gameObject.transform.Find("Panel_BoardSize").gameObject;
		boardSize_Panel = boardSize_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		boardSize_sideClose_Button_gameObject = boardSize_Panel_gameObject.transform.Find("Button_SideClose").gameObject;
		boardSize_sideClose_Button = boardSize_sideClose_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		boardSize_content_Panel_gameObject = boardSize_Panel_gameObject.transform.Find("Panel_Content").gameObject;
		boardSize_content_Panel = boardSize_content_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		boardSize_content_background_Image_gameObject = boardSize_content_Panel_gameObject.transform.Find("Image_Background").gameObject;
		boardSize_content_background_Image = boardSize_content_background_Image_gameObject.GetComponent<UnityEngine.UI.Image>();

		boardSize_content_title_Text_gameObject = boardSize_content_Panel_gameObject.transform.Find("Text_Title").gameObject;
		boardSize_content_title_Text = boardSize_content_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		boardSize_content_description_Text_gameObject = boardSize_content_Panel_gameObject.transform.Find("Text_Description").gameObject;
		boardSize_content_description_Text = boardSize_content_description_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		boardSize_content_listSizes_Panel_gameObject = boardSize_content_Panel_gameObject.transform.Find("Panel_ListSizes").gameObject;
		boardSize_content_listSizes_Panel = boardSize_content_listSizes_Panel_gameObject.GetComponent<UnityEngine.UI.Image>();

		boardSize_content_ok_Button_gameObject = boardSize_content_Panel_gameObject.transform.Find("Button_Ok").gameObject;
		boardSize_content_ok_Button = boardSize_content_ok_Button_gameObject.GetComponent<UnityEngine.UI.Button>();

		boardSize_content_ok_title_Text_gameObject = boardSize_content_ok_Button_gameObject.transform.Find("Text_Title").gameObject;
		boardSize_content_ok_title_Text = boardSize_content_ok_title_Text_gameObject.GetComponent<UnityEngine.UI.Text>();

		boardSize_content_close_Button_gameObject = boardSize_content_Panel_gameObject.transform.Find("Button_Close").gameObject;
		boardSize_content_close_Button = boardSize_content_close_Button_gameObject.GetComponent<UnityEngine.UI.Button>();
	}
}
