using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


	public static Inventory _instance;
	private TweenPosition tween;

	public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid> ();
	private int coinCount = 1000;  //金币数量

	public UILabel coinNumberLable; 
	public GameObject inventoryItem;


	void Awake(){
		_instance = this;
		tween = this.GetComponent<TweenPosition> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.K)) {
			GetId (Random.Range (2001, 2023));
		}
	}

	//拾取到id的物品，并添加到物品栏
	//处理拾取物品的功能
	public void GetId(int id, int count = 1){
		//第一步是查找在所有的物品中是否存在该物品
		//第二部如果存在，让 num +1
		//如果不存在，查找空的方格，然后把新创建的 InventoryItem 放到这个空的方格里面
		InventoryItemGrid grid = null;
		foreach (InventoryItemGrid temp in itemGridList) {
			if (temp.id == id) {
				grid = temp;
				break;
			}
		}

		if (grid != null) {  //存在的情况
			grid.PlusNumber(count);
		} 
		else {//不存在的情况
			foreach (InventoryItemGrid temp in itemGridList) {
				if (temp.id == 0) {
					grid = temp; break;
				}
			}
			if (grid != null) {//第三 不过不存在，查找空的方格，然后把新创建的Inventoryitem放到这个空的方格里面
				GameObject itemGo = NGUITools.AddChild(grid.gameObject, inventoryItem);
				itemGo.transform.localPosition = Vector3.zero;
				itemGo.GetComponent<UISprite>().depth = 4;
				grid.SetId(id, count);
			}
		}
			
		
	}

	private bool isShow = false;

	void Show(){
		isShow = true;
		tween.PlayForward ();
	}

	void Hide(){
		isShow = false;
		tween.PlayReverse ();
	}


	public void TransformState(){   //转变状态
		if (isShow == false) {
			Show ();
		} else {
			Hide ();
		}
	}

	// 这个是取款方法，返回 true 表示取款成功，返回 false 表示取款失败
	public bool GetCoin(int count){
		if (coinCount >= count) {
			coinCount -= count;
			coinNumberLable.text = coinCount.ToString ();
			return true;
		}
		return false;
	}
}
