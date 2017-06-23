using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using admob;


public class AdmobController : MonoBehaviour {
	#region VARIABLES
	//string appID = "ca-app-pub-6772547619228672~4666124948";

	//string bottomBanner = "ca-app-pub-6772547619228672/6142858149";

	//string interstitialID = "ca-app-pub-6772547619228672/4142791743";

	string ID_App = "ca-app-pub-6772547619228672~4666124948";

	string ID_Banner = "ca-app-pub-6772547619228672/6142858149";

	string ID_Interstitial = "ca-app-pub-6772547619228672/4142791743";

	private BannerView banner;
	private InterstitialAd interstitial;
	#endregion

	#region SETUP
	void Initialize() {
		InitializeBanner();

		InitializeInterstitial();
	}

	#region BANNER
	private void InitializeBanner() {
		banner = new BannerView(ID_Banner, AdSize.Banner, AdPosition.Bottom);
		// Called when an ad request has successfully loaded.
		banner.OnAdLoaded += Banner_OnAdLoaded;
		// Called when an ad request failed to load.
		banner.OnAdFailedToLoad += Banner_OnAdFailedToLoad;
		// Called when an ad is clicked.
		banner.OnAdOpening += Banner_OnAdOpening;
		// Called when the user returned from the app after an ad click.
		banner.OnAdClosed += Banner_OnAdClosed;
		// Called when the ad click caused the user to leave the application.
		banner.OnAdLeavingApplication += Banner_OnAdLeavingApplication;

		RequestBanner();
	}

	void RequestBanner() {
		//AdRequest requestBanner = new AdRequest.Builder().Build();
		AdRequest requestBanner = new AdRequest.Builder()
				.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
				.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
				.Build();

		// Load the banner with the request.
		banner.LoadAd(requestBanner);
	}

	private void Banner_OnAdLeavingApplication(object sender, System.EventArgs e) {
		Debug.Log("Banner - OnAdLeavingApplication");
	}

	private void Banner_OnAdClosed(object sender, System.EventArgs e) {
		Debug.Log("Banner - OnAdClosed");
	}

	private void Banner_OnAdOpening(object sender, System.EventArgs e) {
		Debug.Log("Banner - OnAdOpening");
	}

	private void Banner_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e) {
		Debug.Log("Banner - OnAdFailedToLoad");
	}

	private void Banner_OnAdLoaded(object sender, System.EventArgs e) {
		Debug.Log("Banner - OnAdLoaded");
	}
	#endregion

	#region INTERSTITIAL
	private void InitializeInterstitial() {
		interstitial = new InterstitialAd(ID_Interstitial);
		// Called when an ad request has successfully loaded.
		interstitial.OnAdLoaded += Interstitial_OnAdLoaded;
		// Called when an ad request failed to load.
		interstitial.OnAdFailedToLoad += Interstitial_OnAdFailedToLoad;
		// Called when an ad is clicked.
		interstitial.OnAdOpening += Interstitial_OnAdOpening;
		// Called when the user returned from the app after an ad click.
		interstitial.OnAdClosed += Interstitial_OnAdClosed;
		// Called when the ad click caused the user to leave the application.
		interstitial.OnAdLeavingApplication += Interstitial_OnAdLeavingApplication;

		RequestInterstitial();
	}

	void RequestInterstitial() {
		//AdRequest requestInterstitial = new AdRequest.Builder().Build();
		AdRequest requestInterstitial = new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
			.Build();

		// Load the interstitial with the request.
		interstitial.LoadAd(requestInterstitial);
	}

	private void Interstitial_OnAdLeavingApplication(object sender, System.EventArgs e) {
		Debug.Log("Interstitial - OnAdLeavingApplication");
		GameObject.Find("Text_Cenas").GetComponent<UnityEngine.UI.Text>().text += "Interstitial - OnAdLeavingApplication\n";
	}

	private void Interstitial_OnAdClosed(object sender, System.EventArgs e) {
		Debug.Log("Interstitial - OnAdClosed");
		GameObject.Find("Text_Cenas").GetComponent<UnityEngine.UI.Text>().text += "Interstitial - OnAdClosed\n";

		RequestInterstitial();
	}

	private void Interstitial_OnAdOpening(object sender, System.EventArgs e) {
		Debug.Log("Interstitial - OnAdOpening");
		GameObject.Find("Text_Cenas").GetComponent<UnityEngine.UI.Text>().text += "Interstitial - OnAdOpening\n";
	}

	private void Interstitial_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e) {
		Debug.Log("Interstitial - OnAdFailToLoad");
		GameObject.Find("Text_Cenas").GetComponent<UnityEngine.UI.Text>().text += "Interstitial - OnAdFailToLoad\n";
	}

	private void Interstitial_OnAdLoaded(object sender, System.EventArgs e) {
		Debug.Log("Interstitial - OnAdLoaded");
		GameObject.Find("Text_Cenas").GetComponent<UnityEngine.UI.Text>().text += "Interstitial - OnAdLoaded\n";
	}
	#endregion


	#endregion

	#region SHOW
	bool isBannerShowing = false;
	public void ShowBannerRelative() {
		if (isBannerShowing) {
			banner.Hide();
		}
		else {
			banner.Show();
		}
		isBannerShowing = !isBannerShowing;
	}

	public void ShowBannerAbsolute() {
		if (isBannerShowing) {
			banner.Hide();
		}
		else {
			banner.Show();
		}
		isBannerShowing = !isBannerShowing;
	}

	public void ShowInterstitial() {
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
		else {
			GameObject.Find("Text_Cenas").GetComponent<UnityEngine.UI.Text>().text += "Not Ready\n";
		}
	}
	#endregion

	#region UNITY_CALLBACKS
	// Use this for initialization
	void Start () {
		//Initialize();
	}

	//// Update is called once per frame
	//void Update () {

	//}

	private void OnApplicationQuit() {
		banner.Destroy();
		interstitial.Destroy();
	}
	#endregion
}