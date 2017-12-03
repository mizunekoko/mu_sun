using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager{

	private Vector2 _GyroVector;

	private string _ResultValue;
	private string _ResultScoar;
	private bool _ResultImage;


	public Vector2 GyroVector{get{ return _GyroVector;} set{ _GyroVector = value; } }
	
	public string ResultValue{get{ return _ResultValue;} set{ _ResultValue = value; } }
	public string ResultScoar{get{ return _ResultScoar;} set{ _ResultScoar = value; } }
	public bool ResultImage{get{ return _ResultImage;} set{ _ResultImage = value; } }


	public static Manager _singleton;
	public static Manager GetInstans(){
		return _singleton ?? (_singleton = new Manager());
	}

}
