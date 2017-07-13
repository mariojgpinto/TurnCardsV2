using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packs_Script : MonoBehaviour {
	#region VARIABLES
	public GameObject prefabButton;

	public GameObject panel_list;

	List<PackElem_Script> buttons = new List<PackElem_Script>();
	#endregion

	#region SETUP
	public void Initialize() {
		if (buttons.Count == 0) {
			if (DataManager.instance.data.packs_state == Macros.DATA_STATE.LOADED) {
				foreach (Pack pack in DataManager.instance.data.packs) {
					GameObject btn = Instantiate(prefabButton, panel_list.transform, false);

					btn.GetComponent<PackElem_Script>().SetInfo(pack);

					buttons.Add(btn.GetComponent<PackElem_Script>());
				}
			}
		}
		else {
			for (int i = 0; i < DataManager.instance.data.packs.Count; ++i ) {
				buttons[i].SetInfo(DataManager.instance.data.packs[i]);
			}
		}
	}
	#endregion
}
