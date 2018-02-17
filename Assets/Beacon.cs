using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour {
	LevelController lc;
	// Use this for initialization
	void Start () {
		lc = GameObject.Find("LevelController").GetComponent<LevelController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ScanInput(){
		if (usable) {
			if(Input.GetAx
		}
	}

	void OnTriggerEnter(Collider other){
		lc.WriteControl ("press 'e' to activate");
		lc.WriteDescription ("BEACON");
	}
	void OnTriggerExit(Collider other){
		lc.ClearText ();
	}
}
