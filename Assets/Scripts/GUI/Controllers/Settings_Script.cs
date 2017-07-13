using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Script : MonoBehaviour {
	#region VARIABLES
	public GameObject panelThemes;
	public GameObject panelReset;
	public GameObject panelAbout;
	#endregion

	#region UI_CALLBACKS
	public void Initialize() {
		SetPanelThemes(false);
		SetPanelReset(false);
		SetPanelAbout(false);
	}

	public void SetPanelThemes(bool enable) {
		panelThemes.SetActive(enable);
	}

	public void SetPanelReset(bool enable) {
		panelReset.SetActive(enable);
	}

	public void SetPanelAbout(bool enable) {
		panelAbout.SetActive(enable);
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#endregion
}
