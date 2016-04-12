﻿using UnityEngine;
//using CnControls;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float jumpSpeed;
	public float speedFactor;
	private Rigidbody2D rb2d;
	public VirtualJoystick joystick;
	public bool m_Grounded = true;
	//Use the two store floats to create a new Vector2 variable movement.
	private Vector2 movement;
	public int i;

//
//	//For Crawler
//	public float moveSpeed = .2f;
//	//private CircleCollider2D collider;
//	private float crawlerRadius = 0.25f;
//	//private Vector2 crawlerCenter;
//	public LayerMask obstacles;
//	private Vector3 previousPosition;
//	private bool hasStuck = false;
//

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		//rb2d.drag = 0.5f;
		m_Grounded=false;
		jumpSpeed =15f;
		speed = 20f;
		speedFactor = 5f;
		i = 0;

	}

	private void tryJump() {


		if (m_Grounded == false)
			return;
		m_Grounded = false;
		rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed);
		//rb2d.AddForce (new Vector2(0, jumpSpeed));

		//Debug.Log("i = " + i++);
	}

	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		movement = new Vector2 (moveHorizontal, moveVertical); 

		movement.x = joystick.Horizontal();

		movement.y = joystick.Vertical();
		//Debug.Log (" spped " + movement.y);
		if (movement.y > 0.5 ) {

			tryJump ();
		}





	}
	// Update is called once per frame
	void Update () {
		// Don't rotate temporarily for jump bug
		transform.Rotate (new Vector3 (0, 0, -45) * Time.deltaTime);

//		Vector2 up = transform.up;
//		Debug.Log ("Tranf.up = " + transform.up);
//
//		Vector2 frontPoint = transform.position;
//
//		RaycastHit2D hit = Physics2D.Raycast (frontPoint, -up, crawlerRadius, obstacles);
//		Debug.DrawRay (frontPoint, -up, Color.red);
//
//		if (hit.collider != null) {
//			//just debug info
//			Debug.DrawRay (hit.point, hit.normal, Color.yellow);
//			Vector3 moveDirection = Quaternion.Euler (0, 0, -90) * hit.normal;
//			Debug.DrawRay (frontPoint, moveDirection, Color.white);
//
//			//var collisions = Physics2D.OverlapCircleAll(transform.position, crawlerRadius);
//			//Debug.Log (collisions.);
//
//			//stick to the obstacle
//			GetComponent<Rigidbody2D>().AddForce (-2 * hit.normal);
//			//move forward
//			GetComponent<Rigidbody2D>().AddForce(0.5f * moveDirection);
//
//
//			var len = crawlerRadius * transform.lossyScale.x * 2;
//			RaycastHit2D hit2 = Physics2D.Raycast (frontPoint, moveDirection, len, obstacles);
//			if(hit2.collider != null){
//				//Debug.Log ("### Obstacle forward. Rotating");
//				Quaternion targetRotation2 = Quaternion.FromToRotation (Vector3.up, hit2.normal);
//				transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation2, Time.deltaTime);
//			} else {
//				//rotate crawler according to obstacle angle under it
//				Quaternion targetRotation = Quaternion.FromToRotation (Vector3.up, hit.normal);
//				transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, Time.deltaTime);
//				//Debug.Log ("### No obstcacle...");
//			}
//
//
//		} else {
//			//no ground under object - falling.
//			GetComponent<Rigidbody2D>().AddForce(Vector3.down);
//		}


		// run
		//rb2d.AddForce (new Vector2(movement.x, 0) * speed);
		rb2d.velocity = new Vector2 (movement.x * speedFactor, rb2d.velocity.y);

		//jump
		Collider2D[] colliders = Physics2D.OverlapCircleAll(rb2d.position, 0.25f);
		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.

//		for (int i = 0; i < colliders.Length; i++)
//		{
//			if (colliders [i].gameObject != gameObject) {
//				m_Grounded = true;
//				break;
//			}
//		}
//
//
		if (colliders.Length > 1) {
			m_Grounded = true;
				Debug.Log("colliders.Length = " + colliders.Length);
		} else {
				Debug.Log("colliders.Length = " + colliders.Length);
			m_Grounded = false;
		}

	}
}

//[RequireComponent(typeof (PlatformerCharacter))]
//public class Platformer2DUserControl : MonoBehaviour
//{
//    private PlatformerCharacter m_Character;
//    private bool m_Jump;


//    private void Awake()
//    {
//        m_Character = GetComponent<PlatformerCharacter>();
//    }

//    private void Update()
//    {
//        if (!m_Jump)
//        {
//            // Read the jump input in Update so button presses aren't missed.
//            m_Jump = CnInputManager.GetButtonDown("Jump");
//        }
//    }

//    private void FixedUpdate()
//    {
//        float h = CnInputManager.GetAxis("Horizontal");
//        // Pass all parameters to the character control script.
//        m_Character.Move(h, m_Jump);
//        m_Jump = false;
//    }
//}

