using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChickenContoller : MonoBehaviour {

    public GameObject target;
    public float force;

    Vector3 startingPosition;

	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Point the chicken at the target
        transform.LookAt(target.transform);
        var forceVector = transform.forward * force;
        GetComponent<Rigidbody>().AddForce(forceVector);
	}

    public void Reset()
    {
        transform.position = startingPosition;
        gameObject.SetActive(false);
    }
}
