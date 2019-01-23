using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plater : MonoBehaviour
{
	

	public float jumpSpeed = 8.0F;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;

	bool isGrounded=false;


	public float speed;
	public Canvas canvas;
	private Rigidbody2D rb;
	//private Vector2 moveVelocity;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	void Update()
	{

		if (Input.GetKey ("joystick button 16")) {
			Debug.Log ("hitting A");
		}
		if (isGrounded)
		{
			moveDirection = transform.right * Input.GetAxis("Horizontal") * speed;
			if (Input.GetKey("joystick button 16"))
			{
				Debug.Log("hitting A");
				moveDirection.y += jumpSpeed;
			}
		}
		rb.MovePosition(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
		canvas.transform.Translate(-Time.deltaTime*5,0,0);
	}


	void OnTriggerEnter2D(Collider2D col){
		isGrounded = true;
		Debug.Log ("Enter");
	}

	void OnTriggerExit2D(Collider2D col){
		isGrounded =false;
	}
}