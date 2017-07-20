using UnityEngine;
using System.Collections;
using TMPro;

public class SpeedMater : MonoBehaviour {
	public GameObject Dr;
	public TextMeshProUGUI txt;
	// Use this for initialization
	void Start () {
		Dr = GameObject.Find ("Drone_test_edited");
		txt.text = "";
	}

	// Update is called once per frame
	void Update () {
		txt.text = "Rotate : " + Dr.GetComponent<Rigidbody> ().angularVelocity.magnitude.ToString ("F2");
			
	}
}
