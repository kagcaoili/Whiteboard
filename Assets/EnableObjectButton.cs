using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableObjectButton : MonoBehaviour {

    private static EnableObjectButton activeButton;
    public GameObject objectToEnable;

    public static Color inactiveColor = Color.white;
    public static Color activeColor = Color.green;

    public void ToggleUI()
    {
        if (objectToEnable != null)
        {

            if (!objectToEnable.activeSelf && activeButton != this)
            {
                if (activeButton != null)
                {
                    activeButton.SetEnabled(false);
                    activeButton = this;
                }
            }
            else if (objectToEnable.activeSelf)
            {
                activeButton = null;
            }

            objectToEnable.SetActive(!objectToEnable.activeSelf);
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
            }
            else
            {
                SetButtonColor(inactiveColor);
            }

        }
    }

    private void SetButtonColor(Color color)
    {

        GetComponent<Image>().color = color;

    }
}
