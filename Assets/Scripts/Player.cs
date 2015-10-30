using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpspeed;
	private Rigidbody2D playerbody;
	private bool holdjump;
	//private float distToGround;

	// Use this for initialization
	void Start () {
		playerbody = GetComponent<Rigidbody2D>();
		//distToGround = GetComponent<Collider2D>().bounds.extents.y;
		holdjump = false;
	}
	
	// Update is called once per frame
	void Update () {
		playerbody.velocity = new Vector2 (speed, playerbody.velocity.y);
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(isGrounded ()){
			    playerbody.velocity = new Vector2 (playerbody.velocity.x, jumpspeed);
				holdjump = true;
			}
		}
		if (holdjump) {
			if(playerbody.velocity.y < 0){
				playerbody.gravityScale = 3;
				Debug.Log ("test");
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			playerbody.gravityScale = 18;
			holdjump = false;
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			//transform.position = new Vector3(transform.position.x, .1f, 0);
			transform.localScale = new Vector3(transform.localScale.x, .5f, 0);
			playerbody.gravityScale = 22;
		}
		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			//transform.position = new Vector3(transform.position.x, .5f, 0);
			transform.localScale = new Vector3(transform.localScale.x, 1f, 0);
			playerbody.gravityScale = 18;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle") {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	bool isGrounded(){
		if (playerbody.velocity.y == 0) {
			return true;
		} else {
			return false;
		}
	}
}
