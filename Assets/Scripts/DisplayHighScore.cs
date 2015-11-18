using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class DisplayHighScore : MonoBehaviour {

    List<String> Level_1_scores = new List<String>();
    List<String> Level_2_scores = new List<String>();
    List<String> Level_3_scores = new List<String>();
    List<String> Level_4_scores = new List<String>();
    List<String> Level_5_scores = new List<String>();
    List<String> Level_endless_scores = new List<String>();

    int new_score;
	
    // Use this for initialization
	void Start () {
        intialize();
	}

    void intialize()
    {
        string line;
        string path = System.IO.Directory.GetCurrentDirectory();
        //System.IO.StreamReader file1 = new System.IO.StreamReader(@path + "\\Assets\\Scripts\\Level1_hs.txt");
        //System.IO.StreamReader file2 = new System.IO.StreamReader(@path + "\\Assets\\Scripts\\Level2_hs.txt");
        //System.IO.StreamReader file3 = new System.IO.StreamReader(@path + "\\Assets\\Scripts\\Level3_hs.txt");
        //System.IO.StreamReader file4 = new System.IO.StreamReader(@path + "\\Assets\\Scripts\\Level4_hs.txt");
        //System.IO.StreamReader file5 = new System.IO.StreamReader(@path + "\\Assets\\Scripts\\Level5_hs.txt");
        //System.IO.StreamReader file_endless = new System.IO.StreamReader(@path + "\\Assets\\Scripts\\Level_endless_hs.txt");

        System.IO.StreamReader file1 = new System.IO.StreamReader(@path + "/Assets/Scripts/Level1_hs.txt");
        System.IO.StreamReader file2 = new System.IO.StreamReader(@path + "/Assets/Scripts/Level2_hs.txt");
        System.IO.StreamReader file3 = new System.IO.StreamReader(@path + "/Assets/Scripts/Level3_hs.txt");
        System.IO.StreamReader file4 = new System.IO.StreamReader(@path + "/Assets/Scripts/Level4_hs.txt");
        System.IO.StreamReader file5 = new System.IO.StreamReader(@path + "/Assets/Scripts/Level5_hs.txt");
        System.IO.StreamReader file_endless = new System.IO.StreamReader(@path + "/Assets/Scripts/Level_endless_hs.txt");

        while((line = file1.ReadLine()) != null)
        {
            Level_1_scores.Add(line);
        }

        while ((line = file2.ReadLine()) != null)
        {
            Level_2_scores.Add(line);
        }
        
        while ((line = file3.ReadLine()) != null)
        {
            Level_3_scores.Add(line);
        }

        while ((line = file4.ReadLine()) != null)
        {
            Level_4_scores.Add(line);
        }

        while ((line = file5.ReadLine()) != null)
        {
            Level_5_scores.Add(line);
        }

        while ((line = file_endless.ReadLine()) != null)
        {
            Level_endless_scores.Add(line);
        }

        file1.Close();
        file2.Close();
        file3.Close();
        file4.Close();
        file5.Close();
        file_endless.Close();
    }
	
    void insert_Score(int level)
    {

    }

    void OnGUI()
    {
        string display1 = "Level 1: \n ";
        string display2 = "Level 2: \n ";
        string display3 = "Level 3: \n ";
        string display4 = "Level 4: \n ";
        string display5 = "Level 5: \n ";
        string endless_display = "Endless Level: \n ";

        for (int i = 0; i < Level_1_scores.Count; i++)
        {
            display1 = display1 + (i + 1) + ": " + Level_1_scores[i] + "\n ";
            display2 = display2 + (i + 1) + ": " + Level_2_scores[i] + "\n ";
            display3 = display3 + (i + 1) + ": " + Level_3_scores[i] + "\n ";
            display4 = display4 + (i + 1) + ": " + Level_4_scores[i] + "\n ";
            display5 = display5 + (i + 1) + ": " + Level_5_scores[i] + "\n ";
            endless_display = endless_display + (i + 1) + ": " + Level_endless_scores[i] + "\n ";
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
