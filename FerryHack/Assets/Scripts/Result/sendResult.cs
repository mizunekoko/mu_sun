using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using JsonUtility.FromJson;

public class sendResult : MonoBehaviour {

	private float _time;
	const int SECOND = 1;

[System.Serializable]
public class markjson{
	public string point_id;
	public string user_id;
}

	// Use this for initialization
	void Start () {
		
		if(Manager.GetInstans().ResultValue == null){
			Manager.GetInstans().ResultValue = "";
			Manager.GetInstans().ResultScoar = "";
			Manager.GetInstans().ResultImage = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		_time += 1 * Time.deltaTime;
		if(_time >= SECOND / 2){  
			StartCoroutine(GetText());
		}
	}

	IEnumerator GetText(){
		WWW request = new WWW("http://localhost:8888/package2.json");
		yield return request;

		if(!string.IsNullOrEmpty(request.error)){
			Debug.Log(request.error);
		}else{
			if(request.responseHeaders.ContainsKey("STATUS") && request.responseHeaders["STATUS"] == "HTTP/1.1 200 OK"){
				string text = request.text;
				byte[] results = request.bytes;
				Debug.Log(text);

				markjson mj = JsonUtility.FromJson<markjson>(text);

				Debug.Log(string.Format("{0}:{1}",mj.point_id,mj.user_id));
			}
		}
	}

	public void puahButton1(){
		Manager.GetInstans().ResultValue = "ざんねん";
		Manager.GetInstans().ResultScoar = "3:00.00";
		Manager.GetInstans().ResultImage = false;
		SceneManager.LoadScene("Result");

	}

	public void puahButton2(){
		Manager.GetInstans().ResultValue = "もうひとがんばり";
		Manager.GetInstans().ResultScoar = "2:00.00";
		Manager.GetInstans().ResultImage = false;
		SceneManager.LoadScene("Result");
	}

	public void puahButton3(){
		Manager.GetInstans().ResultValue = "おめでとう";
		Manager.GetInstans().ResultScoar = "1:30.00";
		Manager.GetInstans().ResultImage = true;
		SceneManager.LoadScene("Result");
	}
}
