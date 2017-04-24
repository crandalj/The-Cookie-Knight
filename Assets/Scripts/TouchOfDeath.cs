using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOfDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log (other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			//Trigger level complete.
			PlayerController.player.canMove = false;
			GameController.gamecontroller.RetryMenu();
		}
	}
}
