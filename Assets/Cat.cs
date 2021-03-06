using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{
	bool facingRight = true;
	Rigidbody2D myRigidbody;
	Animator myAnim;
	public float mySpeed = 1.0f;

	public bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float jumpForce;

	public GameObject fish;


	// Use this for initialization
	void Start ()
	{
		myRigidbody = this.gameObject.GetComponent<Rigidbody2D> ();
		//this.gameObject.GetComponent<Transform> ();//Transform
		myAnim = GetComponent<Animator> ();//Animator
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			myRigidbody.AddForce (new Vector2 (0.0f, jumpForce));
			myAnim.SetBool ("isJump",true);

			//myAnim.SetFloat ("vspeed",myRigidbody.velocity.y);
		}

		if (Input.GetKey (KeyCode.Q))
		{
			//Instantiate (fish, transform.position, transform.rotation);
		}
	}

	void FixedUpdate () 
	{
		//collider2D touched = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		myAnim.SetBool ("jump",!grounded);

		float move = Input.GetAxis ("Horizontal");//按左右鍵
		myAnim.SetFloat ("speed",Mathf.Abs(move));

		myRigidbody.velocity = new Vector2 (move * mySpeed, myRigidbody.velocity.y);
		if (move > 0.0f && facingRight == false)
		{
			Flip ();
		} else if (move < 0.0f && facingRight == true)
		{
			Flip ();
		} else
		{
		}

	}

	void Flip()
	{
		//Debug.Log(transform.position);
		//transform.rotation;transform.localScale;

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x = theScale.x * -1;
		transform.localScale = theScale;
	}
}
