using UnityEngine;

public class CatController : MonoBehaviour {

    public float torque;
    public float force = 1000;
    public ParticleSystem bloodyExplosion;

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3(0,0,0);
        rigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        bool isKeyHeld = false;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            var forceVector = gameObject.transform.forward * force;
            rigidBody.AddForce(forceVector);
            isKeyHeld = true;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var forceVector = gameObject.transform.forward * -force;
            rigidBody.AddForce(forceVector);
            isKeyHeld = true;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddTorque(new Vector3(0, -torque, 0));
            isKeyHeld = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddTorque(new Vector3(0, torque, 0));
            isKeyHeld = true;
        }

        // Pull in the animation controller for this cat
        Animator catAnimationController = GetComponent<Animator>();
        catAnimationController.SetBool("isWalking", isKeyHeld);


        //var rotation = gameObject.transform.eulerAngles;
        //rotation.y += Time.deltaTime * 10;
        //gameObject.transform.eulerAngles = rotation;


    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.ToLower() == "box")
        {
            //rigidBody.AddForce(0, 100000, 0);
            bloodyExplosion.Play();
            bloodyExplosion.gameObject.transform.parent = null;
            gameObject.SetActive(false);
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
