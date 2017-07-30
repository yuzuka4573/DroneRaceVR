using UnityEngine;
using System.Collections;

public class GateSpwan : MonoBehaviour {
	public GameObject obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Instantiate(obj, this.transform.position, Quaternion.identity);
	}
}
