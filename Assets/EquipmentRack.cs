using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentRack : MonoBehaviour {
	LevelController lc;
	public string description;
	public string control;
	bool active = true;
	bool usable = false;
	// Use this for initialization
	void Start () {
		lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
