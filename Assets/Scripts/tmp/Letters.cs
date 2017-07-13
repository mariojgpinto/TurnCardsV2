using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Letters : MonoBehaviour {
	public float animationTime = .5f;
	Text text = null;

	public void Appear() {
		StartCoroutine(Appear_routine());
	}

	public void Disappear() {
		StartCoroutine(Disappear_routine());
	}

	IEnumerator Appear_routine() {
		string originalText = text.text;

		float deltaWait = animationTime / originalText.Length;
		text.text = "";
		for (int i = 0; i < originalText.Length; ++i) {
			text.text = text.text + originalText[i];
			yield return new WaitForSeconds(deltaWait);
		}

		text.text = originalText;
	}

	IEnumerator Disappear_routine() {
		string originalText = text.text;
		float deltaWait = animationTime / text.text.Length;

		text.text = originalText;
		for (int i = 0; i < originalText.Length; ++i) {
			text.text = originalText.Substring(0, originalText.Length - i - 1) ;
			yield return new WaitForSeconds(deltaWait);
		}

		text.text = "";
	}

	// Use this for initialization
	void Start() {
		text = this.GetComponent<Text>();

		Appear();
	}

	//private void OnDisable() {
	//	Debug.Log("Text Invisible - " + text.text);
	//}

	private void OnEnable() {
		if(text != null)
			Appear();
	}
}
