using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour {
    public float Hspeed = 4;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * Hspeed * Time.deltaTime); 
        
	}
}
