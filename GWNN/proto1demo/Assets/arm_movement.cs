//Derek Andrews
//January 25th, 2019
//General Arm movement script
//will need to be changed and modified 
//testing with arm velocity
//make your input settings are setup
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm_movement : MonoBehaviour {
    public GameObject parent;
    public swordVelocity sword;
    private Vector3 movementVector;
    private float movementSpeed = 8;
    Vector3 armPos;
    Vector2 pos;
    float radius = 3;
    // Use this for initialization
    void Start () {
		
	}

    private void Reset() {
       // transform.position = parent.transform.position;
       // fraction += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(transform.position, new Vector3( parent.transform.position.x+ 1f, parent.transform.position.y, parent.transform.position.z), 5*Time.deltaTime);
    }


    private Vector2 GetRadius(Vector2 midpoint, Vector2 endpoint, float maxDistance) {
        Vector2 distance = endpoint;
        if (Vector2.Distance(midpoint, endpoint) > maxDistance) {
            distance = endpoint - midpoint;
            distance.Normalize();
            return (distance * maxDistance) + midpoint;
        }
        return distance;
            

    }

    // Update is called once per frame
    void Update () {
        Vector3 origin = new Vector3(parent.transform.position.x+1f, parent.transform.position.y, parent.transform.position.z);
       // Debug.Log(sword.GetVelocityMag());
        float dx = Input.GetAxis("RightJoystickX");
        float dz = Input.GetAxis("RightJoystickY");
        // -1 <= dx <= 1
        // -1 <= dy <= 1

            if (Mathf.Abs(dz) > .1 || Mathf.Abs(dx) > .1) {
                if (Input.GetAxis("Prim") > 0) {
                    Vector3 offset = new Vector3(dx, dz, 0);
                    Vector3 newPos = origin + (offset * radius);
                    transform.position = Vector3.Lerp(transform.position, newPos, .2f);
                } else { Reset(); }
            } else {
                Reset();
            }

    }

}




