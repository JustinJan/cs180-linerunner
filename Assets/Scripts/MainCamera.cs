using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x+10, 3, -1f);
	}
}
