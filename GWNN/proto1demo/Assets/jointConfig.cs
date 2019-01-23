using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jointConfig : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpringJoint2D spring = gameObject.GetComponent<SpringJoint2D>();
        if(spring != null) {
            Debug.Log("hello");
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
