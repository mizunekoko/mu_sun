using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager{

	private Vector2 _GyroVector;

	public Vector2 GyroVector{get{ return _GyroVector;} set{ _GyroVector = value; } }


	public static Manager _singleton;
	public static Manager GetInstans(){
		return _singleton ?? (_singleton = new Manager());
	}

}
