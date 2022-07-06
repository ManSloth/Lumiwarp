using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuLights : MonoBehaviour {

    public bool lighting;
    public GameObject prevLight;
    public float speed;
    float elapsed;

	// Use this for initialization
	void Start () {
        speed = 0.01f;
	
	}
	
	// Update is called once per frame
	void Update () {

        elapsed += Time.deltaTime;
        if(prevLight.GetComponent<MenuLights>().lighting)
        {
            if (prevLight.GetComponent<Image>().color.a >= 0.75f)
                lighting = true;
        }
	
        if(lighting)
        {
            if (elapsed >= speed)
            {
                Color c = GetComponent<Image>().color;
                GetComponent<Image>().color = new Color(c.r, c.g, c.b, c.a + 0.02f);
                elapsed = 0;
                if(GetComponent<Image>().color.a >= 1.0f)
                {
                    GetComponent<Image>().color = new Color(c.r, c.g, c.b, 1.0f);
                    lighting = false;
                }
            }
            
        }
        else
        {
            if (elapsed >= speed)
            {
                Color c = GetComponent<Image>().color;
                GetComponent<Image>().color = new Color(c.r, c.g, c.b, c.a - 0.02f);
                elapsed = 0;
                if(GetComponent<Image>().color.a <0)
                {
                    GetComponent<Image>().color = new Color(c.r, c.g, c.b, 0.0f);
                }
            }
        }

	}
}
