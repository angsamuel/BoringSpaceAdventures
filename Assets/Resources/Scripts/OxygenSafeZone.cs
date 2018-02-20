using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OxygenSafeZone : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Unit" || other.tag == "Player") {
			other.GetComponent<Unit> ().FillOxygen ();
		}
	}
}
