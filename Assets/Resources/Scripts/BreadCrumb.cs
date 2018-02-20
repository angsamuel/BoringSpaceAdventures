using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumb : MonoBehaviour {
	LevelController lc;
	public GameObject orb;
	public string description;
	public string control;
	bool active = false;
	// Use this for initialization
	void Start () {
		lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
		StartCoroutine (SwitchOn ());
	}

	Color OppositeColor(Color c){
		Color opposite = new Color (1.0f - c.r, 1.0f - c.g, 1.0f - c.b);
		return opposite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SwitchOn(){
		yield return new WaitForSeconds (1f);
		active = true;
		orb.GetComponent<Renderer> ().material.color = OppositeColor (lc.groundMaterial.color);

	}

	void OnTriggerEnter(Collider other){
		if (active) {
			if (other.tag == "Player") {
				lc.WriteDescription (description);
				lc.WriteControl (control);
			}
		}
	}
}
