using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour {
	LevelController lc;
	public GameObject light;
	public Color onColor;
	// Use this for initialization
	void Start () {
		lc = GameObject.Find("LevelController").GetComponent<LevelController> ();
	}
	
	// Update is called once per frame
	void Update () {
		ScanInput ();
	}
	bool usable = false;
	bool active = true;
	void ScanInput(){
		if (usable) {
			if (Input.GetAxisRaw ("Use") != 0) {
				usable = false;
				active = false;
				SwitchOn ();
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (active) {
			usable = true;
			lc.WriteControl ("press 'e' to activate");
		}
		lc.WriteDescription ("BEACON");

	}
	void OnTriggerExit(Collider other){
		lc.ClearText ();
	}

	void SwitchOn(){
		light.GetComponent<Renderer> ().material.color = onColor;
		lc.WriteControl ("please return to your ship");
		lc.WriteDescription ("BEACON ACTIVATED");
	}
}
