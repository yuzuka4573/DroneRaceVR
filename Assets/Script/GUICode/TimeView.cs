using UnityEngine;
using System.Collections;
using TMPro;

public class TimeView : MonoBehaviour {
	public Timer tm;
	public TextMeshProUGUI txt;
	// Use this for initialization
	void Start () {
		txt.text = "00:00";
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = tm.minute.ToString ("00") + ":" + tm.second.ToString ("00");
	}
}
