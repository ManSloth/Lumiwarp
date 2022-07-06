using UnityEngine;
using System.Collections;

public class ImagePulse : MonoBehaviour {

    float scale;
    bool up;

	// Use this for initialization
	void Start () {
        scale = 1;
        up = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(scale, scale, scale);

        if (up)
        {
            scale += 0.005f;
            if(scale >= 1)
            {
                up = false;
            }
        }
        else
        {
            scale -= 0.005f;
            if(scale <= 0.8f)
            {
                up = true;
            }
        }
	}
}
