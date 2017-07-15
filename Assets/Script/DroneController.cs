using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour {

	GameObject drone;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		drone = GameObject.Find ("Drone_test_edited");
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//moving
		if (Input.GetAxis("Horizontal") != 0f) {
			rb.AddForce (gameObject.transform.right*15*Input.GetAxis("Horizontal"), ForceMode.Force);
		}
		if (Input.GetAxis("Vertical") != 0f) {
			rb.AddForce (gameObject.transform.forward*15*Input.GetAxis("Vertical"), ForceMode.Force);
		}
		if (Input.GetKey("joystick button 4")) {
			Debug.Log ("Press up");
			rb.AddForce (gameObject.transform.up*20, ForceMode.Force);
		}
		if (Input.GetKey("joystick button 5")) {
			Debug.Log ("Press down");
			rb.AddForce (gameObject.transform.up*-20,  ForceMode.Force);
		}
		if (Input.GetKeyDown("joystick button 8")) {
			Debug.Log("move break");
			rb.drag = 3;
			StartCoroutine (stopMove ());
		}
		if (Input.GetKeyDown("joystick button 9")) {
			Debug.Log("rotate break");
			rb.angularDrag = 3;
			StartCoroutine (stopRotate ());
		}
		if (Input.GetKeyDown ("joystick button 9")) {
			Debug.Log ("Break all");
			rb.angularDrag = 3;
			rb.drag = 3;
			StartCoroutine (stopAll ());
		}
		//camera and drone rotate
		/*
		float inputy = Input.GetAxis ("rotateY");
		rb.rotation = transform.rotation * Quaternion.Euler (0, inputy, 0);
		*/
		if (Input.GetAxis("rotateY") != 0f) {
			Debug.Log ("rotate");
			rb.angularVelocity=new Vector3(0f,Input.GetAxis("rotateY")*1.5f,0f);
		}

	}

	private IEnumerator stopMove(){
		yield return new WaitForSeconds (1);
		rb.velocity = Vector3.zero;
		rb.drag = 0.5F;
		yield break;
	}

	private IEnumerator stopRotate(){
		yield return new WaitForSeconds (1);
		rb.angularVelocity = Vector3.zero;
		rb.angularDrag = 0.5F;
		yield break;
	}

	private IEnumerator stopAll(){
		yield return new WaitForSeconds (1);
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.drag = 0.5F;
		rb.angularDrag = 0.5F;
		yield break;
	}
}
