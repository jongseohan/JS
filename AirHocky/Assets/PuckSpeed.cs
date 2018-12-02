using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpeed : MonoBehaviour {
    public float maxSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rigid = this.GetComponent<Rigidbody>();
        Vector3 vel = rigid.velocity;
        if (vel.magnitude > maxSpeed)
            vel = vel.normalized * maxSpeed;
    }
}
