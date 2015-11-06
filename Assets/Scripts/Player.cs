using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpspeed;
	private Rigidbody2D playerbody;
	private bool holdjump;
<<<<<<< HEAD
	private Vector3 spawnPoint;
	Animator anim;
=======
	public AudioClip jumpsound;
>>>>>>> d3a20c4486b7a5922ad04366b2ea792b4e755a4c
	//private float distToGround;

	// Use this for initialization
	void Start () {
		spawnPoint = transform.position;
		playerbody = GetComponent<Rigidbody2D>();
		//distToGround = GetComponent<Collider2D>().bounds.extents.y;
		holdjump = false;
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerbody.velocity = new Vector2 (speed, playerbody.velocity.y);

		if(playerbody.position.y <= .03)
			anim.SetFloat("Speed", 0);
		else 
			anim.SetFloat("Speed", 1);


		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetFloat("Speed", 1);
			if(isGrounded ()){
			    playerbody.velocity = new Vector2 (playerbody.velocity.x, jumpspeed);
				AudioSource.PlayClipAtPoint(jumpsound, this.transform.position);
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
			anim.SetFloat("Speed", 0);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
//		if (other.tag == "Obstacle") {
//			Application.LoadLevel (Application.loadedLevel);
//		}
		transform.position = spawnPoint;
	}

	bool isGrounded(){
		if (playerbody.velocity.y == 0) {
			return true;
		} else {
			return false;
		}
	}
}
