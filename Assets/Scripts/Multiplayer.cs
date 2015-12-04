﻿using UnityEngine;
using System.Collections;
//using playerNamespace;
using UnityEngine.Networking;

public class Multiplayer : NetworkBehaviour
{
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	public float speed;
	public float jumpspeed;
	private Rigidbody2D playerbody;
	//private CharacterController playerbody;
	private bool holdjump;
	public bool frozen;
	private Vector3 spawnPoint;
	Animator anim;
	float savedTime;
	public AudioClip jumpsound;
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = GetComponent<Rigidbody2D>().position;
			stream.Serialize(ref syncPosition);
			
			syncPosition = GetComponent<Rigidbody2D>().velocity;
			stream.Serialize(ref syncVelocity);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = GetComponent<Rigidbody2D>().position;
		}
	}
	
	void Awake()
	{
		//this.name = players.newPlayerName ();
		lastSynchronizationTime = Time.time;
		playerbody = GetComponent<Rigidbody2D>();
		holdjump = false;
		anim = GetComponent <Animator> ();
	}
	
	void Update()
	{
		//if (GetComponent<NetworkView>().isMine)
		if(isLocalPlayer)
		{
			InputMovement();
			//InputColorChange();
		}
		else
		{
			SyncedMovement();
		}
	}
	
	
	private void InputMovement()
	{

		if (frozen == false) {
			playerbody.velocity = new Vector2 (speed, playerbody.velocity.y);
		} else {
			if (savedTime + 3f < Time.realtimeSinceStartup)
				frozen = false;
		}
		
		if (playerbody.position.y <= .03)
			anim.SetFloat ("Speed", 0);
		else 
			anim.SetFloat ("Speed", 1);
		
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetFloat ("Speed", 1);
			if (isGrounded ()) {
				playerbody.velocity = new Vector2 (playerbody.velocity.x, jumpspeed);
				AudioSource.PlayClipAtPoint (jumpsound, this.transform.position);
				holdjump = true;
			}
		}
		if (holdjump) {
			if (playerbody.velocity.y < 0) {
				playerbody.gravityScale = 3;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			
			playerbody.gravityScale = 18;
			holdjump = false;
		}
		
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			//transform.position = new Vector3(transform.position.x, .1f, 0);
			transform.localScale = new Vector3 (transform.localScale.x, .5f, 0);
			playerbody.gravityScale = 22;
			
		}
		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			//transform.position = new Vector3(transform.position.x, .5f, 0);
			transform.localScale = new Vector3 (transform.localScale.x, 1f, 0);
			playerbody.gravityScale = 18;
			anim.SetFloat ("Speed", 0);
		}
	}
	
	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		
		GetComponent<Rigidbody2D>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Obstacle") {
			transform.position = new Vector3 (transform.position.x + .5f, transform.position.y, transform.position.z);
			frozen = true;
			savedTime = Time.realtimeSinceStartup;
		} else if (other.gameObject.tag == "Finish") {
			Application.LoadLevel ("Multiplayer_Finish");
		}
	}
	
	
	bool isGrounded(){
		if (playerbody.velocity.y == 0) {
			return true;
		} else {
			return false;
		}
	}
	
	
//	private void InputColorChange()
//	{
//		if (Input.GetKeyDown(KeyCode.R))
//			ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
//	}
//	
//	[RPC] void ChangeColorTo(Vector3 color)
//	{
//		GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);
//		
//		if (GetComponent<NetworkView>().isMine)
//			GetComponent<NetworkView>().RPC("ChangeColorTo", RPCMode.OthersBuffered, color);
//	}
}
