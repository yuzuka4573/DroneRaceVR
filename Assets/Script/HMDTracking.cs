using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class HMDTracking : MonoBehaviour {
	GameObject dr; //myself
	public Quaternion direction; //HMD rotation data;
	// Use this for initialization
	void Start () {
		//get myself
		dr = GameObject.Find ("Drone_test_edited");
	}
	
	// Update is called once per frame
	void Update () {
		//collect data from HMD
		direction = InputTracking.GetLocalRotation (VRNode.Head);

		// front
		if (-0.25f <= direction [1] && direction [1] < 0.25f) {
			Debug.Log ("center");
			// back
		} else if (direction [1] <= -0.75f || 0.75f <= direction [1]) {
			Debug.Log ("back");
			// left
		} else if (0.25f <= direction [1] && direction [1] < 0.75f) {
			if (direction [3] < 0) {
				Debug.Log ("left");
			}else{
				Debug.Log ("right");
			}
			// ringht
		} else if (-0.75f <= direction [1] && direction [1] < -0.25f) {
			if (direction [3] < 0) {
				Debug.Log ("right");
			}else{
				Debug.Log ("left");
			}
		}
		//rotate
		dr.transform.rotation = Quaternion.Euler(0,direction[1],0);
	}
}
