using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public GameObject cube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Input.mousePosition;
            Debug.Log("Clicked mouse at screen point: " + mousePos);
            Vector3 worldSpace = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
            Instantiate(cube, new Vector3(worldSpace.x, worldSpace.y, 0.0f), Quaternion.identity);
        }
	}
}
