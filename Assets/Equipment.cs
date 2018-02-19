using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
	public string name;
	public string description;
	public float cooldownTime;
	public GameObject ammo;
	public int ammoMax;
	public int ammoCount;
	// Use this for initialization
	public void Start () {
		ammoCount = ammoMax;
	}

	protected virtual IEnumerator Cooldown(){
		yield return null;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Use(Unit u){

	}
}
