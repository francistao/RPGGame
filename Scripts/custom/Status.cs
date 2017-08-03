using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	public static Status _instance;
	private TweenPosition tween;
	private bool isShow = false;


	private UILabel attackLabel;
	private UILabel defLabel;
	private UILabel speedLabel;
	private UILabel pointRemainLabel;
	private UILabel summaryLabel;

	private GameObject attackButtonGo;
	private GameObject defButtonGo;
	private GameObject speedButtonGo;

	private PlayerStatus ps;


	void Awake(){
		_instance = this;
		tween = this.GetComponent<TweenPosition> ();

		attackLabel = transform.Find("attack").GetComponent<UILabel>();
		defLabel = transform.Find("def").GetComponent<UILabel>();
		speedLabel = transform.Find("speed").GetComponent<UILabel>();
		pointRemainLabel = transform.Find("point_remain").GetComponent<UILabel>();
		summaryLabel = transform.Find("summary").GetComponent<UILabel>();
		attackButtonGo = transform.Find("attack_plusbutton").gameObject;
		defButtonGo = transform.Find("def_plusbutton").gameObject;
		speedButtonGo = transform.Find("speed_plusbutton").gameObject;
	}

	void Start() {
		ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
	}
		
	public void TransformState() {
		if (isShow == false) {
			UpdateShow();
			tween.PlayForward(); isShow = true;
		} else {
			tween.PlayReverse(); isShow = false;
		}
	}

	void UpdateShow() {// 更新显示 根据ps playerstatus的属性值，去更新显示
		attackLabel.text = ps.attack + " + " + ps.attack_plus;
		defLabel.text = ps.def + " + " + ps.def_plus;
		speedLabel.text = ps.speed + " + " + ps.speed_plus;

		pointRemainLabel.text = ps.point_remain.ToString();

		summaryLabel.text = "伤害：" + (ps.attack + ps.attack_plus)
			+ "  " + "防御：" + (ps.def + ps.def_plus)
			+ "  " + "速度：" + (ps.speed + ps.speed_plus);

		if (ps.point_remain > 0) {
			attackButtonGo.SetActive(true);
			defButtonGo.SetActive(true);
			speedButtonGo.SetActive(true);
		} else {
			attackButtonGo.SetActive(false);
			defButtonGo.SetActive(false);
			speedButtonGo.SetActive(false);
		}

	}

	public void OnAttackPlusClick() {
		bool success = ps.GetPoint();
		if (success) {
			ps.attack_plus++;
			UpdateShow();
		}
	}
	public void OnDefPlusClick() {
		bool success = ps.GetPoint();
		if (success) {
			ps.def_plus++;
			UpdateShow();
		}
	}
	public void OnSpeedPlusClick() {
		bool success = ps.GetPoint();
		if (success) {
			ps.speed_plus++;
			UpdateShow();
		}
	}

}
