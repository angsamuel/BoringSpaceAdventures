using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoPod : MonoBehaviour {
	LevelController lc;

	public bool active = false;
	bool usable = false;
	bool displayDesc = false;
	public GameObject ice;
	float offset = -.65f;
	// Use this for initialization
	void Start () {
		lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
		lc.playerUnit.transform.position = this.transform.position + new Vector3(0,offset,0);
		//ice.transform.localScale = new Vector3 (0.9f, 0.0001f, 0.9f);
		//ice.transform.localPosition = new Vector3 (0, -0.4f, 0);
		//ice.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (usable) {
			ScanInput ();
		}
	}

	void ScanInput(){
		if(Input.GetAxisRaw("Use") != 0){
			FreezePlayer();

		}
	}

	void FreezePlayer(){
		lc.puc.active = false;

		StartCoroutine (FreezeRoutine ());
	}

	public void DefrostPlayer(){
		lc.ship.WallsActive (false);
		StartCoroutine (DefrostRoutine ());
	}



	float timeToExpand = 4;
	float timeToFade = 1;

	IEnumerator DefrostRoutine(){

		lc.WriteDescription ("DEFROSTING...");
		lc.WriteControl ("please wait");
		float t = 0;

		Material material = GetComponent<Renderer> ().material;
		while (t < timeToFade) {
			t += Time.deltaTime;
			material.color = new Color(material.color.r, material.color.g, material.color.g, Mathf.Lerp(1, 0, t/timeToFade));
			lc.playerUnit.transform.position = this.transform.position + new Vector3(0,offset,0);

			yield return null;
		}

		t = 0;

		while (t < timeToExpand) {
			t += Time.deltaTime;
			ice.transform.localPosition = new Vector3(0, Mathf.Lerp( 0.0f,-0.4f, t/timeToExpand), 0);
			ice.transform.localScale = new Vector3 (0.9f, 0.8f - t / timeToExpand * 0.8f, 0.9f);
			lc.playerUnit.transform.position = this.transform.position + new Vector3(0,offset,0);
			yield return null;
		}

		usable = false;
		active = false;
		lc.puc.active = true;
		ice.SetActive (false);
		lc.playerUnit.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		lc.WriteDescription ("DEFROST COMPLETE");
		lc.WriteControl ("please exit the CRYO POD");
	}
		

	IEnumerator FreezeRoutine(){
		lc.ClearText ();
		active = false;
		usable = false;
		lc.WriteDescription ("FREEZING...");
		ice.SetActive (true);
		float t = 0;
		while (t < timeToExpand) {
			t += Time.deltaTime;
			ice.transform.localPosition = new Vector3(0, Mathf.Lerp(-0.4f, 0.0f, t/timeToExpand), 0);
			ice.transform.localScale = new Vector3 (0.9f, t / timeToExpand * 0.8f, 0.9f);

			yield return null;
		}

		t = 0;
		Material material = GetComponent<Renderer> ().material;
		while (t < timeToFade) {
			t += Time.deltaTime;
			material.color = new Color(material.color.r, material.color.g, material.color.g, Mathf.Lerp(0, 1, t/timeToFade));

			yield return null;
		}
		lc.playerUnit.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		lc.WriteDescription ("FREEZE COMPLETE");
		lc.WriteControl ("sleep tight");
		yield return new WaitForSeconds (1);
		lc.FadeToBlack ();
	}

	void OnTriggerEnter(Collider other){
			if (other.tag == "Player") {
				if (active){
					lc.WriteControl ("press 'e' to begin journey");
					usable = true;
				}
			if (displayDesc) {
				lc.WriteDescription ("CRYO POD");
			}
			}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			lc.ClearText();
			displayDesc = true;
		}
	}
}
