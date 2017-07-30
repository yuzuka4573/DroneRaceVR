using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {
	Button FM;
	Button RM;
	Button EX;

	void Start () {
		// ボタンコンポーネントの取得
		FM     = GameObject.Find ("/GUIs/CanvasMenu/Free Mode").GetComponent<Button> ();
		RM   = GameObject.Find ("/GUIs/CanvasMenu/Race Mode").GetComponent<Button> ();
		EX = GameObject.Find ("/GUIs/CanvasMenu/Exit").GetComponent<Button> ();

		// 最初に選択状態にしたいボタンの設定
		FM.Select ();
	}
}