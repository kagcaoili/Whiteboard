using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public LineRenderer scribble;
    public float width;
    public float offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log("Clicked mouse at screen point: " + mousePos);
            Vector3 worldSpace = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
            LineRenderer currScribble = (LineRenderer) Instantiate(scribble, new Vector3(worldSpace.x, worldSpace.y, 0.0f), Quaternion.identity);
            currScribble.startWidth = width;
            currScribble.endWidth = width;

            currScribble.SetPosition(0, worldSpace);
            currScribble.SetPosition(1, new Vector3(worldSpace.x+offset, worldSpace.y+offset, worldSpace.z));
        }
	}
}
