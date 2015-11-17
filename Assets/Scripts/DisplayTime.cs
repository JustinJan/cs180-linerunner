using UnityEngine;
using System.Collections;

public class DisplayTime : MonoBehaviour
{
	
	public int playtime = 0; 
	private int seconds = 0; 
	private int minutes = 0; 
	private bool timeVisible = true; 

	void Start(){
		StartCoroutine ("PlayTimer");
	}

	private IEnumerator PlayTimer(){
		while (true) {
			yield return new WaitForSeconds (1); 
			playtime += 1;
			seconds = (playtime % 60); 
			minutes = (playtime / 60) % 60; 
		}

	}

	void OnGUI(){
		GUI.color = Color.gray; 
		GUI.skin.box.fontStyle = FontStyle.Bold;
		GUI.skin.label.fontSize = 20;
		string text = string.Format ("{0:00}:{1:00}", minutes, seconds);
		GUI.Label(new Rect(50, 20, 400, 50), text);
	}

}