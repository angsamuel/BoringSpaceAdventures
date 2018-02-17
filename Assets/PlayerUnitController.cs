using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : MonoBehaviour {
	Unit unit;
	public bool active = true;
	// Use this for initialization
	void Start () {
		unit = GetComponent<Unit> ();
	}
	
	void Update () {
		if (active) {
			ScanInput ();
		}
	}

	bool canJump = true;
	void ScanInput(){
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			unit.MoveLeft ();
		}

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			unit.MoveRight ();
		}

		if (Input.GetAxisRaw ("Horizontal") == 0) {
			unit.StopHorz ();
		}

		if (Input.GetAxisRaw ("Vertical") < 0) {
			unit.MoveDown ();
		}

		if (Input.GetAxisRaw ("Vertical") > 0) {
			unit.MoveUp ();
		}

		if (Input.GetAxisRaw ("Vertical") == 0) {
			unit.StopVert ();
		}
		if (Input.GetAxisRaw ("Jump") != 0) {
			if (canJump) {
				unit.Jump ();
				Debug.Log ("JUMPED");
				canJump = false;
			}
		} else if (Input.GetAxisRaw ("Jump") == 0) {
			canJump = true;
		}

	}
}
