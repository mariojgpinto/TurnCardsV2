using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packs_Script : MonoBehaviour {
	#region VARIABLES
	public GameObject prefabButton;

	public GameObject panel_list;
	#endregion

	#region SETUP
	public void Initialize() {
		if(DataManager.instance.data.packs_state == Macros.DATA_STATE.LOADED) {
			foreach(Pack pack in DataManager.instance.data.packs) {
				GameObject btn = Instantiate(prefabButton, panel_list.transform, false);

				btn.GetComponent<PackElem_Script>().SetInfo(pack);
			}
		}
	}
	#endregion
}
