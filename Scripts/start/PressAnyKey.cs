using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {

	private bool isAnyKeyDown = false;  //表示是否有任何按键按下
	private GameObject buttonContainer;






	// Use this for initialization
	void Start () {
		buttonContainer = this.transform.parent.Find ("buttonContainer").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAnyKeyDown == false) {
			if (Input.anyKey) {
				// show button container
				// hide self
				showButton();
			}
		}
	}

	void showButton(){
		buttonContainer.SetActive (true);
		this.gameObject.SetActive (false);
		isAnyKeyDown = true;
	}
}
