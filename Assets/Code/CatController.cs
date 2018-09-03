﻿using UnityEngine;

public class CatController : MonoBehaviour {

    public float torque;
    public float force = 1000;
    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3(0,0,0);
        rigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            var forceVector = gameObject.transform.forward * force;
            rigidBody.AddForce(forceVector);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var forceVector = gameObject.transform.forward * -force;
            rigidBody.AddForce(forceVector);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddTorque(new Vector3(0, -torque, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddTorque(new Vector3(0, torque, 0));
        }


        //var rotation = gameObject.transform.eulerAngles;
        //rotation.y += Time.deltaTime * 10;
        //gameObject.transform.eulerAngles = rotation;


    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.ToLower() == "box")
        {
            rigidBody.AddForce(0, 100000, 0);
        }
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.name.ToLower() == "finishline")
        {
            rigidBody.AddForce(0, 100000, 0);
        }
    }
}
