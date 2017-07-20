using UnityEngine;
using System.Collections;
using TMPro;

public class RotateMater : MonoBehaviour {
	public GameObject Dr;
	public TextMeshProUGUI txt;
	// Use this for initialization
	void Start () {
		Dr = GameObject.Find ("Drone_test_edited");
		txt.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Speed : " + Dr.GetComponent<Rigidbody>().velocity.magnitude.ToString("F2");
	}
}
