using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour {

	private string itemName;

	void Start(){
		itemName = gameObject.name;
		Debug.Log (itemName);
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			//Trigger level complete.
			GameController.gamecontroller.KeyItemFound(itemName);
			gameObject.SetActive (false);
		}
	}
}
