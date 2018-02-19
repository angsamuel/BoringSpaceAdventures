using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	Rigidbody rb;
	public float speed = 1;
	float maxOxygen = 301;
	public float oxygen = 301f;
	bool playerUnit;

	public List<Equipment> equipmentList;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame

	void Update(){
		UpdateOxygen ();
	}

	public void UpdateOxygen(){
		if (oxygen > 0) {
			oxygen -= Time.deltaTime;
		} else {
			Die ();
		}
	}

	public void FillOxygen(){
		oxygen = maxOxygen;
	}

	int selectionIndex = 0;
		
	public void UseEquipment(){
		equipmentList [selectionIndex].Use (this);
	}

	void Die(){
		GameObject.Find ("LevelController").GetComponent<LevelController> ();

	}

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

	public string GetOxygenTime(){
		string minutesString = ((int)(oxygen / 60)).ToString();
		int seconds = (int)(oxygen % 60);
		string secondsString = "";
		if (seconds < 10) {
			secondsString = "0" + ((int)seconds).ToString ();
		} else {
			secondsString = ((int)seconds).ToString ();
		}
		return "O2 " +  minutesString + ":" + secondsString;
	}
			

}
