using UnityEngine;
using System.Collections; 

public class ChangeScene : MonoBehaviour {

	private static string prevScene;

	public void ChangeToScene (string sceneToChangeTo){ 
		if (sceneToChangeTo == "prevScene") {
			Application.LoadLevel (getPrevLevel ());
		} 
		else {
			Application.LoadLevel (sceneToChangeTo); 
			setPrevLevel (sceneToChangeTo);
		} 
	}

	public static void setPrevLevel(string level){
		prevScene = level; 
	}

	public static string getPrevLevel(){
		return prevScene; 
	}
}
