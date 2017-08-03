using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour {

	public static EquipmentUI _instance;
	private TweenPosition tween;
	private bool isShow = false;

	private GameObject headgear;
	private GameObject armor;
	private GameObject rightHand;
	private GameObject leftHand;
	private GameObject shoe;
	private GameObject accessory;

	private PlayerState ps;


	void Awake(){
		_instance = this;
		tween = this.GetComponent<TweenPosition> ();

		headgear = transform.Find ("Headgear").gameObject;
		armor = transform.Find ("Armor").gameObject;
		rightHand = transform.Find ("RightHand").gameObject;
		leftHand = transform.Find ("LeftHand").gameObject;
		shoe = transform.Find ("Shoe").gameObject;
		accessory = transform.Find ("Accessory").gameObject;

		ps = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerState> ();
	}



	public void TransformState(){
		if (isShow == false) {
			tween.PlayForward ();
			isShow = true;
		} else {
			tween.PlayReverse ();
			isShow = false;
		}
	}

	public bool Dress(int id){
		ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById (id);
		if (info.type != ObjectType.Equip) {
			return false;  //穿戴不成功
		}
		return true;
	}
}
