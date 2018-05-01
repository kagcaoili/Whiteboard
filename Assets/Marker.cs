using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public LineRenderer scribble;
    public float width;
    public float offset;

    private Ray ray;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<Whiteboard>())
            {
                if (Input.GetMouseButton(0))
                {
                    //Vector3 worldSpace = Camera.main.ScreenToWorldPoint(new Vector3(hit.point.x, hit.point.y, 10.0f));
                    LineRenderer currScribble = (LineRenderer)Instantiate(scribble, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    currScribble.startWidth = width;
                    currScribble.endWidth = width;

                    currScribble.SetPosition(0, hit.point);
                    currScribble.SetPosition(1, new Vector3(hit.point.x + offset, hit.point.y + offset, hit.point.z));
                }
            }
        }
	}
}
