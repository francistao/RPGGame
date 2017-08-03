using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCamera : MonoBehaviour {


	public float speed = 10;

	private float endZ = -20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.z < endZ) {  //还没有达到目标位置，需要移动
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}
}
