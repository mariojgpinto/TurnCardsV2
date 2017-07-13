using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Script : MonoBehaviour {
	#region VARIABLES
	public GameObject boardSizePrefab;
	public GameObject boardSizeParent;

	public Text boardSizeTitle;

	public TimePack currentPack;

	bool initialized = false;
	List<TimeBoardSizeElem_Script> timeElement = new List<TimeBoardSizeElem_Script>();
	#endregion

	#region SETUP
	public void Initialize() {
		GUI_Time.boardSize_Panel_gameObject.SetActive(false);

		if (!initialized) {
			bool first = true;
			foreach (TimePack pack in DataManager.instance.data.timePacks) {
				GameObject go = Instantiate(boardSizePrefab, boardSizeParent.transform, false);

				go.GetComponent<TimeBoardSizeElem_Script>().Inititalize(pack);
				timeElement.Add(go.GetComponent<TimeBoardSizeElem_Script>());
				go.GetComponent<Toggle>().isOn = first;
				
				if (first) {
					SetSelectedSize(pack);
					first = false;
				}
			}

			initialized = true;
		}
		else {
			SetSelectedSize(currentPack);
		}
	}

	public void SetSelectedSize(TimePack pack) {
		Debug.Log("Selected Size: " + pack.boardSize);
		currentPack = pack;

		boardSizeTitle.text = currentPack.title;

		GUI_Time.buttons_t30_square_best_Text.text = currentPack.records[0].score.ToString();
		GUI_Time.buttons_t60_square_best_Text.text = currentPack.records[1].score.ToString();
		GUI_Time.buttons_t90_square_best_Text.text = currentPack.records[2].score.ToString();
		GUI_Time.buttons_t120_square_best_Text.text = currentPack.records[3].score.ToString();
		GUI_Time.buttons_t180_square_best_Text.text = currentPack.records[4].score.ToString();
	}
	#endregion
}
