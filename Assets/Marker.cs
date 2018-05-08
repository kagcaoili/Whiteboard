using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public LineRenderer scribble;
    public float width;
    public float offset;

    private Ray ray;
    private Vector3 lastPoint;

    public float detectingRadius;

	// Use this for initialization
	void Start () {
	}

    private bool isMoving(Vector3 lastPosition, Vector3 currentPos)
    {
        if (currentPos.x < (lastPosition.x - detectingRadius) && currentPos.x > (lastPosition.x + detectingRadius))
        {
            if (currentPos.y < (lastPosition.y - detectingRadius) && currentPos.y > (lastPosition.y + detectingRadius))
            {
                Debug.Log("Moving from " + lastPoint + " to " + currentPos);
                return true;
            }
        }

        return false;
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
                if (Input.GetMouseButtonDown(0))
                {
                    LineRenderer currScribble = (LineRenderer)Instantiate(scribble, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    currScribble.startWidth = width;
                    currScribble.endWidth = width;

                    currScribble.SetPosition(0, hit.point);

                    lastPoint = new Vector3(hit.point.x + offset, hit.point.y + offset, hit.point.z);

                    currScribble.SetPosition(1, lastPoint);

                } else if (Input.GetMouseButton(0))
                {
                    Debug.Log("Last Point: " + lastPoint);
                    Debug.Log("Currenet mosue position: " + hit.point);
                    if (isMoving(lastPoint, hit.point))
                    {
                        LineRenderer currScribble = (LineRenderer)Instantiate(scribble, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                        currScribble.startWidth = width;
                        currScribble.endWidth = width;

                        currScribble.SetPosition(0, lastPoint);
                        currScribble.SetPosition(1, hit.point);

                        lastPoint = hit.point;
                    }
                }
            }
        }
	}
}
