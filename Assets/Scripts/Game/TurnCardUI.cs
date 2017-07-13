using UnityEngine;
using System.Collections;

public class TurnCardUI : MonoBehaviour {
	public const float animationTime = .5f;
	#region VARIABLES
	public bool isBack = false;
	public bool isActive = true;

	public bool isBusy = false;

	public int posX;
	public int posY;
	Vector3 initialScale = Vector3.one;

	public bool stop = false;

	Coroutine routineTurn = null;
	Coroutine routineHide = null;
	Coroutine routineShow = null;
	#endregion

	#region SETUP
	public void Init(int x, int y){
		posX = x;
		posY = y;
		isActive = true;
	}

	public void ResetCard(bool useRoutine = false){
		//if (isBusy) {
		//	//StopCoroutine(HideCard_routine());
		//	stop = true;
		//}

		if (routineTurn != null)
			StopCoroutine(routineTurn);
		if (routineHide != null)
			StopCoroutine(routineHide);
		if (routineShow != null)
			StopCoroutine(routineShow);

		isBusy = false;
		stop = false;

		this.transform.rotation = Quaternion.identity;

		if (useRoutine) {
			StartCoroutine(ShowCard_routine());
		}
		else {
			this.transform.localScale = initialScale;
		}

		isActive = true;
	}
	#endregion

	#region ACTIONS
	public void ProcessTouch() {
		if(GUI_Controller.instance.gui_GameRegular.activeSelf)
			Controller.instance.gameRegular.ProcessTouch(this);
		else
			//if (GUI_Controller.instance.gui_GameRegular.activeSelf)
			Controller.instance.gameTimed.ProcessTouch(this);
	}

	public void FlipCard(float waitTime = 0){
		//Debug.Log("Flip UI");
		if (!isBusy){
			isBusy = true;
			routineTurn = StartCoroutine(FlipCard_routine(waitTime));
		}
	}

	public void HideCard(){
		if (!isBusy){
			isBusy = true;
			routineHide = StartCoroutine(HideCard_routine());
		}
	}

	public void SetFront(){
		isBack = false;
		//this.transform.rotation = Quaternion.Euler(0,180,0);
		this.GetComponent<UnityEngine.UI.Image>().color = Preferences.colorFront;
	}

	public void SetBack(){
		isBack = true;
		//this.transform.rotation = Quaternion.Euler(0,0,0);
		this.GetComponent<UnityEngine.UI.Image>().color = Preferences.colorBack;
	}
	#endregion

	#region ACTIONS_AUXILIAR
	IEnumerator FlipCard_routine(float waitTime){
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.1
		float duration = animationTime;
		Vector3 initialRotation = this.transform.rotation.eulerAngles;
		
		yield return new WaitForSeconds(waitTime);

		bool turned = false;

		while(progress < 1)
		{
			this.transform.rotation = Quaternion.Euler(initialRotation + (Vector3.up * 180 * progress));

			if (progress < .5f)
				this.transform.localScale = (initialScale) + (initialScale * .5f) * progress;
			else {
				this.transform.localScale = (initialScale) + (initialScale * .5f) * (1 - progress);

				if (!turned) {
					if(isBack)
						this.GetComponent<UnityEngine.UI.Image>().color = Preferences.colorFront;
					else
						this.GetComponent<UnityEngine.UI.Image>().color = Preferences.colorBack;
					turned = false;
				}
			}

			if(stop){
				stop = false;
				goto end;
			}

			progress += Time.deltaTime/duration;
			yield return true;//new WaitForSeconds(smoothness);
		}
		isBack = !isBack;
		this.transform.rotation = Quaternion.Euler(Vector3.zero);
		if (isBack)
			this.GetComponent<UnityEngine.UI.Image>().color = Preferences.colorBack;
		else
			this.GetComponent<UnityEngine.UI.Image>().color = Preferences.colorFront;

		this.transform.localScale = initialScale;
		
		isBusy = false;
		routineTurn = null;
		yield break; 

		end:
		this.transform.localScale = initialScale;
		this.transform.rotation = Quaternion.Euler(Vector3.zero);
		routineTurn = null;
		yield break;
	}

	IEnumerator HideCard_routine(){
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.1
		float duration = animationTime;
		
		isActive = false;
		
		while(progress < 1)
		{
			this.transform.localScale = initialScale * (1-progress);

			if(stop){
				stop = false;
				goto end;
			}

			progress += Time.deltaTime/duration;
			yield return true;//new WaitForSeconds(smoothness);
		}

		this.transform.localScale = Vector3.zero;
		
		isBusy = false;

		SetBack();
		routineHide = null;
		yield break; 

		end:
		this.transform.localScale = initialScale;
		this.transform.rotation = Quaternion.Euler(Vector3.zero);
		routineHide = null;
		yield break;
	}

	IEnumerator ShowCard_routine() {
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.1
		float duration = animationTime/2f;

		isBusy = true;
		isActive = false;

		while (progress < 1) {
			this.transform.localScale = initialScale * (progress);

			progress += Time.deltaTime / duration;
			yield return true;//new WaitForSeconds(smoothness);
		}

		this.transform.localScale = Vector3.one;

		isBusy = false;
		yield break;
	}
	#endregion
}
