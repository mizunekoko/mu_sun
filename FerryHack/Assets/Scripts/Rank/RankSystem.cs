using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class usersjson{
	public userjson[] users;
}

[System.Serializable]
public class userjson{
	public string rank;
	public string name;
	public string score;
}

public class RankSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(GetRank());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GetRank(){
		WWW request = new WWW("http://172.16.80.7:8080/users/rank/3");
		yield return request;

		if(!string.IsNullOrEmpty(request.error)){
			Debug.Log(request.error);
		}else{
			if(request.responseHeaders.ContainsKey("STATUS") && request.responseHeaders["STATUS"] == "HTTP/1.1 200 OK"){
				string text = request.text;
				byte[] results = request.bytes;
				Debug.Log(text);

				usersjson usj = JsonUtility.FromJson<usersjson>(text);

				GameObject.Find ("sun_1st/name").GetComponent<Text>().text = usj.users[0].name;
				GameObject.Find ("sun_1st/scoar").GetComponent<Text>().text = usj.users[0].score;
				GameObject.Find ("2th/name").GetComponent<Text>().text = usj.users[1].name;
				GameObject.Find ("2th/scoar").GetComponent<Text>().text = usj.users[1].score;
				GameObject.Find ("3nd/name").GetComponent<Text>().text = usj.users[2].name;
				GameObject.Find ("3nd/scoar").GetComponent<Text>().text = usj.users[2].score;
			}
		}
	}

	public void pushBack(){
		SceneManager.LoadScene("Title");
	}
}
