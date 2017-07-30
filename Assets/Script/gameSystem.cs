using UnityEngine;
using System.Collections;

public class gameSystem : MonoBehaviour {
	public int flagAll=26;
	public int getFlag=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//



		//exit game 
		if (Input.GetButtonDown ("End"))
			Application.Quit ();
	}
}
