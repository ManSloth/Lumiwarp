using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePulse : MonoBehaviour {
    
    bool pulseUp;
    float elapsed;
    float scale;
    float speed;

    float maxSize, minSize;

	// Use this for initialization
	void Start () {
        //text = transform.GetComponent<Text>();
        pulseUp = false;
        elapsed = 0;
        scale = 1.0f;
        speed = 0.01f;
        maxSize = 1.15f;
        minSize = 0.85f;

    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsed += Time.unscaledDeltaTime;
	    if(!pulseUp)
        {
            if (elapsed >= 0.016)
            {
                scale -= Time.unscaledDeltaTime*0.5f;
                elapsed = 0;
            }
            if(scale <= minSize)
            {
                scale = minSize;
                pulseUp = true;
            }
        }
        else
        {
            if (elapsed >= 0.016)
            {
                scale += Time.unscaledDeltaTime*0.5f;
                elapsed = 0;
            }
            if (scale >= maxSize)
            {
                scale = maxSize;
                pulseUp = false;
            }
        }
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
