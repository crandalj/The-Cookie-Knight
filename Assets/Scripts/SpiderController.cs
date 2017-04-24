using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

	public GameObject spider;
	private bool facingRight;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;

	// Use this for initialization
	void Start () {
		facingRight = true;
		currentPoint = points [pointSelection];
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = spider.transform.localScale;
		theScale.x *= -1;
		spider.transform.localScale = theScale;
	}

	// Update is called once per frame
	void FixedUpdate () {
		spider.transform.position = Vector3.MoveTowards (spider.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

		if (spider.transform.position == currentPoint.position) {
			pointSelection++;
			if (pointSelection == points.Length) {
				pointSelection = 0;
			}

			currentPoint = points [pointSelection];
		}
		if (spider.transform.position.x < currentPoint.position.x && !facingRight) {
			Flip ();
		} else if (spider.transform.position.x > currentPoint.position.x && facingRight){
			Flip ();
		}
	}
}
