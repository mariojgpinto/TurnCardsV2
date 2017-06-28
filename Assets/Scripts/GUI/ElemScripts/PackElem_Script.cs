using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackElem_Script : MonoBehaviour {
	#region VARIABLES
	public Text title;
	public Text progress;
	public Image star;

	public Pack pack;
	#endregion

	#region INITIALIZE
	public void SetInfo(Pack _pack) {
		pack = _pack;

		title.text = pack.title;

		int totalBoards = pack.boards.Count;
		int totalCompleted = pack.GetCompleted();

		progress.text = totalCompleted + "/" + totalBoards;

		if(totalBoards == totalCompleted) {
			int totalPerfect = pack.GetCompletedPerfect();
			if (totalBoards == totalPerfect) {
				//SHOW STAR
			}
			else {
				//SHOW COMPLETE
			}

			star.gameObject.SetActive(true);
		}
		else {
			star.gameObject.SetActive(false);
		}

		this.GetComponent<Button>().onClick.AddListener(() => OnButtonClicked());
	}
	#endregion

	#region BUTTON_CALLBACK
	void OnButtonClicked() {
		Debug.Log("Click: " + pack.title);
		GUI_Controller.instance.gui_Boards.GetComponent<Boards_Script>().Initialize(pack);

		GUI_Animation.SwitchMenus(GUI_Controller.instance.gui_Levels, GUI_Controller.instance.gui_Boards);
	}
	#endregion
}
