using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
	public Sprite[] _sun;
	private int _state;
	private Vector2 _standard_position;
	private Vector2 _pos;
	private float _time;
	private Vector2 _vec;

	private const int NORMAL = 0;  //普通
	private const int LITTLEDANGER = 1;  //少し危険
	private const int OUT = 2;     //終了
	private const int SECOND = 1;       //1分


	// Use this for initialization
	void Start () {
		_state = 0;
		_standard_position = Manager.GetInstans ().GyroVector;

	}

	// Update is called once per frame
	void Update () {
		_time += 1 * Time.deltaTime;

		if (_time >= SECOND / 2) {  //0.5秒ごとに角度の計算
			this.Gyro();
			this.SunTranslation ();
			_time = 0;
		}
	}


	void SunTranslation(){
		_state = 0;

		if(0.3f >= _vec.x & _vec.x >= -0.3f){
			
		}else if(0.5f >= _vec.x & _vec.x > -0.5f){
			_state = 1;
		}else{
			_state = 2;
		}

		if (0.3f >= _vec.y & _vec.y >= -0.3f) {

		} else if (0.5f >= _vec.y & _vec.y > -0.5 & _state != 2) {
			_state = 1;
		} else {
			_state = 2;
		}

		this.transform.GetComponent<SpriteRenderer>().sprite = _sun[_state];

	}

	void Gyro(){
		_vec.x = Input.acceleration.x;
		_vec.y = Input.acceleration.y;
	}
}
