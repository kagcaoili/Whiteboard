using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableObjectButton : MonoBehaviour {

    private static EnableObjectButton activeButton;
    public GameObject objectToEnable;
    public bool mutuallyExclusive = true;

    public static Color inactiveColor = Color.white;
    public static Color activeColor = Color.green;

    private bool firstFrame = true;

    public void Start()
    {

        SetButtonColor(inactiveColor);
        SetEnabled(false);
   
    }

    public void Update()
    {


    }

    public void ToggleObject()
    {
        if (objectToEnable != null)
        {

            if (!objectToEnable.activeSelf && activeButton != this)
            {

                if (activeButton != null && mutuallyExclusive)
                {

                    activeButton.SetEnabled(false);
                    activeButton = this;
                }
            }
            else if (objectToEnable.activeSelf && mutuallyExclusive)
            {
                activeButton = null;
            }

            SetEnabled(!objectToEnable.activeSelf);
        }
    }

    public void SetEnabled(bool enabled)
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(enabled);
            
            if (enabled)
            {
                SetButtonColor(activeColor);

                if (mutuallyExclusive)
                {
                    activeButton = this;

                }
            }
            else
            {
                SetButtonColor(inactiveColor);

                if (objectToEnable.GetComponent<DrawableObject>())
                {

                    foreach (LineRenderer child in objectToEnable.GetComponentsInChildren<LineRenderer>())
                    {

                        GameObject.Destroy(child.gameObject);

                    }

                }

            }

        }
    }

    private void SetButtonColor(Color color)
    {

        GetComponent<Image>().color = color;

    }
}
