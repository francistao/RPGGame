using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Transform player;
	private Vector3 offsetPosition;  //位置偏移
	private bool isRotating = false;


	public float distance = 0;
	public float scrollSpeed = 1;
	public float rotateSpeed = 2;
	 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		transform.LookAt (player.position);
		offsetPosition = transform.position - player.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = offsetPosition + player.position;
		//处理视野的旋转
		RotateView();
		//处理视野的拉近和拉远效果
		ScrollView();


	}

	void ScrollView(){
		//向后返回负值（拉近视野），向前滑动返回正值 （拉远视野）
		distance = offsetPosition.magnitude;
		distance -= Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed ;
		distance = Mathf.Clamp (distance, 2, 18);
		offsetPosition = offsetPosition.normalized * distance;
	}

	void RotateView(){
		//Input.GetAxis ("Mouse X");  //得到鼠标在水平方向的滑动
		//Input.GetAxis("Mouse Y");

		if (Input.GetMouseButtonDown (1)) {
			isRotating = true;
		} 
		if (Input.GetMouseButtonUp (1)) {
			isRotating = false;
		} 
		if (isRotating) {
			transform.RotateAround (player.position, player.up, rotateSpeed * Input.GetAxis ("Mouse X"));

			Vector3 originalPos = transform.position;
			Quaternion qriginalRotation = transform.rotation;

			transform.RotateAround (player.position, transform.right, - rotateSpeed * Input.GetAxis ("Mouse Y"));  //影响的属性有两个，一个是position，一个是 rotation


			float x = transform.eulerAngles.x;
			if (x < 10 || x > 80) {   //当超出范围之后，我们将属性归位原来的，就是让旋转无效
				transform.position = originalPos;
				transform.rotation = qriginalRotation;

			}
//			x = Mathf.Clamp (x, 10, 80);
//			transform.eulerAngles = new Vector3 (x, transform.eulerAngles.y, transform.eulerAngles.z);

		} 

		offsetPosition = transform.position - player.position;
	}
}
