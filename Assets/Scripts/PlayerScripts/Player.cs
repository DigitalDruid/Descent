﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;

	//calls GetComponet for Rigidbody and Animator as soon as game loads
	void Awake(){
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Calling the PlayerMoveKeyBoard function every couple of frames
	void FixedUpdate () {
		PlayerMoveKeyBoard();
	}

	//Physics for the player
	void PlayerMoveKeyBoard(){
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if( h > 0) {

			if(vel < maxVelocity)
				forceX = speed;

			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);

			}else if (h < 0){

				if(vel < maxVelocity)
					forceX = -speed;

			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool("Walk", false);
		}

		myBody.AddForce (new Vector2(forceX, 0));
	}
}