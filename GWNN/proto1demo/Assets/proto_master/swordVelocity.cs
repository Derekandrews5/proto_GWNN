//Derek Andrews
//January 25th, 2019
//Sword testing velocity
//will be relevant down the road
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordVelocity : MonoBehaviour {


    public Vector3 previousPosition;
    public Vector3 currentPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        previousPosition = currentPosition;
        currentPosition = transform.position;
            

	}

    public int GetVelocityMag() {


        return (int)(Mathf.Abs((previousPosition - currentPosition).magnitude)*100);


    }

}
