using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpspeed;
	private Rigidbody2D playerbody;

	// Use this for initialization
	void Start () {
		playerbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		playerbody.velocity = new Vector2 (speed, playerbody.velocity.y);
		if (Input.GetKeyDown (KeyCode.Space)) {
			playerbody.velocity = new Vector2 (playerbody.velocity.x, jumpspeed);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle") {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
