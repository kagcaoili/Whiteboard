using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChangeButton : MonoBehaviour {

    public Material skybox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSykbox()
    {

        RenderSettings.skybox = skybox;
        Debug.Log("IT WORKED!");
    }
}
