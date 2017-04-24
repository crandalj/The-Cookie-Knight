using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	public float falldelay;
	public float resetdelay;
	public float fallSpeed;

	private Vector3 spawnPos;
	private float delayTime;

	private bool activated = false;
	private bool falling = false;

	// Use this for initialization
	void Start () {
		spawnPos = this.transform.position;
	}

	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log (other.gameObject.name);
		if (other.gameObject.tag == "Player" && !activated && !falling) {
			delayTime = Time.time + falldelay;
			activated = true;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (activated && (Time.time > delayTime)) {
			falling = true;
			delayTime = Time.time + resetdelay;
			activated = false;
		}

		if (falling){
			if (Time.time < delayTime) {
				Vector2 newpos = new Vector2 (transform.position.x, transform.position.y - (fallSpeed * Time.deltaTime));
				transform.position = newpos;
			} else{
				falling = false;
				transform.position = spawnPos;
			}
		}
	}
}
