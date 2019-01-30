//Derek Andrews
//January 25th, 2019
//General move and jump script 
//make sure imput setting for controller match
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class playerController: MonoBehaviour {
    //private Rigidbody2D mybody;
    private Rigidbody mybody;
    public float speed;
	public Canvas canvas;
    public bool isGrounded;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    // Use this for initialization
    void Start () {
        //getting rigidbody of the object the script is on
        mybody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("LeftJoystickX");
		mybody.velocity = new Vector2 (move * speed, mybody.velocity.y);
        //if 'A' or joystick button is moved up all the way and the object is grounded then jump
        if ((Input.GetKeyDown("joystick button 0") && isGrounded) || Input.GetAxis("LeftJoystickY")>.9 && isGrounded) {
            mybody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;           
        }
        //to move background
        //this will be deprecated later
        canvas.transform.Translate(-Time.deltaTime*5,0,0);
		
	}

    void OnCollisionStay() {
        isGrounded = true;
    }

}
