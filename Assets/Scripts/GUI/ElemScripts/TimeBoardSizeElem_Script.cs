using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoardSizeElem_Script : MonoBehaviour {
	#region VARIABLES
	public UnityEngine.UI.Text title;
	TimePack pack;
	#endregion

	#region SETUP
	public void Inititalize(TimePack _pack) {
		pack = _pack;

		title.text = pack.boardSize + "x" + pack.boardSize;

		this.GetComponent<UnityEngine.UI.Toggle>().group = this.transform.parent.gameObject.GetComponent<UnityEngine.UI.ToggleGroup>();

		this.GetComponent<UnityEngine.UI.Toggle>().onValueChanged.AddListener((bool value) => SetSelectedSize(value));
	}

	private void SetSelectedSize(bool value) {
		GUI_Controller.instance.gui_Time.GetComponent<Time_Script>().SetSelectedSize(pack);
	}
	#endregion
}
