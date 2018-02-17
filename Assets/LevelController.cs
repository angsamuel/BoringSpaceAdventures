using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour {
	public Text descriptionText;
	public Text controlText;
	public PlayerUnitController puc;

	Coroutine lastDescriptionRoutine;
	Coroutine lastControlRoutine;

	Material groundMaterial;

	Image coverPanel;
	// Use this for initialization
	void Start () {
		groundMaterial = GameObject.Find ("Ground").GetComponent<Renderer> ().material;
		RandomizeGroundColor ();
		descriptionText.text = "";
		controlText.text = "";
		puc = GameObject.Find ("PlayerUnit").GetComponent<PlayerUnitController> ();
		coverPanel = GameObject.Find ("CoverPanel").GetComponent<Image> ();
		coverPanel.color = Color.black;
		puc.active = false;
		FadeFromBlack ();
	}

	void RandomizeGroundColor(){
		groundMaterial.color = new Color (Random.Range (0.0f, 0.8f), Random.Range (0.0f, 0.8f), Random.Range (0.0f, 0.8f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClearText(){
		descriptionText.text = "";
		controlText.text = "";
	}

	public void StopTypingRoutines(){
		if (lastDescriptionRoutine != null) {
			StopCoroutine (lastDescriptionRoutine);
		}
		if (lastControlRoutine != null) {
			StopCoroutine (lastControlRoutine);
		}

		ClearText ();

	}

	public void WriteDescription(string m){
		if (lastDescriptionRoutine != null) {
			StopCoroutine (lastDescriptionRoutine);
		}

		lastDescriptionRoutine = StartCoroutine (TypeDescription (m));
	}

	public void WriteControl(string m){
		if (lastControlRoutine != null) {
			StopCoroutine (lastControlRoutine);
		}
		lastControlRoutine = StartCoroutine (TypeControl (m));
	}

	float textTypeDelay = 0.001f;
	IEnumerator TypeDescription(string m){
		ClearText ();
		yield return new WaitForSeconds (textTypeDelay);

		for (int i = 0; i < m.Length; i++) {
			descriptionText.text += m [i];
			yield return new WaitForSeconds (textTypeDelay);
		}
	}

	IEnumerator TypeControl(string m){
		ClearText ();

		yield return new WaitForSeconds (textTypeDelay);

		for (int i = 0; i < m.Length; i++) {
			controlText.text += m [i];
			yield return new WaitForSeconds (textTypeDelay);
		}
	}


	public void FadeToBlack(){
		StartCoroutine (FadeToBlackRoutine ());
	}
	public void FadeFromBlack(){
		StartCoroutine (FadeFromBlackRoutine ());

	}

	float coverPanelFadetime = 3f;
	IEnumerator FadeFromBlackRoutine(){
		float t = 0;
		yield return new WaitForSeconds (1);
		while (t < coverPanelFadetime) {
			t += Time.deltaTime;
			coverPanel.color = new Color (coverPanel.color.r, coverPanel.color.g, coverPanel.color.b, Mathf.Lerp (1, 0, t / coverPanelFadetime));
			yield return null;

		}
		GameObject.Find ("CryoPod").GetComponent<CryoPod> ().DefrostPlayer ();

		coverPanel.color = Color.clear;
	}

	IEnumerator FadeToBlackRoutine(){
		float t = 0;
		while (t < coverPanelFadetime) {
			t += Time.deltaTime;
			coverPanel.color = new Color (coverPanel.color.r, coverPanel.color.g, coverPanel.color.b, Mathf.Lerp (0, 1, t / coverPanelFadetime));
			yield return null;
		}
		coverPanel.color = Color.black;
	}

}
