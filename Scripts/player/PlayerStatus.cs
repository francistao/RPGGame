using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HeroType{
	Swordman,
	Magician
}

public class PlayerStatus : MonoBehaviour {

	public HeroType heroType;


	public int grade = 1;
	public int hp = 100;
	public int mp = 100;
	public int coin = 200;  //金币数量

	public int attack = 20;
	public int attack_plus = 0;

	public int def = 20;
	public int def_plus = 0;

	public int speed = 20;
	public int speed_plus = 0;

	public int point_remain = 0;  //剩余的点数


	public void GetCoint(int count){
		coin += count;
	}
		

	public bool GetPoint(int point = 1){
		if (point_remain >= point) {
			point_remain -= point;
			return true;
		} 
		return false;
	}
}
