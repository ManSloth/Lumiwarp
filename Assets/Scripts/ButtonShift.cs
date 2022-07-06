using UnityEngine;
using System.Collections;

public class ButtonShift : MonoBehaviour {

    float elapsed, speed;
    public float extraTranslation, amountToMove ;
    public int dir;
    public int PlayerNumber;
    float deltaTime;
    PlayGame2 sprintGame;
    PlayGame4 tugGame;

	// Use this for initialization
	void Start () {
        //Time.timeScale = 0.0f;
        speed = Screen.width * 0.4f;
        sprintGame = transform.parent.GetComponent<PlayGame2>();
        tugGame = transform.parent.GetComponent<PlayGame4>();
        amountToMove = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(PlayerNumber ==1)
            Player1Movement();
        if(PlayerNumber ==2)
            Player2Movement();
        if (GameData.data.game == 6)
            deltaTime = sprintGame.deltaTime;
        else
            deltaTime = tugGame.deltaTime;
        amountToMove = speed * deltaTime;
	}

    void Player1Movement()
    {
        if(dir ==1)
        {
            transform.position = new Vector3(transform.position.x + amountToMove, transform.position.y,
                transform.position.z);
            if(transform.localPosition.x >= 410f)
            {
                extraTranslation = transform.localPosition.x - 410;
                transform.localPosition = new Vector3(410f, transform.localPosition.y - extraTranslation,
                transform.localPosition.z);
                dir = 2;
            }
        }
        else if(dir ==2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - amountToMove,
                transform.position.z);
            if (transform.localPosition.y <= -700f)
            {
                extraTranslation = transform.localPosition.y + 700;
                transform.localPosition = new Vector3(transform.localPosition.x + extraTranslation, -700f,
                transform.localPosition.z);
                dir = 3;
            }
        }
        else if (dir == 3)
        {
            transform.position = new Vector3(transform.position.x - amountToMove, transform.position.y,
                transform.position.z);
            if (transform.localPosition.x <= -410f)
            {
                extraTranslation = transform.localPosition.x + 410;
                transform.localPosition = new Vector3(-410f, transform.localPosition.y - extraTranslation,
                transform.localPosition.z);
                dir = 4;
            }
        }
        else if (dir == 4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + amountToMove,
                transform.position.z);
            if (transform.localPosition.y >= -290f)
            {
                extraTranslation = transform.localPosition.y + 290;
                transform.localPosition = new Vector3(transform.localPosition.x + extraTranslation, -290f,
                transform.localPosition.z);
                dir = 1;
            }
        }
    }

    void Player2Movement()
    {
        if (dir == 1)
        {
            transform.position = new Vector3(transform.position.x - amountToMove, transform.position.y,
                transform.position.z);
            if (transform.localPosition.x <= -410f)
            {
                extraTranslation = transform.localPosition.x + 410;
                transform.localPosition = new Vector3(-410f, transform.localPosition.y- extraTranslation,
                transform.localPosition.z);
                dir = 2;
            }
        }
        else if (dir == 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + amountToMove,
                transform.position.z);
            if (transform.localPosition.y >= 700f)
            {
                extraTranslation = transform.localPosition.y - 700;
                transform.localPosition = new Vector3(transform.localPosition.x+ extraTranslation, 700f,
                transform.localPosition.z);
                dir = 3;
            }
        }
        else if (dir == 3)
        {
            transform.position = new Vector3(transform.position.x + amountToMove, transform.position.y,
                transform.position.z);
            if (transform.localPosition.x >= 410f)
            {
                extraTranslation = transform.localPosition.x - 410;
                transform.localPosition = new Vector3(410f, transform.localPosition.y-extraTranslation,
                transform.localPosition.z);
                dir = 4;
            }
        }
        else if (dir == 4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - amountToMove,
                transform.position.z);
            if (transform.localPosition.y <= 290f)
            {
                extraTranslation = transform.localPosition.y - 290;
                transform.localPosition = new Vector3(transform.localPosition.x+extraTranslation, 290f,
                transform.localPosition.z);
                dir = 1;
            }
        }
    }
}
