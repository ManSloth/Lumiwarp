using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public bool buttonPressed;
    //public Text isPress;
    int num;

	// Use this for initialization
	void Start () {
	
	}
	
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

	// Update is called once per frame
	void Update () {
        /*
        if (buttonPressed)
            num = 1;
        else
            num = 0;
        isPress.text = num.ToString();
         * */
	}
}
