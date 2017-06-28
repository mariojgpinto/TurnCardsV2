using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _TestAdmob : MonoBehaviour {
	public AdmobManager admob;
	//public Text text


	public void OnButtonPressed(int id) {
		switch (id) {
			case 0:
				admob.ShowBannerRelative();
				break;
			case 1:
				admob.ShowBannerAbsolute();
				break;
			case 2:
				admob.ShowInterstitial();
				break;
			default: break;
		}
	}

	// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
