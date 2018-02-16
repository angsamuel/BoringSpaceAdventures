using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	Rigidbody rb;
	public float speed = 1;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame


	public void MoveLeft(){
		rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
	}
	public void MoveRight(){
		rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
	}

	public void StopHorz(){
		rb.velocity = new Vector3 (0, rb.velocity.y, rb.velocity.z);
	}
	public void MoveUp(){
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
	}
	public void MoveDown(){
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,-speed);
	}
	public void StopVert(){
		rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 0);
	}

	public void Jump(){
		rb.AddForce (new Vector3 (0, 500, 0));
	}
			

}
