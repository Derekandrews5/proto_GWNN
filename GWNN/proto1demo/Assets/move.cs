using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class move : MonoBehaviour {
    //private Rigidbody2D mybody;
    private Rigidbody mybody;
 
    public float speed;
	
	public Canvas canvas;

    public bool isGrounded;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    // Use this for initialization
    void Start () {
        //mybody = gameObject.GetComponent<Rigidbody2D> ();
        mybody = GetComponent<Rigidbody>();
       
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("LeftJoystickX");
		mybody.velocity = new Vector2 (move * speed, mybody.velocity.y);

	

        if ((Input.GetKeyDown("joystick button 0") && isGrounded) || Input.GetAxis("LeftJoystickY")>.9 && isGrounded) {

            mybody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("jump");
        }

        canvas.transform.Translate(-Time.deltaTime*5,0,0);
		
	}

    void OnCollisionStay() {
        isGrounded = true;
    }










    }
