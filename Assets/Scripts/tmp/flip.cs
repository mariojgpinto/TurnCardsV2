using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour {

	public void FlipButton() {
		StartCoroutine(FlipButton_routine());
	}

	IEnumerator FlipButton_routine() {
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.1
		float duration = .5f;
		Vector3 initialRotation = this.transform.rotation.eulerAngles;

		this.GetComponent<UnityEngine.UI.Image>().color = Color.white;
		//this.GetComponentInChildren<UnityEngine.UI.Text>().color = Color.black;


		Debug.Log("Beginnig");

		while (progress < 1) {
			this.transform.rotation = Quaternion.Euler(initialRotation + (Vector3.right * 90 * progress));

			progress += Time.deltaTime / duration;
			yield return true;//new WaitForSeconds(smoothness);
		}

		this.GetComponent<UnityEngine.UI.Image>().overrideSprite = null;
		this.GetComponent<UnityEngine.UI.Image>().color = Color.white;
		this.GetComponentInChildren<UnityEngine.UI.Text>().color = Color.black;

		Debug.Log("Middle");

		progress = 0; //This float will serve as the 3rd parameter of the lerp function.1
		duration = .5f;
		initialRotation = this.transform.rotation.eulerAngles;

		while (progress < 1) {
			this.transform.rotation = Quaternion.Euler(initialRotation + (Vector3.right * -90 * progress));

			progress += Time.deltaTime / duration;
			yield return true;//new WaitForSeconds(smoothness);
		}

		this.transform.rotation = Quaternion.Euler(Vector3.zero);

		Debug.Log("End");
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
