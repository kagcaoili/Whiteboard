using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawableObject : MonoBehaviour
{

    private float z;

    private float lineZ;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }

    /*
    public void OnCollisionEnter(Collision other)
    {

        MarkerTip tip = other.collider.GetComponent<MarkerTip>();
        StartDraw(tip, other.contacts[0].point);

        foreach (Rigidbody body in other.collider.GetComponentsInParent<Rigidbody>())
        {

            body.freezeRotation = true;

        }
    }
    
    public void OnCollisionStay(Collision other)
    {

        MarkerTip tip = other.collider.GetComponent<MarkerTip>();
        Draw(tip, other.contacts[0].point);

    }

    public void OnCollisionExit(Collision other)
    {

        MarkerTip tip = other.collider.GetComponent<MarkerTip>();
        StopDraw(tip);

        foreach (Rigidbody body in other.collider.GetComponentsInParent<Rigidbody>())
        {

            body.freezeRotation = false;


        }
    }
    */



    public void OnTriggerEnter(Collider other)
    {

        MarkerTip tip = other.GetComponent<MarkerTip>();

        if (tip && tip.drawPrepped && !tip.drawing)
        {
            Vector3 pos = GetComponent<Collider>().ClosestPointOnBounds(other.transform.position);
            lineZ = pos.z;
            StartDraw(tip, pos);
           
            Debug.Log("SETTING LINE Z");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        MarkerTip tip = other.GetComponent<MarkerTip>();

        if (tip && tip.drawing)
        {
            Vector3 pos = GetComponent<Collider>().ClosestPointOnBounds(other.transform.position);
            Draw(tip, pos);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        MarkerTip tip = other.GetComponent<MarkerTip>();

        if (tip && !tip.drawing)
        {
            StopDraw(tip);
            Debug.Log("Stopping draw!");
        }
    }

    
    public void StartDraw(MarkerTip tip, Vector3 point)
    {
        if (tip)
        {

            Marker marker = tip.GetComponentInParent<Marker>();
            if (marker)
            {
                z = marker.transform.position.z;
                marker.SetMarkerDown(point, gameObject);
                tip.drawing = true;

            }
        }
    }

    public void Draw(MarkerTip tip, Vector3 point)
    {

        if (tip)
        {
            Marker marker = tip.GetComponentInParent<Marker>();
            point.z = lineZ;
            marker.DrawPoint(point, gameObject);
            marker.transform.position = new Vector3(marker.transform.position.x, marker.transform.position.y, z);
        }
    }

    public void StopDraw(MarkerTip tip)
    {
        if (tip)
        {
            Marker marker = tip.GetComponentInParent<Marker>();
            marker.SetMarkerUp();

        }
    }
}