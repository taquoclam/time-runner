using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	private Rigidbody2D myRigidbody;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool isGrounded;
	private Animator myAnim;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		jumpSpeed = 12;
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);

		if (Input.GetButtonDown ("Jump") && isGrounded) {
			myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, jumpSpeed, 0f);
		}

		myAnim.SetFloat ("Speed", Mathf.Abs (myRigidbody.velocity.x));
		myAnim.SetBool ("Grounded", isGrounded);

	}
}
