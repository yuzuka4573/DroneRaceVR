using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float allsecond = 0;
	public int minute = 0;
	public int second = 0;
	public bool isWorking=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isWorking) {
			allsecond += Time.deltaTime;
			minute = (int)allsecond / 60;
			second = (int)allsecond - (minute * 60);
		}
	}
	void resetTime(){
		Debug.Log ("reset Timer");
		allsecond = 0;
		minute = 0;
		second = 0;
	}
}
