using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private PlayerMove move;

	// Use this for initialization
	void Start () {
		move = this.GetComponent<PlayerMove> ();

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (move.state == PlayerState.Moving) {
			PlayAnim ("Run");
		} else if(move.state == PlayerState.Idle){
			PlayAnim ("Idle");
		}
	}


	void PlayAnim(string animName){
		GetComponent<Animation> ().CrossFade (animName);
	}
}
