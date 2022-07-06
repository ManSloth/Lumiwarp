using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTransition : MonoBehaviour {

    GameObject topDoor, bottomDoor;
    public float speed;
    public bool doorsClosing;
    Vector2 movement;
    public bool closed, opened, closePlayed;

    public Sprite shift, classic, sequence, memory, sprint, tug, blank;

    public GameObject menu;

    AudioSource doorMoving, doorClosed;

	// Use this for initialization
	void Start () {
        topDoor = transform.GetChild(0).gameObject;
        bottomDoor = transform.GetChild(1).gameObject;
        doorsClosing = false;
        closed = false;
        opened = true;
        doorMoving = GetComponent<AudioSource>();
        doorClosed = transform.GetChild(4).GetComponent<AudioSource>();
        closePlayed = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        doorMoving.volume = GameData.data.fxVol * 0.4f;
        doorClosed.volume = GameData.data.fxVol * 0.4f;
        float height = Screen.height;
        movement = new Vector3(0, speed * Time.unscaledDeltaTime * height,0);
        if(doorsClosing)
        {
            opened = false;
            if (!closed)
            {
                if (topDoor.transform.localPosition.y > 515f)
                    topDoor.transform.Translate(new Vector3(0, -movement.y, 0));
                if (topDoor.transform.localPosition.y < 515f)
                {
                    topDoor.transform.localPosition = new Vector3(0, 515, 0);
                    closed = true;
                }
                if (bottomDoor.transform.localPosition.y < -515f)
                    bottomDoor.transform.Translate(new Vector3(0, -movement.y, 0));
                if (bottomDoor.transform.localPosition.y > -515)
                {
                    bottomDoor.transform.localPosition = new Vector3(0, -515, 0);
                }
            }
        }
        else
        {
            if (topDoor.transform.localPosition.y < 2000f)
            {
                topDoor.transform.Translate(new Vector3(0, movement.y, 0));
                closed = false;
            }
            if (topDoor.transform.localPosition.y > 2000f)
            {
                doorMoving.Stop();
                topDoor.transform.localPosition = new Vector3(0, 2000, 0);
                opened = true;
                transform.GetChild(0).transform.GetChild(2).transform.gameObject.SetActive(false);
                if (menu.activeSelf)
                    GameData.data.game = 0;
            }
            if (bottomDoor.transform.localPosition.y > -2000f)
                bottomDoor.transform.Translate(new Vector3(0, movement.y, 0));
            if (bottomDoor.transform.localPosition.y < -2000f)
            {
                bottomDoor.transform.localPosition = new Vector3(0, -2000, 0);
            }
        }

        if (closed)
        {
            if(!closePlayed)
            {
                doorClosed.Play();
                closePlayed = true;
            }
            doorMoving.Stop();
            if (!menu.activeSelf)
            {
                if (GameData.data.game == 1 || GameData.data.game == 5 || GameData.data.game == 8)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.GetComponent<Difficulty>().Grow();
                }
                else
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                    transform.GetChild(3).gameObject.GetComponent<Difficulty>().Grow();
                }
            }
        }

        TrialVersion();
    }

    public void CloseDoors()
    {
        closePlayed = false;
        doorMoving.Play();
        doorsClosing = true;
        if (GameData.data.game == 0)
        {
            transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = blank;
        }

        if (!Social.localUser.authenticated)
        {
            if (opened)
            {
                if (GameData.data.game == 1 || GameData.data.game == 5 || GameData.data.game == 8 || GameData.data.game == 3)
                {
                    topDoor.transform.GetChild(1).gameObject.SetActive(true);
                    bottomDoor.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    topDoor.transform.GetChild(1).gameObject.SetActive(false);
                    bottomDoor.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            else
            {
                topDoor.transform.GetChild(1).gameObject.SetActive(false);
                bottomDoor.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            topDoor.transform.GetChild(1).gameObject.SetActive(false);
            bottomDoor.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OpenDoors()
    {
        doorMoving.Play();
        if (GameData.data.game == 1 || GameData.data.game == 5 || GameData.data.game == 8 || GameData.data.game == 3)
        {
            //topDoor.transform.GetChild(1).gameObject.SetActive(true);
            //bottomDoor.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            topDoor.transform.GetChild(1).gameObject.SetActive(false);
            bottomDoor.transform.GetChild(0).gameObject.SetActive(false);
        }
        transform.GetChild(3).gameObject.GetComponent<Difficulty>().shrink = true;
        transform.GetChild(2).gameObject.GetComponent<Difficulty>().shrink = true;
        doorsClosing = false;
    }

    public void TrialVersion()
    {
        if (GameData.data.trialBuild)
        {
            if (GameData.data.trialTimeLeft <= 0)
            {
                transform.GetChild(2).transform.GetChild(1).GetComponent<Button>().interactable = false;
            }
        }
        else
        {

        }
    }
}
