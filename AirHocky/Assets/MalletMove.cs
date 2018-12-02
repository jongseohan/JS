using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalletMove : MonoBehaviour {    
    public float moveSpeed;
    Vector3 lookDirection;
    private float mass;
    private GameObject puck;
    private Rigidbody puckRigid;

    private float lastTime;  //경과 시간을 갖는 변수
    

    // Use this for initialization
    void Start () {
        //GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward*10, new Vector3(0, 1, 0), ForceMode.Impulse);
        mass = GetComponent<Rigidbody>().mass;
        puck = GameObject.FindWithTag("Puck");
        puckRigid = puck.GetComponent<Rigidbody>();
        puckRigid.AddForce( 1.0f, 0.0f, 10.0f, ForceMode.Impulse);
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if( Time.time - lastTime > 1.0f)
        {
            lastTime = Time.time;
            UnityEngine.Debug.Log("calc!!");
            Vector3 vel = puckRigid.velocity;
            if( vel.z != 0.0f)
            {
                float a = vel.x / vel.z;
                Vector3 puckPos = puck.transform.position;
                Vector3 pos = this.transform.position;
                // z = a(x - x1) + z1
                float x = a * (pos.z - puckPos.z) + puckPos.x;
                pos.x = x > 21.0f ? 21.0f : x < -21.0f ? -21.0f : x;
                this.transform.position = pos;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        UnityEngine.Debug.Log("collision!!");
        if (obj.tag == "Puck")
        {
            UnityEngine.Debug.Log("collision!!??");
            Vector3 vel = puckRigid.velocity;
            Vector3 velNorm = vel.normalized;
            Vector3 force = velNorm * moveSpeed;
            puckRigid.AddForce(force, ForceMode.Impulse);
        }
    }
}
