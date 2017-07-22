using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class DroneController : MonoBehaviour {

	GameObject drone;
	Rigidbody rb;
	public int speedval = 30;
	public int UDval = 100;
	public float rotateval=1.5f;
	public float LCRval = 0f;
	public float RCRval = 0f;
	// Use this for initialization
	void Start () {
		drone = GameObject.Find ("Drone_test_edited");
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//moving
		//x and z section
		if (Input.GetAxis ("Horizontal") != 0f) {
			rb.AddForce (gameObject.transform.right * speedval * Input.GetAxis ("Horizontal"), ForceMode.Force);
		}
		if (Input.GetAxis ("Vertical") != 0f) {
			rb.AddForce (gameObject.transform.forward * speedval * Input.GetAxis ("Vertical"), ForceMode.Force);
		}

		// y section
		if (Input.GetKey ("joystick button 4") || Input.GetKey (KeyCode.Space)) {
			Debug.Log ("Press up");
			rb.AddForce (gameObject.transform.up * UDval, ForceMode.Force);
		}
		if (SceneManager.GetActiveScene ().name != "Hardmode") {

			if (Input.GetKey ("joystick button 5") || Input.GetKey ("c")) {
				Debug.Log ("Press down");
				rb.AddForce (gameObject.transform.up * -UDval, ForceMode.Force);
			}
		}
		//break section
		if (Input.GetKeyDown("joystick button 8")||Input.GetKey("i")) {
			Debug.Log("move break");
			rb.drag = 3;
			StartCoroutine (stopMove ());
		}
		if (Input.GetKeyDown("joystick button 9") ||Input.GetKey ("k")) {
			Debug.Log("rotate break");
			rb.angularDrag = 3;
			StartCoroutine (stopRotate ());
		}
		//rotation
		if (Input.GetAxis("rotateY") != 0f) {
			Debug.Log ("rotate");
			rb.angularVelocity=new Vector3(0f,Input.GetAxis("rotateY")*rotateval,0f);
		}
		if (Input.GetKey ("j")) {
			Debug.Log ("rotate");
			if(LCRval<rotateval)LCRval += 0.01f;
			if (RCRval > 0)RCRval -= 0.01f;
			rb.angularVelocity = new Vector3 (0f, -1 * (LCRval-RCRval), 0f);
		} else if (Input.GetKey ("l")) {
			Debug.Log ("rotate");
			if(RCRval<rotateval)RCRval += 0.01f;
			if (LCRval > 0)LCRval -= 0.01f;
			rb.angularVelocity = new Vector3 (0f, (RCRval-LCRval), 0f);
		} else {
			if (LCRval > 0)LCRval -= 0.01f;
			if (RCRval > 0)RCRval -= 0.01f;
		}

		/*if (Input.GetKeyDown ("joystick button 9")) {
			Debug.Log ("Break all");
			rb.angularDrag = 3;
			rb.drag = 3;
			StartCoroutine (stopAll ());
		}*/
		//camera and drone rotate
		/*
		float inputy = Input.GetAxis ("rotateY");
		rb.rotation = transform.rotation * Quaternion.Euler (0, inputy, 0);
		*/
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
