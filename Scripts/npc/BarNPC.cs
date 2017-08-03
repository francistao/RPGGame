using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : NPC {

	public TweenPosition questTween;
	public UILabel desLabel;
	public GameObject acceptBtnGo;
	public GameObject okBtnGo;
	public GameObject cancelBtnGo;


	public bool isInTask = false;  //用来表示是否在任务中
	public int killCount = 0; //表示任务进度已经杀死了几只小野狼

	private PlayerStatus status;


	// Use this for initialization
	void Start () {
		status = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){   //当鼠标位于这个 collider 之上的时候，会在每一帧调用这个方法
		if(Input.GetMouseButtonDown(0)){  //当点击了老爷爷
			this.GetComponent<AudioSource> ().Play ();
			if (isInTask) {
				ShowTaskProgress ();
			} else {
				ShowTaskDes ();
			}
			ShowQuest ();
		}
	}

	void ShowQuest(){
		questTween.gameObject.SetActive (true);
		questTween.PlayForward ();
	}

	void HideQuest(){
		questTween.PlayReverse ();
	}


	void ShowTaskDes(){
		desLabel.text = "任务：\n杀死10只狼\n\n奖励：\n1000金币";
		okBtnGo.SetActive (false);
		acceptBtnGo.SetActive (true);
		cancelBtnGo.SetActive (true);
	}

	void ShowTaskProgress(){
		desLabel.text = "任务：\n你已经杀死了" + killCount + "/10只狼\n\n奖励：\n1000金币";
		okBtnGo.SetActive (true);
		acceptBtnGo.SetActive (false);
		cancelBtnGo.SetActive (false);
	}
	//任务系统  任务对话框上的按钮点击事件的处理 
	public void OnCloseButtonClick(){
		HideQuest ();
	}

	public void OnAcceptButtonClick(){
		ShowTaskProgress ();
		isInTask = true;
	}

	public void OnOkButtonClick(){
		if (killCount >= 10) {  //完成任务
			status.GetCoint(1000);
			killCount = 0;
			ShowTaskDes ();
		} else { // 没有完成任务
			HideQuest(); 
		}
	}

	public void OnCancelButtonClick(){
		HideQuest ();
	}
}
