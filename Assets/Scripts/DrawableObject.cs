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
        if (tip)
        {

            Marker marker = tip.GetComponentInParent<Marker>();
            if (marker)
            {
                marker.SetMarkerDown(other.contacts[0].point, gameObject);

            }
        }
    }

    public void OnCollisionStay(Collision other)
    {

        MarkerTip tip = other.collider.GetComponent<MarkerTip>();
        if (tip)
        {
            Marker marker = tip.GetComponentInParent<Marker>();
            marker.DrawPoint(other.contacts[0].point, gameObject);
        }


    }

    public void OnCollisionExit(Collision other)
    {

        MarkerTip tip = other.collider.GetComponent<MarkerTip>();
        if (tip)
        {
            Marker marker = tip.GetComponentInParent<Marker>();
            marker.SetMarkerUp();

        }
    }
}