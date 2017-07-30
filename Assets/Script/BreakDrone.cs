using UnityEngine;
using System.Collections;

public class BreakDrone : MonoBehaviour {
	public GameObject Dr;
	public GlitchFx gfx;
	public float Damval = 6f;
	// Use this for initialization
	void Start () {
		/*Dr = GameObject.Find ("Drone_text_edited");
		gfx = GameObject.Find ("Main Camera").GetComponent<GlitchFx> ();*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("CHECK");
		Debug.Log ("Speed : "+Dr.GetComponent<Rigidbody> ().velocity.magnitude);
		if (Dr.GetComponent<Rigidbody> ().velocity.magnitude > Damval) {
			Debug.Log ("CHECK TRUE");
			if (other.tag == "building" || other.tag == "ground"||other.tag == "object") {
				Debug.Log ("HIT!");
				StartCoroutine (noise ());
			}
		}
	}

	IEnumerator noise(){
		Dr.GetComponent<Rigidbody> ().freezeRotation = false;
		Dr.GetComponent<DroneController> ().isControl = false;

		for(int c =0;c<50;c++){
			yield return new WaitForSeconds(0.1f);
			gfx.intensity += 0.05f;
		}

		Dr.GetComponent<DroneController> ().resetPos ();
		yield return new WaitForSeconds(0.1f);
		Dr.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		Dr.GetComponent<DroneController> ().isControl = true;
		gfx.intensity =0;
		yield break;
	}
}

