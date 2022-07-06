using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using GooglePlayGames;

//////////////////////////Memory 1 player///////////////////////////////////

public class PlayGame3 : MonoBehaviour {

    float timePlayed;
    
    Button red, blue, green, yellow, orange, purple;
    ButtonPressed redPressed, bluePressed, greenPressed, yellowPressed, orangePressed, purplePressed;
    Bulb bulb;

    Text score, finalScore;


    float elapsed, elapsed2, gameSpeed, clickTimer;

    int scoreValue, nextColor, oldScore, curSeqColor;

    bool canClick, buttonClicked, lose, buzzPlayed, addColor, playSequence, pushSequence;
    bool redPrev, greenPrev, bluePrev, yellowPrev, orangePrev, purplePrev, turnOn, scorePosted;

    public GameObject buttonSound, buzzerSound, lightSound, discoMode, background;
    GameObject lightColor, lightBulb, stopGo, loseScreen, uiElements;
    List<int> sequence;

    public Sprite wait, go;
    Image waitGo;

    AudioSource buttonPlay, lightPlay, buzzPlay;

    SpriteAnimation particle;

    AccessLeaderboard lb;

    //public GameObject eventData;

    // Use this for initialization
    void Start () {

        if (GameData.data.discoMode)
            discoMode.SetActive(true);
        else
            discoMode.SetActive(false);

        red = transform.GetChild(0).GetChild(2).gameObject.GetComponent<Button>();
        orange = transform.GetChild(0).GetChild(3).gameObject.GetComponent<Button>();
        purple = transform.GetChild(0).GetChild(4).gameObject.GetComponent<Button>();
        green = transform.GetChild(0).GetChild(5).gameObject.GetComponent<Button>();
        blue = transform.GetChild(0).GetChild(6).gameObject.GetComponent<Button>();
        yellow = transform.GetChild(0).GetChild(7).gameObject.GetComponent<Button>();

        redPressed = red.GetComponent<ButtonPressed>();
        orangePressed = orange.GetComponent<ButtonPressed>();
        purplePressed = purple.GetComponent<ButtonPressed>();
        greenPressed = green.GetComponent<ButtonPressed>();
        bluePressed = blue.GetComponent<ButtonPressed>();
        yellowPressed = yellow.GetComponent<ButtonPressed>();


        score = transform.GetChild(0).GetChild(9).gameObject.GetComponent<Text>();
        finalScore = transform.GetChild(1).GetChild(2).GetComponent<Text>();

        stopGo = transform.GetChild(0).GetChild(11).gameObject;
        waitGo = stopGo.GetComponent<Image>();

        lightColor = transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        lightBulb = transform.GetChild(0).GetChild(1).gameObject;
        bulb = lightBulb.GetComponent<Bulb>();

        lightSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buzzerSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buttonSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        
        buttonPlay = buttonSound.GetComponent<AudioSource>();
        lightPlay = lightSound.GetComponent<AudioSource>();
        buzzPlay = buzzerSound.GetComponent<AudioSource>();

        particle = transform.GetChild(0).GetChild(10).GetComponent<SpriteAnimation>();

        lb = transform.GetChild(1).transform.GetChild(3).GetComponent<AccessLeaderboard>();

        loseScreen = transform.GetChild(1).gameObject;
        uiElements = transform.GetChild(0).gameObject;

        redPrev = false;
        bluePrev = false;
        greenPrev = false;
        yellowPrev = false;
        orangePrev = false;
        purplePrev = false;
        turnOn = false;
        scorePosted = false;

        elapsed = 0;
        elapsed2 = 0;
        gameSpeed = 0;
        oldScore = -1;
        curSeqColor = 0;
        timePlayed = 0;

        canClick = false;
        buttonClicked = false;
        lose = false;
        buzzPlayed = false;
        addColor = true;
        playSequence = false;
        pushSequence = false;


        sequence = new List<int>();
        sequence.Add(0);

        if (!Social.localUser.authenticated)
            transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        timePlayed += Time.deltaTime;
        score.text = scoreValue.ToString();
        gameSpeed = 1.0f;
        elapsed += Time.deltaTime;
        
        if (addColor)
        {
            nextColor = Random.Range(1, 7);
            sequence.Add(nextColor);
            addColor = false;
            playSequence = true;
            elapsed = 0;
        }

        if(playSequence)
        {
            waitGo.sprite = wait;
            if(elapsed >= gameSpeed)
            {
                
                curSeqColor++;
                if (curSeqColor < sequence.Count)
                {
                    lightPlay.Play();
                    if (sequence[curSeqColor] == 1)
                    {
                        bulb.TurnRed();
                    }
                    if (sequence[curSeqColor] == 2)
                    {
                        bulb.TurnGreen();
                    }
                    if (sequence[curSeqColor] == 3)
                    {
                        bulb.TurnBlue();
                    }
                    if (sequence[curSeqColor] == 4)
                    {
                        bulb.TurnYellow();
                    }
                    if (sequence[curSeqColor] == 5)
                    {
                        bulb.TurnOrange();
                    }
                    if (sequence[curSeqColor] == 6)
                    {
                        bulb.TurnPurple();
                    }
                    turnOn = true;
                }
                else
                {
                    turnOn = false;
                    playSequence = false;
                    pushSequence = true;
                    curSeqColor = 1;
                    clickTimer = 0;
                }
                elapsed = 0;

            }
            if (turnOn)
            {
                if (bulb.Alpha() >= 1.0f)
                {
                    turnOn = false;
                }
            }
        }

        if(pushSequence)
        {
            waitGo.sprite = go;
            clickTimer += Time.deltaTime;
            if (clickTimer >= 2.0f)
                lose = true;
            else
            {
                if (curSeqColor < sequence.Count)
                {
                    if (redPressed.buttonPressed && !redPrev)
                    {
                        if (sequence[curSeqColor] == 1)
                        {
                            buttonPlay.Play();
                            curSeqColor++;
                            redPrev = true;
                            clickTimer = 0;
                        }
                        else
                            lose = true;
                    }
                    if (greenPressed.buttonPressed && !greenPrev)
                    {
                        if (sequence[curSeqColor] == 2)
                        {
                            buttonPlay.Play();
                            curSeqColor++;
                            greenPrev = true;
                            clickTimer = 0;
                        }
                        else
                            lose = true;
                    }
                    if (bluePressed.buttonPressed && !bluePrev)
                    {
                        if (sequence[curSeqColor] == 3)
                        {
                            buttonPlay.Play();
                            curSeqColor++;
                            bluePrev = true;
                            clickTimer = 0;
                        }
                        else
                            lose = true;
                    }
                    if (yellowPressed.buttonPressed && !yellowPrev)
                    {
                        if (sequence[curSeqColor] == 4)
                        {
                            buttonPlay.Play();
                            curSeqColor++;
                            yellowPrev = true;
                            clickTimer = 0;
                        }
                        else
                            lose = true;
                    }
                    if (orangePressed.buttonPressed && !orangePrev)
                    {
                        if (sequence[curSeqColor] == 5)
                        {
                            buttonPlay.Play();
                            curSeqColor++;
                            orangePrev = true;
                            clickTimer = 0;
                        }
                        else
                            lose = true;
                    }
                    if (purplePressed.buttonPressed && !purplePrev)
                    {
                        if (sequence[curSeqColor] == 6)
                        {
                            buttonPlay.Play();
                            curSeqColor++;
                            purplePrev = true;
                            clickTimer = 0;
                        }
                        else
                            lose = true;
                    }
                    if (!redPressed.buttonPressed)
                        redPrev = false;
                    if (!greenPressed.buttonPressed)
                        greenPrev = false;
                    if (!bluePressed.buttonPressed)
                        bluePrev = false;
                    if (!yellowPressed.buttonPressed)
                        yellowPrev = false;
                    if (!orangePressed.buttonPressed)
                        orangePrev = false;
                    if (!purplePressed.buttonPressed)
                        purplePrev = false;
                }
                else
                {
                    pushSequence = false;
                    addColor = true;
                    curSeqColor = 0;
                    scoreValue++;
                    particle.StartParticle();
                }
            }
        }
        


        if(lose)
        {
            if (!buzzPlayed)
            {
                if (GameData.data.vibrate == 1)
                    Handheld.Vibrate();
                score.text = scoreValue.ToString() + "!";
                finalScore.text = scoreValue.ToString() + "!";
                buzzPlay.Play();
                buzzPlayed = true;
                lb.leadboardId = "CgkI3fz1i50WEAIQBA";
                GameData.data.totalTimePlayed += timePlayed;
                GameData.data.Save();
            }
            Time.timeScale = 0;
            background.SetActive(false);
            loseScreen.SetActive(true);
            uiElements.SetActive(false);
            discoMode.SetActive(false);
            if (Social.localUser.authenticated)
            {
                if (!scorePosted)
                {
                    GameData.data.PostMemoryScore(scoreValue);
                    if (scoreValue >= 5)
                        Achievements.unlock.Memory5Pts();
                    if (scoreValue >= 10)
                        Achievements.unlock.Memory10Pts();
                    if (scoreValue >= 25)
                        Achievements.unlock.Memory25Pts();
                    if (scoreValue >= 50)
                        Achievements.unlock.Memory50Pts();
                    if (scoreValue >= 75)
                        Achievements.unlock.Memory75Pts();
                    if (scoreValue >= 100)
                        Achievements.unlock.Memory100Pts();
                    Achievements.unlock.Memory10X();
                    Achievements.unlock.Memory50X();
                    Achievements.unlock.Memory100X();
                    
                    scorePosted = true;
                }
            }
        }

        if (turnOn)
        {
            bulb.TurnOn();
        }
        else
            bulb.TurnOff();
	}
}
