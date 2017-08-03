using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
	Moving,
	Idle
}


public class PlayerMove : MonoBehaviour {

	public float speed = 4;
	public PlayerState state = PlayerState.Idle;

	private PlayerDir dir;
	private CharacterController controller;
	public bool isMoving = false;



	// Use this for initialization
	void Start () {
		dir = this.GetComponent<PlayerDir> ();
		controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (dir.targetPosition, transform.position);
		if (distance > 0.3f) {
			isMoving = true;
			state = PlayerState.Moving;
			controller.SimpleMove (transform.forward * speed);
		} else {
			isMoving = false;
			state = PlayerState.Idle;
		}
		
	}
}
