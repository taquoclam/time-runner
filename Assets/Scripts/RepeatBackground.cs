using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
	private float groundHorizontalLength;
	private float orderLayer;

	// Use this for initialization
	void Start () {
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;

		//This is to prevent objects from blocking player
		if (gameObject.tag == "ground") {
			orderLayer = 1;
		} else {
			orderLayer = 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
		}
	}

	private void RepositionBackground(){
		Vector3 groundOffset = new Vector3 (groundHorizontalLength * 2f, 0, orderLayer);
		transform.position = (Vector3)transform.position + groundOffset;
	}

}
