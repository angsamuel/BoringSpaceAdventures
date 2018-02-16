﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour {
	Material material;
	float currentAlpha;
	Color c;
	float fadeTime = .5f;
	// Use this for initialization
	void Start () {
		currentAlpha = 1f;
		material = GetComponent<Renderer> ().material;
		c = material.color;
		material.color = new Color (c.r, c.b, c.g, currentAlpha);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool canEnter = true;
	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && canEnter) {
			canEnter = false;
			StartCoroutine (FadeOut ());
		}

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			canEnter = true;
			StartCoroutine (FadeIn ());
		}
	}

	IEnumerator FadeIn(){
		Debug.Log ("FADE IN");
		StopCoroutine (FadeOut ());
		while (currentAlpha < 1) {
			yield return null;
			currentAlpha += Time.deltaTime/fadeTime;
			material.color = new Color (c.r, c.b, c.g, currentAlpha);
		}
	}

	IEnumerator FadeOut(){
		Debug.Log ("FADE OUT");

		StopCoroutine (FadeIn ());
		while (currentAlpha > 0) {
			yield return null;
			currentAlpha -= Time.deltaTime/fadeTime;
			material.color = new Color (c.r, c.b, c.g, currentAlpha);
		}
	}
}
