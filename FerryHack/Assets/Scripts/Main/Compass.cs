using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		Input.compass.enabled = true;  //コンパスを起動する。
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localRotation = Quaternion.Euler( new Vector3(0, 0, Input.compass.magneticHeading));
	}
}
