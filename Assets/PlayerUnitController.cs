using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : MonoBehaviour {
	Unit unit;
	public bool active = true;
	LevelController lc;

	// Use this for initialization
	void Start () {
		lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
		unit = GetComponent<Unit> ();
		lc.oxygenText.color = Color.clear;
	}
	
	void Update () {
			ScanInput ();
	}

	bool canJump = true;
	void ScanInput(){
		if (active) {

			if (Input.GetAxisRaw ("Stats") != 0) {
				lc.oxygenText.color = Color.white;
			} else {
				lc.oxygenText.color = Color.clear;
			}


			if(Input.GetAxisRaw ("UseEquipment") != 0){
				unit.UseEquipment ();
				Debug.Log ("pressed");
			}

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

}
