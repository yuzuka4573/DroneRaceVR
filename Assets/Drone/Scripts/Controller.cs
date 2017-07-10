using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<WingSpin>().isSpinning = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("z"))
        {
            GetComponent<WingSpin>().isSpinning = true;
        }
        if (Input.GetKeyDown("x"))
        {
            GetComponent<WingSpin>().isSpinning = false;
        }
    }
	void OnTriggerEnter(Collider other) {

		if (other.tag == "ground") {
			GetComponent<WingSpin> ().isSpinning = false;
		} 

	}
	void OnTriggerExit(Collider other) {

		if (other.tag == "ground") {
			GetComponent<WingSpin> ().isSpinning = true;
		} 

	}

}
