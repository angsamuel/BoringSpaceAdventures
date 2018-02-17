using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {
	LevelController lc;
	public string description;
	public string control;

	Ship ship;

	bool active = true;
	bool usable = false;
	// Use this for initialization
	void Start () {
		lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
		ship = GameObject.Find ("Ship").GetComponent<Ship> ();
	}
	
	// Update is called once per frame
	void Update () {
		ScanInput ();
	}



	void ScanInput(){
		if (usable) {
			if (Input.GetAxisRaw ("Use") != 0) {
				ship.Launch ();
				usable = false;
				active = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (active) {
			if (other.tag == "Player") {
				usable = true;
				lc.WriteDescription (description);
				lc.WriteControl (control);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (active) {
			if (other.tag == "Player") {
				usable = false;
				lc.ClearText ();
				lc.StopTypingRoutines ();
			}
		}
	}
}
