using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class markjson{
	public string rank;
	public string user_id;
	public string scoar;
}

public class RankSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Get1(){
		WWW request = new WWW("http://localhost:8888/package3.json");
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
				GameObject.Find ("ookan/val").GetComponent<Text>().text = Manager.GetInstans().ResultValue;
				GameObject.Find ("ookan/scoar").GetComponent<Text>().text = Manager.GetInstans().ResultScoar;
			}
		}
	}

	public void pushBack(){
		SceneManager.LoadScene("Title");
	}
}
