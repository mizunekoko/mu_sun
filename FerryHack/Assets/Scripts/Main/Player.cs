using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Goal"){
			SceneManager.LoadScene("Result");
		}
	}

}
