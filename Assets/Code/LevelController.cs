using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public bool useSkybox = true;
    public Color skyColor;

	// Use this for initialization
	void Awake () {
        
    }
	
	// Update is called once per frame
	void Update () {

        GameObject cameraObject = GameObject.Find("Main Camera");
        
        Camera camera = cameraObject.GetComponent<Camera>();

        if (useSkybox)
        {
            camera.clearFlags = CameraClearFlags.Skybox;
        }
        else
        {
            camera.backgroundColor = skyColor;
            camera.clearFlags = CameraClearFlags.SolidColor;
        }
    }
}
