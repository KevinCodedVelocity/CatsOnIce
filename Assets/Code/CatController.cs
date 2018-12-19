using System;
using UnityEngine;

public class CatController : MonoBehaviour
{
    const string AnimatorIsWalking = "isWalking";
    Rigidbody catBody;
    Animator catAnimationController;

    public float torque;
    public float force = 1000;
    public ParticleSystem bloodyExplosion;
    public GameController gameController;
    
    // Use this for initialization
    void Start () {
        gameObject.transform.position = new Vector3(0,0,0);
        catBody = gameObject.GetComponent<Rigidbody>();
        catAnimationController = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        bool isKeyHeld = false;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            var forceVector = gameObject.transform.forward * force;
            catBody.AddForce(forceVector);
            isKeyHeld = true;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var forceVector = gameObject.transform.forward * -force;
            catBody.AddForce(forceVector);
            isKeyHeld = true;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            catBody.AddTorque(new Vector3(0, -torque, 0));
            isKeyHeld = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            catBody.AddTorque(new Vector3(0, torque, 0));
            isKeyHeld = true;
        }

        // Pull in the animation controller for this cat
        
        catAnimationController.SetBool(AnimatorIsWalking, isKeyHeld);


        //var rotation = gameObject.transform.eulerAngles;
        //rotation.y += Time.deltaTime * 10;
        //gameObject.transform.eulerAngles = rotation;


    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            //rigidBody.AddForce(0, 100000, 0);
            bloodyExplosion.transform.parent = gameObject.transform;
            bloodyExplosion.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            bloodyExplosion.time = 0;         
            bloodyExplosion.Play();
            bloodyExplosion.gameObject.transform.parent = null;
            gameObject.SetActive(false);

            gameController.OnDeath();
        }
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.name.ToLower() == "finishline")
        {
            catBody.AddForce(0, 100000, 0);
        }
    }

    internal void Reset()
    {
        gameObject.SetActive(true);
        catBody.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        catBody.MovePosition(Vector3.zero);

        catAnimationController.SetBool(AnimatorIsWalking, false);

        transform.eulerAngles = Vector3.zero;
    }
}
