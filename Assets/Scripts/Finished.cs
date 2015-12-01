using UnityEngine;
using System.Collections;

public class Finished : MonoBehaviour {

	void OnGUI()
	{
		string message = "Highest Score for this level: " + DisplayHighScore.return_highscore();
		message = message + "\n Your score: " + DisplayHighScore.format(DisplayTime.playtime - 10);
		message = message + "\n Your total amount of coins: " + coinScript.coins;

		GUI.color = Color.black;
		GUI.Label(new Rect(150, 120, 400, 500), message);
	}
}
