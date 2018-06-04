using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTip : MonoBehaviour {


    public bool drawPrepped = false;
    public bool drawing = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PrepDraw()
    {
        if (!drawing)
        {
            drawPrepped = true;
        }

    }

    public void EndDraw()
    {
        if (drawing)
        {
            drawPrepped = false;
            drawing = false;
        }
    }
}
