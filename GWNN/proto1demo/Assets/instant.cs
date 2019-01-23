using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instant : MonoBehaviour {

    public Transform enem;
    private float spawnprob;
    public int probability = 100;
    public bool enemies = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnprob= Random.Range(1, probability);
        Debug.Log(spawnprob);
        if (spawnprob == 3) {
            if (enemies == true) {
                Instantiate(enem, new Vector3(20, -3.4f, 0), Quaternion.identity);
                Debug.Log("creature spawned");
            }
        }
	}
}
