using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ookanDisp();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ookanDisp(){
		GameObject.Find ("ookan/val").GetComponent<Text>().text = Manager.GetInstans().ResultValue;
		GameObject.Find ("ookan/scoar").GetComponent<Text>().text = Manager.GetInstans().ResultScoar;
		GameObject.Find ("ookan").transform.Find ("king_oukan").gameObject.SetActive (Manager.GetInstans().ResultImage);
		Debug.Log(Manager.GetInstans().ResultValue);
	}
	
}
