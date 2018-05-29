using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawableObject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnCollisionEnter(Collision other)
    {

        MarkerTip tip = other.collider.GetComponent<MarkerTip>();
        StartDraw(tip, other.contacts[0].point);
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
    }

    public void OnTriggerEnter(Collider other)
    {

        MarkerTip tip = other.GetComponent<MarkerTip>();
        Vector3 pos = other.ClosestPointOnBounds(other.transform.position);
        StartDraw(tip, pos);


    }

    public void OnTriggerStay(Collider other)
    {
        MarkerTip tip = other.GetComponent<MarkerTip>();
        Vector3 pos = other.ClosestPointOnBounds(other.transform.position);
        Draw(tip, pos);
    }

    public void OnTriggerExit(Collider other)
    {
        MarkerTip tip = other.GetComponent<MarkerTip>();
        StopDraw(tip);
    }

    public void StartDraw(MarkerTip tip, Vector3 point)
    {
        if (tip)
        {

            Marker marker = tip.GetComponentInParent<Marker>();
            if (marker)
            {
                marker.SetMarkerDown(point, gameObject);

            }
        }
    }

    public void Draw(MarkerTip tip, Vector3 point)
    {

        if (tip)
        {
            Marker marker = tip.GetComponentInParent<Marker>();
            marker.DrawPoint(point, gameObject);
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