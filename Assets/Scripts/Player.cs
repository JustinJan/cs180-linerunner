using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpspeed;
	private Rigidbody2D playerbody;
	Animator anim;

	// Use this for initialization
	void Start () {
		playerbody = GetComponent<Rigidbody2D>();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerbody.position.y <= 2)
			anim.SetFloat("Speed", 0);
		else {
			anim.SetFloat("Speed", 1);
		}
		playerbody.velocity = new Vector2 (speed, playerbody.velocity.y);
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetFloat("Speed", 1);
			playerbody.velocity = new Vector2 (playerbody.velocity.x, jumpspeed);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle") {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
