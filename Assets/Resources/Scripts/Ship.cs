using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour {
	LevelController lc;
	public int launchForce = 5000;
	Rigidbody rb;
	Unit playerUnit;

	public string launchDescription;
	public string launchControl;

	CryoPod cryoPod;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerUnit = GameObject.Find ("PlayerUnit").GetComponent<Unit> ();
		lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
		cryoPod = GameObject.Find ("CryoPod").GetComponent<CryoPod> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Launch(){
		StartCoroutine (LaunchRoutine ());
	}

	IEnumerator LaunchRoutine(){
		cryoPod.active = true;
		lc.WriteControl (launchControl);
		lc.WriteDescription (launchDescription);

		playerUnit.GetComponent<PlayerUnitController> ().active = false;

		while (transform.position.y < 350) {
			Debug.Log ("Launching");
			yield return null;
			//rb.AddForce (new Vector3 (0, launchForce, 0));
			rb.velocity = new Vector3(0,30,0);
		}
		rb.velocity = new Vector3 (0, 0, 0);
		rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ
			| RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		playerUnit.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		rb.useGravity = false;
		Debug.Log ("LAUNCH OVER");
		playerUnit.GetComponent<PlayerUnitController> ().active = true;
		lc.WriteDescription ("LAUNCH COMPLETE");
		lc.WriteControl ("proceed to CRYO POD");
		yield return new WaitForSeconds (1f);
		lc.ClearText ();

	}


}
