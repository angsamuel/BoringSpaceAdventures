using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bullet;
	public GameObject casing;
	public GameObject bulletSpawner;
	public GameObject casingSpawner;
	public float fireDelay;
	public float bulletSpeed;
	public float casingSpeed;
	bool canFire = true;
	Vector3 myTarget;

	List<GameObject> bulletPool;
	List<GameObject> shellPool;
	int poolSize = 10;
	// Use this for initialization
	void Start () {
		bulletPool = new List<GameObject> ();
		shellPool = new List<GameObject> ();
		myTarget = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator BulletWait(){
		canFire = false;
		yield return new WaitForSeconds (fireDelay);
		canFire = true;

	}
	float aimSpeed = 100;
	virtual public void Aim(Vector3 target){
		myTarget = target;
		Debug.Log (myTarget);
		Quaternion nRotation = Quaternion.LookRotation (Vector3.forward, target - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, nRotation, Time.deltaTime * aimSpeed);
	}

	int fireIndex = 0;
	public void Shoot(){
		if (canFire) {
			if (bulletPool.Count < poolSize) {
				GameObject nb = Instantiate (bullet, bulletSpawner.transform.position, Quaternion.identity);
				nb.GetComponent<Rigidbody> ().velocity = new Vector3 (bulletSpeed, 0, 0);

				bulletPool.Add (nb);

				GameObject ns = Instantiate (casing, casingSpawner.transform.position, Quaternion.identity);
				ns.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, casingSpeed); 
				shellPool.Add (ns);
			} else {
				bulletPool [0].transform.position = bulletSpawner.transform.position;
				bulletPool [0].GetComponent<Rigidbody> ().velocity = new Vector3 (bulletSpeed, 0, 0);
				bulletPool.Add (bulletPool [0]);
				bulletPool.RemoveAt (0);
				bulletPool [0].transform.rotation = Quaternion.identity;

				shellPool [0].transform.position = casingSpawner.transform.position;
				shellPool [0].GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -casingSpeed); 
				shellPool.Add (shellPool [0]);
				shellPool.RemoveAt (0);
				shellPool [0].transform.rotation = Quaternion.identity;
			}
			StartCoroutine (BulletWait ());

		}
	}
}
