using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyFunctions : MonoBehaviour {

	public GameObject bunnyPrefab;

	public GameObject bunnyRef;
	public Animator anim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			bunnyRef = Instantiate (bunnyPrefab);
			anim = bunnyRef.GetComponent<Animator> ();
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			if (anim.GetBool ("isWalking"))
				anim.SetBool ("isWalking", false);
			else
				anim.SetBool ("isWalking", true);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			Destroy (bunnyRef);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger("doHop");
		}

	}
}
