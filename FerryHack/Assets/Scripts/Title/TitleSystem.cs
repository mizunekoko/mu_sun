using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSystem : MonoBehaviour {
	private Vector2 _vec;
	private float _time;
	private GameObject _startButton;

	private const int SECOND = 1;       //1分
	private const float ERROR = 0.1f;  //誤差(許容範囲)

	void Start(){
		_startButton = GameObject.Find ("Canvas/Button/Text");
	}

	// Update is called once per frame
	void Update () {
		_time += 1 * Time.deltaTime;

		if(_time >= SECOND / 2){  //0.5秒ごとに角度の計算
			_vec.x = Input.acceleration.x;
			_vec.y = Input.acceleration.y;
			_time = 0;
		}
	}

	public void StartButton(){
		if (_vec.x <= ERROR && _vec.x >= -ERROR && _vec.y <= ERROR && _vec.y >= -ERROR) {  //水平距離が許容範囲以内だったら
			//Mainへ移動する
			SceneManager.LoadScene("Main");

			//ゲーム開始時の水平ベクトルを取得する。
			Manager.GetInstans().GyroVector = _vec;

		} else {  //水平にしてくださいという文字をだす
			_startButton.GetComponent<Text>().text = "水平に持ってください";
			_startButton.GetComponent<Text> ().fontSize = 40;

		}
	}
}
