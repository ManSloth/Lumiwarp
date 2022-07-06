using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HueChange : MonoBehaviour {
    float h, s, v;
    float elapsed;
    Light l;

	// Use this for initialization
	void Start () {
        h = 0;
        s = 0;
        v = 0;
        elapsed = 0;
        if(transform.GetComponent<Light>() != null)
            l = transform.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.unscaledDeltaTime;

        if (elapsed >= 0.01f)
        {
            if (l != null)
            {
                Color.RGBToHSV(l.color, out h, out s, out v);
                h += 0.0027f;
                if (h >= 1)
                    h = 0;
                l.color = Color.HSVToRGB(h, s, v);
                elapsed = 0;
            }
        }
        if (elapsed >= 0.01f)
        {
            if (transform.GetComponent<Text>() != null)
            {
                Color.RGBToHSV(transform.GetComponent<Text>().color, out h, out s, out v);
                h += 0.004f;
                if (h >= 1)
                    h = 0;
                transform.GetComponent<Text>().color = Color.HSVToRGB(h, s, v);
                elapsed = 0;
            }
        }

        //transform.GetComponent<Image>().color.
	}
}
