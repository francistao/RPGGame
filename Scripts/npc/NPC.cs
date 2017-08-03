 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {


	void OnMouseEnter(){
		CursorManager._instance.SetNpcTalk ();
	}


	void OnMouseExit(){
		CursorManager._instance.SetNormal ();
	}
}
