using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController player;

	public bool canMove;
	public float moveVel;
	public float inputDelay;
	public float gravity;
	private float moveSpeed;
	public Vector2 velocity = Vector2.zero;
	private float moveInput;
	private float jumpInput;

	public float jumpVel;
	public LayerMask isGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	private bool grounded;

	private bool facingRight;
	private Rigidbody2D rb;
	private Animator anim;

	public AudioClip jumpclip;
	public AudioSource aud;

	// Use this for initialization
	void Start () {
		player = this;
		canMove = true;
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		aud = GetComponent<AudioSource> ();
		facingRight = true;
		moveSpeed = 0;
		jumpInput = 0;
		moveInput = 0;
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	bool Grounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
	}

	void GetInput()
	{
		moveInput = Input.GetAxis ("Horizontal");
		jumpInput = Input.GetAxis ("Jump");

		if (moveInput > 0 && !facingRight) {
			Flip ();
		} else if (moveInput < 0 && facingRight) {
			Flip ();
		}
	}

	void Move()
	{
		if (Mathf.Abs (moveInput) > inputDelay) {
			velocity.x = moveVel * moveInput;
		} else {
			velocity.x = 0;
		}
	}
		
	void Jump()
	{
		if (jumpInput > 0 && Grounded ()) {
			velocity.y = jumpVel;
			anim.SetTrigger ("Jump");
			grounded = false;
			aud.PlayOneShot (jumpclip);
		} else if (jumpInput == 0 && Grounded ()) {
			velocity.y = 0;
			grounded = true;
		} else {
			velocity.y -= gravity;
			grounded = false;
		}
		anim.SetBool ("grounded", grounded);
	}

	void Animation()
	{
		Vector2 speed = rb.velocity;
		moveSpeed = speed.magnitude;
		anim.SetFloat ("movespeed", moveSpeed);
	}

	// Update is called once per frame
	void Update () {
		GetInput ();
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

	void FixedUpdate()
	{
		if (canMove) {
			Move ();
			Jump ();

			rb.velocity = transform.TransformDirection (velocity);

			Animation ();
		}
	}
}
