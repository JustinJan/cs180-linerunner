using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Rigidbody2D playerbody;

	// Use this for initialization
	void Start () {
		playerbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		playerbody.velocity = new Vector2 (speed, playerbody.velocity.y);
	}
}
