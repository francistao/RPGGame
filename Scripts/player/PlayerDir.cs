using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour {

	public GameObject effect_click_prefeb;
	private bool isMoving = false;  //表示鼠标是否按下
	public Vector3 targetPosition = Vector3.zero;

	private PlayerMove playerMove;




	// Use this for initialization
	void Start () {
		targetPosition = this.transform.position;
		playerMove = this.GetComponent<PlayerMove> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !UICamera.isOverUI)  {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			bool isCollider = Physics.Raycast (ray, out hitInfo);
			if (isCollider && hitInfo.collider.tag == Tags.ground) {
				isMoving = true;
				ShowClickEffect (hitInfo.point);
				LookAtTarget (hitInfo.point);
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			isMoving = false;
		}

		if (isMoving) {
			//得到要移动的位置目标
			//让主角朝向目标移动
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo; 
			bool isCollider = Physics.Raycast (ray, out hitInfo);
			if (isCollider && hitInfo.collider.tag == Tags.ground) {
				LookAtTarget (hitInfo.point);
			} 
		}else {
			if (playerMove.isMoving) {
				LookAtTarget (targetPosition);
			}

		}
	}

	//实例化出来点击的效果
	void ShowClickEffect(Vector3 hitPoint){
		hitPoint = new Vector3 (hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
		GameObject.Instantiate (effect_click_prefeb, hitPoint, Quaternion.identity);
	}

	//让主角朝向目标位置
	void LookAtTarget(Vector3 hitPoint){
		targetPosition = hitPoint;
		targetPosition = new Vector3 (targetPosition.x, transform.position.y, targetPosition.z);
		this.transform.LookAt (targetPosition);
	}
}
