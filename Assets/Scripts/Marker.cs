using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public Color markerColor = Color.blue;
    public float markerWidth = 0.005f;

    private ushort hapticTime = 100;

    private LineRenderer activeRenderer;
    private GameObject activeObject;
    private int activeDrawIndex = 1;

    private NewtonVR.NVRHand grabbingHand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    private LineRenderer CreateNewScribble(Vector3 startPoint, GameObject parent)
    {

        if (activeObject != null || activeRenderer != null)
        {
            SetMarkerUp();
        }

        GameObject scribbleObject = new GameObject();
        scribbleObject.transform.parent = parent.transform;

        LineRenderer scribble = scribbleObject.AddComponent<LineRenderer>();
        scribble.useWorldSpace = false;
        scribble.material = new Material(Shader.Find("Sprites/Default"));

        scribble.startColor = markerColor;
        scribble.endColor = markerColor;
        scribble.startWidth = markerWidth;
        scribble.endWidth = markerWidth;
        scribble.SetPosition(0, startPoint);
        scribble.SetPosition(1, startPoint);
        scribble.alignment = LineAlignment.Local;

        activeObject = parent;

        return scribble;

    }

    public void SetMarkerDown(Vector3 initialPosition, GameObject sourceObject)
    {

        if (!IsCloseToZero(initialPosition))
        {
            activeRenderer = CreateNewScribble(initialPosition, sourceObject);

        }
    }

    public void SetMarkerUp()
    {
        activeRenderer = null;
        activeObject = null;
        activeDrawIndex = 1;
    }
    
    public void DrawPoint(Vector3 position, GameObject sourceObject)
    {
        Debug.Log("Drawing at " + position);

        if (activeRenderer && !IsCloseToZero(position) && sourceObject == activeObject)
        {
            activeRenderer.positionCount = activeDrawIndex + 1;
            activeRenderer.SetPosition(activeDrawIndex++, position);
            TriggerDrawHaptic();
        }
        else if (activeRenderer == null)
        {
            CreateNewScribble(position, sourceObject);
        }
    }

    public NewtonVR.NVRHand GetGrabbingHand()
    {

        return GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand;


    }

    private void TriggerDrawHaptic()
    {


        NewtonVR.NVRHand hand = GetGrabbingHand();
        if (hand != null)
        {
            hand.TriggerHapticPulse(hapticTime, NewtonVR.NVRButtons.Touchpad);
        }

    }

    public bool IsCloseToZero(Vector3 vector)
    {

        if (Mathf.Abs(vector.x) <= 0.01f && Mathf.Abs(vector.y) <= 0.01f && Mathf.Abs(vector.z) <= 0.01f)
        {
            return true;
        }

        return false;


    }
}
