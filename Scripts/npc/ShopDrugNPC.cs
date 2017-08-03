using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDrugNPC : NPC {

	public void OnMouseOver(){  //当鼠标在这个游戏物体之上的时候，会一只调用这个方法
		if(Input.GetMouseButtonDown(0)){  //弹出来药品购买列表
//			audio.Play();
			this.GetComponent<AudioSource> ().Play ();
			ShopDrug._instance.TransformState ();
		}
	}
}
