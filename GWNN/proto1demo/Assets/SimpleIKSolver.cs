﻿//Derek Andrews
//January 25th, 2019
//IK setup unity tutorials to see explanation
//will need to be setup correctly and tweaked
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleIKSolver : MonoBehaviour {

    public GameObject targeta;
    public Transform pivot, upper, lower, effector, tip;
    
    public Vector3 normal = Vector3.down;


    float upperLength, lowerLength, effectorLength, pivotLength;
    Vector3 effectorTarget, tipTarget;

    private void Awake() {
        upperLength = (lower.position - upper.position).magnitude;
        lowerLength = (effector.position - lower.position).magnitude;
        effectorLength = (tip.position - effector.position).magnitude;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tipTarget = targeta.transform.position;
        effectorTarget = targeta.transform.position + normal * effectorLength;
        Solve();
	}

    

    private void Reset() {

        pivot = transform;
        try {
            upper = pivot.GetChild(0);
            lower = upper.GetChild(0);
            effector = lower.GetChild(0);
            tip = effector.GetChild(0);
        } catch(UnityException) {
            Debug.Log("Could not find required transforms,please assign manually");
        }
    }

    void Solve() {
        var pivotDir = effectorTarget - pivot.position;
        pivot.rotation = Quaternion.LookRotation(pivotDir);


        var upperToTarget = (effectorTarget - upper.position);
        var a = upperLength;
        var b = lowerLength;
        var c = upperToTarget.magnitude;


        var B = Mathf.Acos((c * c + a * a - b * b) / (2 * c * a)) * Mathf.Rad2Deg;
        var C = Mathf.Acos((a * a + b * b - c * c) / (2 * a * b)) * Mathf.Rad2Deg;


        if (!float.IsNaN(C)) {
            var upperRotation = Quaternion.AngleAxis((-B), Vector3.right);
            upper.localRotation = upperRotation;
            var lowerRotation = Quaternion.AngleAxis(180 - C, Vector3.right);
            lower.localRotation = lowerRotation;
        }
        var effectorRotation = Quaternion.LookRotation(tipTarget - effector.position);
        effector.rotation = effectorRotation;
    }
}