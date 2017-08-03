using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBar : MonoBehaviour {

	public void OnStatusButtonClick(){
		Status._instance.TransformState ();
	}

	public void OnBagButtonClick(){
		Inventory._instance.TransformState ();
	}

	public void OnEquipButtonClick(){
		EquipmentUI._instance.TransformState ();
	}

	public void OnSkillButtonClick(){
		
	}

	public void OnSettingButtonClick(){
		
	}


}
