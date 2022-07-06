using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 1 + Time.unscaledDeltaTime));
        if(transform.rotation.z >= 360)
        {
            float leftOver = transform.rotation.z - 360;
            transform.rotation = new Quaternion(0, 0, leftOver, 0);
        }
	}
}
