using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayHighScore : MonoBehaviour {

    List<int> Level_1_scores = new List<int>();
    List<int> Level_2_scores = new List<int>();
    List<int> Level_3_scores = new List<int>();
    List<int> Level_4_scores = new List<int>();
    List<int> Level_5_scores = new List<int>();
    List<int> Endless_Level_scores = new List<int>();
	
    // Use this for initialization
	void Start () {
	
	}
	
    void OnGUI()
    {
        string display1 = "Level 1: \n  ";
        string display2 = "Level 2: \n  ";
        string display3 = "Level 3: \n  ";
        string display4 = "Level 4: \n  ";
        string display5 = "Level 5: \n  ";
        string endless_display = "Endless Level: \n  ";

        for(int i = 0; i < 5; i++)
        {
            Level_1_scores.Add(0);
            display1 = display1 + (i + 1) + ": " + Level_1_scores[i] + "\n  ";
            Level_2_scores.Add(0);
            display2 = display2 + (i + 1) + ": " + Level_2_scores[i] + "\n  ";
            Level_3_scores.Add(0);
            display3 = display3 + (i + 1) + ": " + Level_3_scores[i] + "\n  ";
            Level_4_scores.Add(0);
            display4 = display4 + (i + 1) + ": " + Level_4_scores[i] + "\n  ";
            Level_5_scores.Add(0);
            display5 = display5 + (i + 1) + ": " + Level_5_scores[i] + "\n  ";
            Endless_Level_scores.Add(0);
            endless_display = endless_display + (i + 1) + ": " + Endless_Level_scores[i] + "\n  ";

        }

        GUI.color = Color.black;
        GUI.Label(new Rect(20, 120, 400, 500), display1);
        GUI.Label(new Rect(120, 120, 400, 500), display2);
        GUI.Label(new Rect(220, 120, 400, 500), display3);
        GUI.Label(new Rect(320, 120, 400, 500), display4);
        GUI.Label(new Rect(420, 120, 400, 500), display5);
        GUI.Label(new Rect(520, 120, 400, 500), endless_display);
    }
}
