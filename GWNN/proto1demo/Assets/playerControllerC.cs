using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerC : MonoBehaviour {
	public float speed;
	public Canvas canvas;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;
	int swit;

	private bool m_isAxisInUse = false;
	public GameObject shield;
	public float rotateSpeed=10;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		
		string input=Input.inputString;
		switch (input) {
		case "1":
			swit = 1;
			print ("1 was pressed");
			break;
		case "2":
			print ("2 was pressed");
			swit = 2;
			break;
		case "3":
			swit=3;
			break;
		case "4":
			swit=4;
			break;

		}
		if (swit == 1) {
			Vector2 moveinput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			moveVelocity = moveinput.normalized * speed;
			if (Input.GetKey ("joystick button 8")) {
				canvas.transform.Translate (-Time.deltaTime * 5, 0, 0);
			}

			if (Input.GetKey ("joystick button 14")) {
				canvas.transform.Translate (-Time.deltaTime * 5, 0, 0);
			}


			if (Input.GetKey ("joystick button 13")) {
				canvas.transform.Translate (-Time.deltaTime * 5, 0, 0);
			}
		}



		if (swit == 2) {
			Vector2 moveinput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			moveVelocity = moveinput.normalized * 0;

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
		if (swit == 3) {
			Vector2 moveinput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			moveVelocity = moveinput.normalized * speed;
			if (moveVelocity.y!=0) {
				canvas.transform.Translate(-Time.deltaTime*5,0,0);
			}

		}
		if (swit == 4) {
			Vector2 moveinput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			moveVelocity = moveinput.normalized * speed;

			float ry = Input.GetAxis ("RV");
			float triggerA = Input.GetAxis ("trigger");


			Debug.Log (triggerA);


			shield.transform.RotateAround(shield.transform.parent.position, new Vector3(0, 0, 1),triggerA*5);


			if( ry == 1)
			{
				if(m_isAxisInUse == false)
				{
					// Call your event function here.
					canvas.transform.Translate(-ry,0,0);
					m_isAxisInUse = true;
				}
			}
			if(ry < 1)
			{
				m_isAxisInUse = false;
			}
		}





	}

	void FixedUpdate(){

		rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		// rb.gravityScale = 0;
		Debug.Log ("Enter");
	}

	void OnTriggerExit2D(Collider2D col){
		//rb.gravityScale = 17;
	}
}
