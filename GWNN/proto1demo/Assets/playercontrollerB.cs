using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrollerB : MonoBehaviour {
	public float speed;
	public Canvas canvas;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;
	private bool m_isAxisInUse = false;
	public GameObject shield;
	public float rotateSpeed=10;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 moveinput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveinput.normalized * speed;

		float ry = Input.GetAxis ("Vertical");
		//float triggerA = Input.GetAxis ("Vertical");


		Debug.Log (ry);

	//	shield.transform.RotateAround(shield.transform.parent.position, new Vector3(0, 0, 1),triggerA*5);

		if( ry == -1)
		{
			if(m_isAxisInUse == false)
			{
				// Call your event function here.
				canvas.transform.Translate(ry,0,0);
				m_isAxisInUse = true;
			}
		}
		if(ry > -1)
		{
			m_isAxisInUse = false;
		}


	}

	void FixedUpdate(){

		rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){

		Debug.Log ("Enter");
	}

	void OnTriggerExit2D(Collider2D col){

	}
}