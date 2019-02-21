using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChickenContoller : MonoBehaviour {

    public GameObject target;
    public float force;

    public Vector3 StartingPosition { get; private set; }

	// Use this for initialization
	void Start () {
        StartingPosition = transform.position;
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
        transform.position = StartingPosition;
        gameObject.SetActive(false);
    }
}
