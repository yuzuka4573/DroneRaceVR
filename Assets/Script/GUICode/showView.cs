using UnityEngine;
using System.Collections;
using TMPro;

public class showView : MonoBehaviour {
	public Camswitch CW;
	public TextMeshProUGUI txt;
	// Use this for initialization
	void Start () {
		txt.text = "";
	}

	// Update is called once per frame
	void Update () {
		if(CW.camSW){
			txt.text = "View : Normal";
		}else{
			txt.text = "View : FPV";
		}
	}
}
