using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 startingPosition;

    public GameObject target;
    public float lerpFactor;
    public float lerpMinimumDistance;


	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = target.transform.position;
        Vector3 cameraPosition = gameObject.transform.position;
        
        gameObject.transform.LookAt(targetPosition);

        // Find an offset from the target to move towards
        Vector3 lerpTarget = targetPosition;
        lerpTarget.y = cameraPosition.y;

        Vector3 targetToCameraVector = lerpTarget - cameraPosition;
        Vector3 offset = targetToCameraVector.normalized * lerpMinimumDistance;
        lerpTarget -= offset;

        gameObject.transform.position = Vector3.Lerp(
                cameraPosition,
                lerpTarget,
                lerpFactor);
	}

    public void Reset()
    {
        transform.position = startingPosition;
    }
}
