using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumber : Equipment {
	bool canUse = true;

	// Use this for initialization
	void Start () {
		//base.Start ();
		ammoMax = 30;
		ammoCount = ammoMax;
	}

	// Update is called once per frame
	void Update () {
		
	}

	override protected IEnumerator Cooldown(){
		canUse = false;
		yield return new WaitForSeconds (cooldownTime);
		canUse = true;
	}

	override public void Use(Unit u){
		Debug.Log (ammoCount);
		if (ammoCount > 0 && canUse) {
			StartCoroutine (Cooldown ());
			ammoCount = ammoCount - 1;
			GameObject newBreadCrumb = Instantiate (ammo, u.transform.position, Quaternion.identity);
		}
	}
}
