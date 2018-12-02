using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public bool useSkybox = true;
    public bool useFog = false;
    public Color skyColor;
    public Material skyboxMaterial;

	// Use this for initialization
	void Awake () {
        
    }
	
	// Update is called once per frame
	void Update () {

        GameObject cameraObject = GameObject.Find("Main Camera");
        
        Camera camera = cameraObject.GetComponent<Camera>();

        RenderSettings.fog = useFog;
        RenderSettings.fogColor = skyColor;
        RenderSettings.skybox = skyboxMaterial;

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
