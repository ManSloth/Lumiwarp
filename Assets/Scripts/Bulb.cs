using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bulb : MonoBehaviour {

    public Sprite red, blue, green, orange, yellow, purple;

    GameObject bulbImage;

    float elapsed, lightSpeedOn, lightSpeedOff, alpha;

	// Use this for initialization
	void Start () {
        bulbImage = transform.GetChild(0).gameObject;
        bulbImage.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        elapsed = 0;
        lightSpeedOn = 0.03f;
        lightSpeedOff = 0.06f;
        alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TurnRed()
    {
        bulbImage.GetComponent<Image>().sprite = red;
    }

    public void TurnBlue()
    {
        bulbImage.GetComponent<Image>().sprite = blue;
    }

    public void TurnGreen()
    {
        bulbImage.GetComponent<Image>().sprite = green;
    }

    public void TurnYellow()
    {
        bulbImage.GetComponent<Image>().sprite = yellow;
    }

    public void TurnOrange()
    {
        bulbImage.GetComponent<Image>().sprite = orange;
    }

    public void TurnPurple()
    {
        bulbImage.GetComponent<Image>().sprite = purple;
    }

    public void TurnOn()
    {
        if (alpha <= 1)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= lightSpeedOn)
            {
                alpha += 0.2f;
                elapsed = 0;
            }
            bulbImage.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
            
        }
        else
        {
            alpha = 1;
            bulbImage.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
        }
    }

    public void TurnOff()
    {
        if (alpha >= 0)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= lightSpeedOff)
            {
                alpha -= 0.2f;
                elapsed = 0;
            }
            bulbImage.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
        }
        else
        {
            alpha = 0;
            bulbImage.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
        }
    }

    public float Alpha()
    {
        return alpha;
    }
}
