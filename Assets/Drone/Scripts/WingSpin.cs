using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingSpin : MonoBehaviour {
    [SerializeField]
    GameObject[] wings; //ドローンの羽

    public bool isSpinning { get; set; } //羽を回すかどうか
    public float speed = 10; //回転速度
	float nowSpeed =0;
	void Update () {
		if (isSpinning) {
			Spin (wings, speed);

		} else {
			stopSpin (wings);
		}
		//StartCoroutine (fade (isSpinning));
	}

    void Spin(GameObject[] wings, float speed) //wingsをspeedの速度で回転
    {
        foreach (var wing in wings)
        {
            wing.transform.Rotate(0, nowSpeed, 0);
        }
		if (nowSpeed < speed) nowSpeed +=1.0F;
	}


	void stopSpin(GameObject[] wings) //wingsをspeedの速度で回転
	{
		if (nowSpeed > 0) {
			foreach (var wing in wings) {
				wing.transform.Rotate (0, nowSpeed, 0);
			}
			nowSpeed -= 1.0F;
		}
	}

	IEnumerator fade(bool iS){
		if (iS) {
			if (GetComponent<AudioSource>().volume <1){
				GetComponent<AudioSource>().volume = 0;
				GetComponent<AudioSource>().Play();
				for (int i = 0; i < 20; i++)
				{
					GetComponent<AudioSource>().volume += 0.05f;
					yield return new WaitForSeconds(0.1f);
				}
			}
				
		} else {
			if (GetComponent<AudioSource>().volume > 0){
				GetComponent<AudioSource>().Play();
				for (int i = 0; i < 20; i++)
				{
					GetComponent<AudioSource>().volume -= 0.05f;
					yield return new WaitForSeconds (0.1F);
				}
			}
		}
		yield break;
	}
}
