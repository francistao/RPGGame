using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour {


	// 游戏数据的保存，和场景之间游戏数据的传递使用 PlayerPrefs
	// 场景的分类
		//2.1 开始场景
		//2.2 角色选择界面
		//2.3 游戏玩家打怪的界面，就是游戏实际的运行场景 村庄有野兽。。。
	 

	//开始新游戏
	public void OnNewGame(){

		//加载我们的选择角色的场景
		PlayerPrefs.SetInt ("DataFromSave", 0); 
		Application.LoadLevel("character creation");
	}


	//加载已经保存的游戏
	public void OnLoadGame(){
		PlayerPrefs.SetInt ("DataFromSave", 1);  //表示数据来自保存
		//加载我们的 play 场景3
	}
}
