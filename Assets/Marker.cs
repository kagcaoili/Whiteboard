using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public LineRenderer scribble;
    public float width;
    public float offset;

    private Ray ray;
    private Vector3 lastPoint;

    public float threshold;

    private GameObject controller;

	// Use this for initialization
	void Start () {
	}

    // check if the user moved their marker more than a certain distance to be considered as a 'movement'
    private bool IsMoving(Vector3 lastPosition, Vector3 currentPos)
    {
        float difference = Vector3.Distance(lastPosition, currentPos);

        return difference > threshold;

    }

    private void Draw_VR()
    {

        Vector3 position = controller.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(position, transform.forward, out hit))
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

                    currScribble.transform.parent = hit.collider.gameObject.transform;

                }
                else if (Input.GetMouseButton(0))
                {
                    if (IsMoving(lastPoint, hit.point))
                    {
                        LineRenderer currScribble = (LineRenderer)Instantiate(scribble, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                        currScribble.startWidth = width;
                        currScribble.endWidth = width;

                        currScribble.SetPosition(0, lastPoint);
                        currScribble.SetPosition(1, hit.point);

                        lastPoint = hit.point;

                        currScribble.transform.parent = hit.collider.gameObject.transform;
                    }
                }
            }
        }
    }

    private void Draw_Mouse()
    {
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

                    currScribble.transform.parent = hit.collider.gameObject.transform;

                }
                else if (Input.GetMouseButton(0))
                {
                    if (IsMoving(lastPoint, hit.point))
                    {
                        LineRenderer currScribble = (LineRenderer)Instantiate(scribble, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                        currScribble.startWidth = width;
                        currScribble.endWidth = width;

                        currScribble.SetPosition(0, lastPoint);
                        currScribble.SetPosition(1, hit.point);

                        lastPoint = hit.point;

                        currScribble.transform.parent = hit.collider.gameObject.transform;
                    }
                }
            }
        }
    }
	


	// Update is called once per frame
	void Update () {
        Draw_Mouse();
        Draw_VR();
    }

}
