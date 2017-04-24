using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			//Trigger level complete.
			PlayerController.player.canMove = false;
			GameController.gamecontroller.RetryMenu();
		}
	}
}
