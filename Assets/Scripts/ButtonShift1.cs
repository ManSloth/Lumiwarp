using UnityEngine;
using System.Collections;

public class ButtonShift1 : MonoBehaviour {

    //Speed of the button's movement.
    float speed;
    public float difSpeed, extraTranslation;
    //direction button is moving.
    public int dir;
    

	// Use this for initialization
	void Start () {
        //Set the speed of the buttons movement
        //speed = Screen.width * difSpeed;

	}

    public void SetSpeed()
    {
        difSpeed = GameData.data.bSpeed;
        speed = Screen.width * difSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        SetSpeed();
        Player1Movement();
        GameData.data.fps = speed;
	}
    

    void Player1Movement()
    {
        //move the button right
        if(dir ==1)
        {
            //Set the position of the button to the current X plus the speed, relative to time.
            //transform.position = new Vector3(transform.position.x + (speed*Time.deltaTime), transform.position.y,
            //    transform.position.z);
            transform.Translate(speed * Time.deltaTime, 0, 0);
            //Cap movement border and change direction to down
            if(transform.localPosition.x >= 410f)
            {
                extraTranslation = transform.localPosition.x - 410;
                transform.localPosition = new Vector3(410f, transform.localPosition.y - extraTranslation,
                transform.localPosition.z);
                dir = 2;
            }
        }
        //move button down
        else if(dir ==2)
        {
            //Set the position of the button to the current Y minus the speed, relative to time.
            //transform.position = new Vector3(transform.position.x, transform.position.y - (speed*Time.deltaTime),
            //    transform.position.z);
            transform.Translate(0, -speed * Time.deltaTime, 0);
            //Cap movement border and change direction to Left
            if (transform.localPosition.y <= -680f)
            {
                extraTranslation = transform.localPosition.y + 680;
                transform.localPosition = new Vector3(transform.localPosition.x + extraTranslation, -680f,
                transform.localPosition.z);
                dir = 3;
            }
        }
        //move button left
        else if (dir == 3)
        {
            //Set the position of the button to the current X minus the speed, relative to time.
            //transform.position = new Vector3(transform.position.x - (speed*Time.deltaTime), transform.position.y,
            //    transform.position.z);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            //Cap movement border and change direction to Up
            if (transform.localPosition.x <= -410f)
            {
                extraTranslation = transform.localPosition.x + 410;
                transform.localPosition = new Vector3(-410f, transform.localPosition.y - extraTranslation,
                transform.localPosition.z);
                dir = 4;
            }
        }
        //Move button up
        else if (dir == 4)
        {
            //Set the position of the button to the current Y plus the speed, relative to time.
            //transform.position = new Vector3(transform.position.x, transform.position.y + (speed*Time.deltaTime),
            //    transform.position.z);
            transform.Translate(0, speed * Time.deltaTime, 0);
            //Cap movement border and change direction to Right
            if (transform.localPosition.y >= -270.0f)
            {
                extraTranslation = transform.localPosition.y + 270;
                transform.localPosition = new Vector3(transform.localPosition.x + extraTranslation, -270.0f,
                transform.localPosition.z);
                dir = 1;
            }
        }
    }
}
