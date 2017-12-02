using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyro : MonoBehaviour {
	public Vector2 _vec;
	public float _time;

	const int SECOND = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_time += 1 * Time.deltaTime;

		if(_time >= SECOND){
			_vec.x = Input.acceleration.x;
			_vec.y = Input.acceleration.y;
			_time = 0;
		}

	}
}
