using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityMultipler : MonoBehaviour {
    private Rigidbody mybody;
    public GameObject platform;
	// Use this for initialization
	void Start () {
        mybody = gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        mybody.AddForce(Physics.gravity * mybody.mass *2);
    }

    // Update is called once per frame
    void Update () {
        //mybody.AddForce(Physics.gravity * mybody.mass * 2);
    }


    /*void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "platform") {
            Physics.IgnoreCollision(platform.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }*/
}
