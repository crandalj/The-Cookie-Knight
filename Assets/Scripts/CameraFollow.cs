using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	// Update is called once per frame
	void Update () {
		float newX = target.transform.position.x;
		float newY = target.transform.position.y + 2;
		transform.position = new Vector3(newX, newY, transform.position.z);
	}
}
