using UnityEngine;
using System.Collections;

public class Camswitch : MonoBehaviour {
	public bool camSW = true; //true = normal false =FPV
	GameObject dr;
	GameObject cam;
	// Use this for initialization
	void Start () {
		dr = GameObject.Find ("Drone");
		cam = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("changeCAM")) {
			if (camSW) {
				Debug.Log ("switch to FPV");
				//switch to FPV
				cam.transform.localPosition=new Vector3(0,0,0);
				cam.transform.localEulerAngles = new Vector3 (0, 0, 0);
				dr.SetActive(false);
				camSW=false;
			} else {
				Debug.Log ("switch to normal");
				//switch to normal
				cam.transform.localPosition=new Vector3(0,0.6f,-1.2f);
				cam.transform.localEulerAngles = new Vector3 (30, 0, 0);
				dr.SetActive(true);
				camSW=true;
			}
		
		}
	}
}
