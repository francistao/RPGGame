using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemGrid : MonoBehaviour {

	public int id = 0;
	private ObjectInfo info = null;

	public int num = 0;
	private UILabel numLable;



	// Use this for initialization
	void Start () {
		numLable = this.GetComponentInChildren<UILabel> ();
	}

	public void SetId(int id, int num = 1){
		this.id = id;
		info = ObjectsInfo._instance.GetObjectInfoById(id);
		InventoryItem item = this.GetComponentInChildren<InventoryItem>();
		item.SetIconName(id, info.icon_name);
		numLable.enabled = true;
		this.num = num;
		numLable.text = num.ToString();
	}

	public void PlusNumber(int num = 1){
		this.num += num;	
		numLable.text = this.num.ToString ();
	}

	//清空 格子存的物品信息
	public void ClearInfo(){
		id = 0;
		info = null;
		num = 0;
		numLable.enabled = false;
	}
}
