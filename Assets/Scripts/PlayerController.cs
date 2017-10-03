using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	private Rigidbody2D myRigidbody;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool isGrounded;
	public ParticleSystem damageParticle;
	private Animator myAnim;

	private bool jumpHeld = false;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		jumpSpeed = 12;
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);

		//variable jump height
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			myRigidbody.AddForce(new Vector2(0, jumpSpeed*64));
			jumpHeld = true;
		}
		else if (Input.GetButtonUp ("Jump")) {
			jumpHeld = false;
		}

		if (!isGrounded && !jumpHeld) {
			myRigidbody.AddForce (new Vector2 (0, -12));
		}

		// animations
		myAnim.SetFloat ("Speed", Mathf.Abs (myRigidbody.velocity.x));
		myAnim.SetBool ("Grounded", isGrounded);

	}

	// debug: log all items player collides with, only once
	HashSet<string> collidedWith = new HashSet<string>();
	void OnCollisionEnter2D(Collision2D coll) {
		// debug
		string name = coll.gameObject.name.ToLower();
		if (!collidedWith.Contains (name)) {
			collidedWith.Add (name);
			Debug.Log (gameObject.name + " collided with: " + name);
		}
	}

	// debug: log all items player triggers, only once
	HashSet<string> triggered = new HashSet<string>();
	void OnTriggerEnter2D(Collider2D coll) {
		// debug
		string name = coll.gameObject.name.ToLower();
		if (!collidedWith.Contains (name)) {
			collidedWith.Add (name);
			Debug.Log (gameObject.name + " triggered: " + name);
		}

		// die from spikes
		if (name.StartsWith ("spikes")) {
			Die ();
		}
	}

	void Die() {
		ParticleSystem particles = Instantiate (damageParticle, myRigidbody.transform.position, myRigidbody.transform.rotation);
		Destroy (particles, 1);
		Invoke ("ResetScene", 1);
	}

	void ResetScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
