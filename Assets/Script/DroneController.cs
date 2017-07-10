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
	void Update () {
		if (Input.GetAxis("Horizontal") != 0f) {
			rb.AddForce (0,0,-5*Input.GetAxis("Horizontal"), ForceMode.Force);
		}
		if (Input.GetAxis("Vertical") != 0f) {
			rb.AddForce (5*Input.GetAxis("Vertical"),0,0, ForceMode.Force);
		}
		if (Input.GetKeyDown("Up")) {
			rb.AddForce (0,10*Input.GetAxis("Vertical"),0, ForceMode.Force);
		}
		if (Input.GetKeyDown("Down")) {
			rb.AddForce (0,-10*Input.GetAxis("Vertical"),0,  ForceMode.Force);
		}
		if (Input.GetKeyDown("Break")) {
			rb.drag = 3;
			StartCoroutine (Sleep ());
		}
	}
	private IEnumerator Sleep(){
		yield return new WaitForSeconds (1);
		rb.velocity = Vector3.zero;
		rb.drag = 0.5F;
		yield break;
	}
}
