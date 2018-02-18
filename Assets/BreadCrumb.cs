using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumb : MonoBehaviour {
	LevelController lc;
	public GameObject orb;
	// Use this for initialization
	void Start () {
		//lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
		//orb.GetComponent<Renderer> ().material.color = OppositeColor (lc.groundMaterial.color);
	}

	Color OppositeColor(Color c){
		Color opposite = new Color (1.0f - c.r, 1.0f - c.g, 1.0f - c.b);
		return opposite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
