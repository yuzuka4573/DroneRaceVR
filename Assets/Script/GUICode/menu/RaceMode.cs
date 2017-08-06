using UnityEngine;
using System.Collections;

public class RaceMode : MonoBehaviour {
	public GameObject DrCam;
	gameSystem gs;
	// Use this for initialization
	void Start () {
		gs = GameObject.Find ("System").GetComponent<gameSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GotoRace(){
		GameObject Dr = GameObject.Find ("Drone_test_edited");
		GameObject.Find ("ViewCamera").SetActive(false);
		GameObject.Find ("GUIs/CanvasMenu").SetActive(false);
		//GameObject.Find ("Drone_test_edited").transform.Find ("Main Camera").Enabled = true;
		DrCam.SetActive(true);
		Dr.GetComponent<Camswitch> ().cam = DrCam;
		Dr.GetComponent<Rigidbody>().isKinematic = false;

		gs.isControll = true;
	}
}
