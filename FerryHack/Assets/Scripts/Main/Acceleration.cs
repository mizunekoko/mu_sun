using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Acceleration : MonoBehaviour {
	private float _speed;
	private Vector2 _vec;
	private Vector2 _first_pos;
	private GameObject _goal_pos;
	private GameObject _child;
	public GameObject _text;
	private float _pa_sent;
	private float _goukei;
	private float _mas;
	private float _time;

	private int _score;

	// Use this for initialization
	void Start () {
		_speed = 0.5f;
		_vec = Vector2.zero;
		_first_pos = this.transform.position;
		_child =  transform.Find ("Goal").gameObject;
		_score = 1000;
		_time = 0;

	}
	
	// Update is called once per frame
	void Update () {

		var dir = Vector3.zero;
		dir.x = Input.acceleration.y;

		_time += Time.deltaTime * 1;

		if(dir.sqrMagnitude > 1){
			dir.Normalize();
		}

		if(_time >= 1){
			if(_score >= 0){
				_score -= 1;
				Manager.GetInstans ().ResultScoar = _score.ToString();
				Manager.GetInstans ().ResultValue = "maei";
				Manager.GetInstans ().ResultImage = true;
			}
			_time = 0;
		}

		dir *= Time.deltaTime;
		transform.Translate(dir * _speed);

		_mas = Mathf.Abs(_first_pos.x - _child.transform.position.x);

		var susumi = Mathf.Abs(this.transform.position.x-_first_pos.x);

		var sintyoku = susumi / _mas;


		//if (sintyoku % 10 == 0) {
		_text.GetComponent<Text> ().text = Mathf.Floor(sintyoku).ToString ();
		//}
	}
}
