using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flicker : MonoBehaviour {

    float destTint, curTint;
    float elapsed, elapsed2;
    bool flickering;

    bool flickerOn;

	// Use this for initialization
	void Start () {
        destTint = 255;
        curTint = 255;
        elapsed = 0;
        elapsed2 = 0;
        flickering = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (flickerOn)
        {
            if (!flickering)
            {
                elapsed += Time.deltaTime;
                if (elapsed >= 0.05f)
                {
                    int num = Random.Range(1, 25);
                    if (num == 2)
                    {
                        destTint = Random.Range(220, 255);
                        flickering = true;
                        elapsed = 0;
                    }
                }
            }
            else
            {
                elapsed2 += Time.deltaTime;
                float tintDiff = curTint - destTint;
                if (tintDiff > 0)
                {
                    if (elapsed2 >= 0.05)
                    {
                        curTint -= 10;
                        elapsed2 = 0;
                    }
                    if (curTint <= destTint)
                        destTint = 255;
                }
                else if (tintDiff <= 0)
                {
                    if (elapsed2 >= 0.05)
                    {
                        curTint += 10;
                        elapsed2 = 0;
                    }
                    if (curTint >= destTint)
                    {
                        curTint = destTint;
                        flickering = false;
                    }
                }
                GetComponent<Image>().color = new Color(curTint / 255, curTint / 255, curTint / 255, 255);
            }
        }
    }

    public void TurnOn()
    {
        flickerOn = true;
    }

}
