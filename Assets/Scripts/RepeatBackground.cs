using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
	private float groundHorizontalLength;
    private float startx;

	// Use this for initialization
	void Start () {
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
        startx = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x + groundHorizontalLength < startx) {
			RepositionBackground ();
		}
	}

	private void RepositionBackground(){
        transform.position += new Vector3(startx - transform.position.x, 0, 0);
	}

}
