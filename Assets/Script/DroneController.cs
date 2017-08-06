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
	gameSystem gs;
	Vector3 initPos;
	Quaternion initRot;
	// Use this for initialization
	void Start () {
		
		drone = GameObject.Find ("Drone_test_edited");
		rb = GetComponent<Rigidbody>();
		initPos = gameObject.transform.position;
		initRot = gameObject.transform.rotation;
		gs = GameObject.Find ("System").GetComponent<gameSystem> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gs.isControll) {
			//moving
			//x and z section
			if (Input.GetAxis ("Horizontal") != 0f) {
				rb.AddForce (gameObject.transform.right * speedval * Input.GetAxis ("Horizontal"), ForceMode.Force);
			}

			if (Input.GetAxis ("Vertical") != 0f) {
				rb.AddForce (gameObject.transform.forward * speedval * Input.GetAxis ("Vertical"), ForceMode.Force);
			}

			// y section
			if (Input.GetButton ("Drone_UP")) {
				Debug.Log ("Press up");
				rb.AddForce (gameObject.transform.up * UDval, ForceMode.Force);
			}

			//if (SceneManager.GetActiveScene ().name != "Hardmode") {

			if (Input.GetButton ("Drone_Down")) {
					Debug.Log ("Press down");
				rb.AddForce (gameObject.transform.up * -(UDval-20), ForceMode.Force);
				}
		//	}
			//break section
			if (Input.GetButton ("Move_break")) {
				Debug.Log ("move break");
				rb.drag = 3;
				StartCoroutine (stopMove ());
			}

			if (Input.GetButton ("Rotate_break")) {
				Debug.Log ("rotate break");
				rb.angularDrag = 3;
				StartCoroutine (stopRotate ());
			}

			//rotation
			if (Input.GetAxis ("rotateY") != 0f) {
				Debug.Log ("rotate");
				if (Input.GetAxis ("rotateY") < 0) {
					if (LCRval < rotateval)
						LCRval += 0.05f;
					if (RCRval > 0)
						RCRval -= 0.05f;
					rb.angularVelocity = new Vector3 (0f, -1 * (LCRval - RCRval), 0f);
				} else if (Input.GetAxis ("rotateY") > 0) {
					if (RCRval < rotateval)
						RCRval += 0.05f;
					if (LCRval > 0)
						LCRval -= 0.05f;
					rb.angularVelocity = new Vector3 (0f, (RCRval - LCRval), 0f);
				}

			}else if (Input.GetButton ("Keyboard_rotateLeft")||Input.GetButton ("Keyboard_rotateRight")) {
				Debug.Log ("rotate button");
				if (Input.GetButton ("Keyboard_rotateLeft")) {
					if (LCRval < rotateval)
						LCRval += 0.05f;
					if (RCRval > 0)
						RCRval -= 0.05f;
					rb.angularVelocity = new Vector3 (0f, -1 * (LCRval - RCRval), 0f);
				} else if (Input.GetButton ("Keyboard_rotateRight")) {
					if (RCRval < rotateval)
						RCRval += 0.05f;
					if (LCRval > 0)
						LCRval -= 0.05f;
					rb.angularVelocity = new Vector3 (0f, (RCRval - LCRval), 0f);
				}

			}else {
				if (LCRval > 0)
					LCRval -= 0.05f;
				if (RCRval > 0)
					RCRval -= 0.05f;
			}

		}

	}

	private IEnumerator stopMove(){
		yield return new WaitForSeconds (0.05f);
		rb.velocity = Vector3.zero;
		rb.drag = 0.5F;
		yield break;
	}

	private IEnumerator stopRotate(){
		yield return new WaitForSeconds (0.05f);
		rb.angularVelocity = Vector3.zero;
		rb.angularDrag = 0.5F;
		LCRval = 0;
		RCRval = 0;
		yield break;
	}

	private IEnumerator stopAll(){
		yield return new WaitForSeconds (0.05f);
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.drag = 0.5F;
		rb.angularDrag = 0.5F;
		LCRval = 0;
		RCRval = 0;
		yield break;
	}
	public void resetPos(){
		transform.position=initPos;
		transform.rotation=initRot;
	}
}
