using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedColorChange : MonoBehaviour {

    ButtonPressed thisButton;
    public Color thisColor;
    Text thisText;
    public int color;

    void Start()
    {
        thisButton = transform.GetComponent<ButtonPressed>();
        //thisColor = transform.GetChild(0).GetComponent<Text>().color;
        thisText = transform.GetChild(0).GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (color == 0)
        {
            if (thisButton.buttonPressed)
            {
                thisText.color = Color.HSVToRGB(0.0f, 1.0f, 0.8f);
            }
            else
            {
                thisText.color = Color.HSVToRGB(0.0f, 1.0f, 1.0f);
            }
        }

        else if (color == 1)
        {
            if (thisButton.buttonPressed)
            {
                thisText.color = Color.HSVToRGB(0.15f, 1.0f, 0.8f);
            }
            else
            {
                thisText.color = Color.HSVToRGB(0.15f, 1.0f, 1.0f);
            }
        }

    }
}
