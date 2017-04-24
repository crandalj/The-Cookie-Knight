using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour {

	public float boostPower;
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			PlayerController.player.velocity.y = boostPower;
		}
	}
}
