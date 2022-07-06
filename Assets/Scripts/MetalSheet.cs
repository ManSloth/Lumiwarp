using UnityEngine;
using System.Collections;

public class MetalSheet : MonoBehaviour {

    public int player;

    int speed;

    public bool active;

    int screenW;

    bool dust, dust2;
    bool doorIsClosed, doorIsClosed2;
    bool doorIsMoving, doorIsMoving2;
    bool neutral;

    AudioSource doorMoving, doorClosed;
    

	// Use this for initialization
	void Start () {
        dust = false;
        dust2 = false;
        doorIsClosed = false;
        doorIsClosed2 = false;
        doorIsMoving = false;
        doorIsMoving2 = false;
        neutral = true;
        speed = 3 * Screen.height;
        active = false;
        doorMoving = transform.parent.parent.GetChild(3).GetComponent<AudioSource>();
        doorClosed = transform.parent.parent.GetChild(4).GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
            Activate();
        else
        {
            if(!neutral)
                Deactivate();
        }
    
        doorMoving.volume = GameData.data.fxVol * 0.4f;
        doorClosed.volume = GameData.data.fxVol * 0.4f;
	}

    public void Activate()
    {
        neutral = false;
        if (GameData.data.game == 2 || GameData.data.game == 4)
        {
            if (player == 1)
            {
                if (!doorIsClosed)
                {
                    if (!doorIsMoving)
                    {
                        doorMoving.Play();
                        doorIsMoving = true;
                    }
                    if (transform.localPosition.y <= -650f)
                        transform.Translate(0, speed * Time.deltaTime, 0);
                    if (transform.localPosition.y >= -650f)
                    {
                        doorClosed.Play();
                        doorMoving.Pause();
                        doorIsClosed = true;
                        doorIsMoving = false;
                        if (!dust)
                        {
                            transform.GetChild(0).transform.GetComponent<SpriteAnimation>().StartParticle();
                            //transform.parent.transform.parent.transform.GetChild(5).GetChild(0).GetComponent<UIParticleEmitter>().Reset();
                            dust = true;
                        }
                        transform.localPosition = new Vector3(0, -650, 0);
                    }
                }
            }
            else if (player == 2)
            {
                if (!doorIsClosed2)
                {
                    if (!doorIsMoving2)
                    {
                        doorMoving.Play();
                        doorIsMoving2 = true;
                    }
                    if (transform.localPosition.y >= 650f)
                        transform.Translate(0, speed * Time.deltaTime, 0);
                    if (transform.localPosition.y <= 650f)
                    {
                        doorClosed.Play();
                        doorMoving.Pause();
                        doorIsClosed2 = true;
                        doorIsMoving2 = false;
                        if (!dust2)
                        {
                            transform.GetChild(0).transform.GetComponent<SpriteAnimation>().StartParticle();
                            //transform.parent.transform.parent.transform.GetChild(5).GetChild(1).GetComponent<UIParticleEmitter>().Reset();
                            dust2 = true;
                        }
                        transform.localPosition = new Vector3(0, 650, 0);
                    }
                }
            }
        }
        else if (GameData.data.game == 6 || GameData.data.game == 7)
        {
            if (player == 1)
            {
                if (!doorIsClosed)
                {
                    if (!doorIsMoving)
                    {
                        doorMoving.Play();
                        doorIsMoving = true;
                    }
                    if (transform.localPosition.y <= -595f)
                        transform.Translate(0, speed * Time.deltaTime, 0);
                    if (transform.localPosition.y >= -595f)
                    {
                        doorClosed.Play();
                        doorMoving.Pause();
                        doorIsClosed = true;
                        doorIsMoving = false;
                        if (!dust)
                        {
                            transform.GetChild(0).transform.GetComponent<SpriteAnimation>().StartParticle();
                            //transform.parent.transform.parent.transform.GetChild(5).GetChild(0).GetComponent<UIParticleEmitter>().Reset();
                            dust = true;
                        }
                        transform.localPosition = new Vector3(0, -595, 0);
                    }
                }
            }
            else if (player == 2)
            {
                if (!doorIsClosed2)
                {
                    if (!doorIsMoving2)
                    {
                        doorMoving.Play();
                        doorIsMoving2 = true;
                    }
                    if (transform.localPosition.y >= 595f)
                        transform.Translate(0, speed * Time.deltaTime, 0);
                    if (transform.localPosition.y <= 595f)
                    {
                        doorClosed.Play();
                        doorMoving.Pause();
                        doorIsClosed2 = true;
                        doorIsMoving2 = false;
                        if (!dust2)
                        {
                            transform.GetChild(0).transform.GetComponent<SpriteAnimation>().StartParticle();
                            //transform.parent.transform.parent.transform.GetChild(5).GetChild(1).GetComponent<UIParticleEmitter>().Reset();
                            dust2 = true;
                        }
                        transform.localPosition = new Vector3(0, 595, 0);
                    }
                }
            }
        }
    }

    public void Deactivate()
    {
        if (GameData.data.game == 2 || GameData.data.game == 4)
        {
            if (player == 1)
            {
                if (!doorIsMoving)
                {
                    doorMoving.Play();
                    doorIsClosed = false;
                    doorIsMoving = true;
                }
                dust = false;
                if (transform.localPosition.y >= -1920f)
                    transform.Translate(0, -speed * Time.deltaTime, 0);
                if (transform.localPosition.y <= -1920f)
                {
                    transform.localPosition = new Vector3(0, -1920, 0);
                    doorMoving.Pause();
                    doorIsMoving = false;
                    neutral = true;
                }
            }
            else if (player == 2)
            {
                if (!doorIsMoving2)
                {
                    doorMoving.Play();
                    doorIsClosed2 = false;
                    doorIsMoving2 = true;
                }
                dust2 = false;
                if (transform.localPosition.y <= 1920f)
                    transform.Translate(0, -speed * Time.deltaTime, 0);
                if (transform.localPosition.y >= 1920f)
                {
                    transform.localPosition = new Vector3(0, 1920, 0);
                    doorMoving.Pause();
                    doorIsMoving2 = false;
                    neutral = true;
                }
            }
        }
        if (GameData.data.game == 6 || GameData.data.game == 7)
        {
            if (player == 1)
            {
                if (!doorIsMoving)
                {
                    doorMoving.Play();
                    doorIsClosed = false;
                    doorIsMoving = true;
                }
                dust = false;
                if (transform.localPosition.y >= -1920f)
                    transform.Translate(0, -speed * Time.deltaTime, 0);
                if (transform.localPosition.y <= -1920f)
                {
                    transform.localPosition = new Vector3(0, -1920, 0);
                    doorMoving.Pause();
                    doorIsMoving = false;
                    neutral = true;
                }
            }
            else if (player == 2)
            {
                if (!doorIsMoving2)
                {
                    doorMoving.Play();
                    doorIsClosed2 = false;
                    doorIsMoving2 = true;
                }
                dust2 = false;
                if (transform.localPosition.y <= 1920f)
                    transform.Translate(0, -speed * Time.deltaTime, 0);
                if (transform.localPosition.y >= 1920f)
                {
                    transform.localPosition = new Vector3(0, 1920, 0);
                    doorMoving.Pause();
                    doorIsMoving2 = false;
                    neutral = true;
                }
            }
        }
    }
}
