using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public float speed;
	public Canvas canvas;
	public Rigidbody2D rb;
	private Vector2 moveVelocity;
	public float jumpSpeed = 10f;
	bool isGrounded=false;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		Vector2 moveinput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveinput.normalized * speed;

		canvas.transform.Translate(-Time.deltaTime*5,0,0);
		if (isGrounded) {
			if (Input.GetKey ("joystick button 16")) {
				Debug.Log ("hitting A");
				//rb.AddForce (transform.up * jumpSpeed);
				//moveVelocity= transform.up * jumpSpeed;
//				rb.AddForce(Vector3.up , ForceMode.Impulse);

			}
		}

	}

	void FixedUpdate(){
		
		rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		isGrounded = true;
		 rb.gravityScale = 0;
		Debug.Log ("Enter");
	}

	void OnTriggerExit2D(Collider2D col){
		rb.gravityScale = 30;
		isGrounded = false;
	}
}
