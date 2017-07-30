using UnityEngine;
using System.Collections;

public class GateSys : MonoBehaviour {
	gameSystem GS;
	bool trigger=true;
	// Use this for initialization
	void Start () {
		GS = GameObject.Find ("System").GetComponent<gameSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (trigger) {
				Debug.Log ("passed");
				GS.getFlag++;
				Destroy (gameObject);
				trigger = false;
			}
		}
	}
}
