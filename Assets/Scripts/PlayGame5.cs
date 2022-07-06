using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GooglePlayGames;

///////////////////Sequence 1 player////////////////////////

public class PlayGame5 : MonoBehaviour {
    float timePlayed;
    
    Button red, blue, green, yellow, orange, purple;
    ButtonPressed redPressed, bluePressed, greenPressed, yellowPressed, orangePressed, purplePressed;
    Bulb bulb, bulb2, bulb3;

    Text score, finalScore;


    float elapsed, elapsed2, gameSpeed, speed;

    int scoreValue, oldScore;

    public int nextColor, nextColor2, nextColor3, seqNum;

    bool canClick, buttonClicked, lose, buzzPlayed, turnOn1, turnOn2, turnOn3, scorePosted;

    bool prevR, prevG, prevB, prevO, prevY, prevP;

    public GameObject buttonSound, buzzerSound, lightSound, discoMode, background;
    GameObject lightColor, lightColor2, lightColor3, lightBulb, lightBulb2, lightBulb3, loseScreen, uiElements;

    AudioSource buttonPlay, lightPlay, buzzPlay;

    SpriteAnimation particle, particle2, particle3;

    AccessLeaderboard lb;

    // Use this for initialization
    void Start () {

        if (GameData.data.discoMode)
            discoMode.SetActive(true);
        else
            discoMode.SetActive(false);

        red = transform.GetChild(0).GetChild(6).gameObject.GetComponent<Button>();
        orange = transform.GetChild(0).GetChild(7).gameObject.GetComponent<Button>();
        purple = transform.GetChild(0).GetChild(8).gameObject.GetComponent<Button>();
        green = transform.GetChild(0).GetChild(9).gameObject.GetComponent<Button>();
        blue = transform.GetChild(0).GetChild(10).gameObject.GetComponent<Button>();
        yellow = transform.GetChild(0).GetChild(11).gameObject.GetComponent<Button>();

        redPressed = red.GetComponent<ButtonPressed>();
        orangePressed = orange.GetComponent<ButtonPressed>();
        purplePressed = purple.GetComponent<ButtonPressed>();
        greenPressed = green.GetComponent<ButtonPressed>();
        bluePressed = blue.GetComponent<ButtonPressed>();
        yellowPressed = yellow.GetComponent<ButtonPressed>();

        score = transform.GetChild(0).GetChild(13).gameObject.GetComponent<Text>();
        finalScore = transform.GetChild(1).GetChild(2).GetComponent<Text>();

        lightColor = transform.GetChild(0).GetChild(3).GetChild(0).gameObject;
        lightBulb = transform.GetChild(0).GetChild(3).gameObject;
        bulb = lightBulb.GetComponent<Bulb>();

        lightColor2 = transform.GetChild(0).GetChild(4).GetChild(0).gameObject;
        lightBulb2 = transform.GetChild(0).GetChild(4).gameObject;
        bulb2 = lightBulb2.GetComponent<Bulb>();

        lightColor3 = transform.GetChild(0).GetChild(5).GetChild(0).gameObject;
        lightBulb3 = transform.GetChild(0).GetChild(5).gameObject;
        bulb3 = lightBulb3.GetComponent<Bulb>();

        lightSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buzzerSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buttonSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;

        buttonPlay = buttonSound.GetComponent<AudioSource>();
        lightPlay = lightSound.GetComponent<AudioSource>();
        buzzPlay = buzzerSound.GetComponent<AudioSource>();

        particle = transform.GetChild(0).GetChild(14).GetComponent<SpriteAnimation>();
        particle2 = transform.GetChild(0).GetChild(15).GetComponent<SpriteAnimation>();
        particle3 = transform.GetChild(0).GetChild(16).GetComponent<SpriteAnimation>();

        lb = transform.GetChild(1).transform.GetChild(3).GetComponent<AccessLeaderboard>();

        loseScreen = transform.GetChild(1).gameObject;
        uiElements = transform.GetChild(0).gameObject;


        elapsed = 0;
        elapsed2 = 0;
        gameSpeed = 0;
        oldScore = -1;
        seqNum = 0;
        timePlayed = 0;

        canClick = false;
        buttonClicked = false;
        lose = false;
        buzzPlayed = false;
        prevR = false; prevG = false; prevB = false;
        prevO = false; prevY = false; prevP = false;
        turnOn1 = false;
        turnOn2 = false;
        turnOn3 = false;
        scorePosted = false;

        if (!Social.localUser.authenticated)
            transform.GetChild(1).GetChild(3).gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        timePlayed += Time.deltaTime;
        speed = GameData.data.speed;
        score.text = scoreValue.ToString();
        gameSpeed = speed - (scoreValue / 100.0f);
        if (gameSpeed < 1.4)
            gameSpeed = 1.4f;
        elapsed += Time.deltaTime;

        

        if (redPressed.buttonPressed && canClick)
        {
            if (!prevR)
            {
                if (seqNum == 0)
                {
                    if (nextColor == 1)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn1 = false;
                        particle.StartParticle();

                    }
                    else
                        lose = true;
                }
                else if (seqNum == 1)
                {
                    if (nextColor2 == 1)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn2 = false;
                        particle2.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 2)
                {
                    if (nextColor3 == 1)
                    {
                        buttonPlay.Play();
                        scoreValue++;
                        seqNum = 0;
                        turnOn3 = false;
                        canClick = false;
                        particle3.StartParticle();
                    }
                    else
                        lose = true;
                }
            }
            buttonClicked = true;
            
            prevR = true;
        }
        else
            prevR = false;

        if (greenPressed.buttonPressed && canClick)
        {
            if (!prevG)
            {
                if (seqNum == 0)
                {
                    if (nextColor == 2)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn1 = false;
                        particle.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 1)
                {
                    if (nextColor2 == 2)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn2 = false;
                        particle2.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 2)
                {
                    if (nextColor3 == 2)
                    {
                        buttonPlay.Play();
                        scoreValue++;
                        seqNum = 0;
                        turnOn3 = false;
                        canClick = false;
                        particle3.StartParticle();
                    }
                    else
                        lose = true;
                }
            }
            buttonClicked = true;
            prevG = true;
        }
        else
            prevG = false;

        if (bluePressed.buttonPressed && canClick)
        {
            if (!prevB)
            {
                if (seqNum == 0)
                {
                    if (nextColor == 3)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn1 = false;
                        particle.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 1)
                {
                    if (nextColor2 == 3)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn2 = false;
                        particle2.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 2)
                {
                    if (nextColor3 == 3)
                    {
                        buttonPlay.Play();
                        scoreValue++;
                        seqNum = 0; ;
                        turnOn3 = false;
                        canClick = false;
                        particle3.StartParticle();
                    }
                    else
                        lose = true;
                }
            }
            buttonClicked = true;
            prevB = true;
        }
        else
            prevB = false;

        if (yellowPressed.buttonPressed && canClick)
        {
            if (!prevY)
            {
                if (seqNum == 0)
                {
                    if (nextColor == 4)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn1 = false;
                        particle.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 1)
                {
                    if (nextColor2 == 4)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn2 = false;
                        particle2.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 2)
                {
                    if (nextColor3 == 4)
                    {
                        buttonPlay.Play();
                        scoreValue++;
                        seqNum = 0;
                        turnOn3 = false;
                        canClick = false;
                        particle3.StartParticle();
                    }
                    else
                        lose = true;
                }
            }
            buttonClicked = true;
            prevY = true;
        }
        else
            prevY = false;

        if (orangePressed.buttonPressed && canClick)
        {
            if (!prevO)
            {
                if (seqNum == 0)
                {
                    if (nextColor == 5)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn1 = false;
                        particle.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 1)
                {
                    if (nextColor2 == 5)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn2 = false;
                        particle2.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 2)
                {
                    if (nextColor3 == 5)
                    {
                        buttonPlay.Play();
                        scoreValue++;
                        seqNum = 0;
                        turnOn3 = false;
                        canClick = false;
                        particle3.StartParticle();
                    }
                    else
                        lose = true;
                }
            }
            buttonClicked = true;
            prevO = true;
        }
        else
            prevO = false;

        if (purplePressed.buttonPressed && canClick)
        {
            if (!prevP)
            {
                if (seqNum == 0)
                {
                    if (nextColor == 6)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn1 = false;
                        particle.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 1)
                {
                    if (nextColor2 == 6)
                    {
                        buttonPlay.Play();
                        seqNum++;
                        turnOn2 = false;
                        particle2.StartParticle();
                    }
                    else
                        lose = true;
                }
                else if (seqNum == 2)
                {
                    if (nextColor3 == 6)
                    {
                        buttonPlay.Play();
                        scoreValue++;
                        seqNum = 0;
                        turnOn3 = false;
                        canClick = false;
                        particle3.StartParticle();
                    }
                    else
                        lose = true;
                }
            }
            buttonClicked = true;
            prevP = true;
        }
        else
            prevP = false;

        if(elapsed >= gameSpeed)
        {
            if (oldScore == scoreValue)
            {
                lose = true;
            }
            else
            {
                turnOn1 = false;
                turnOn2 = false;
                turnOn3 = false;
                elapsed2 += Time.deltaTime;
            }
        }
        if(elapsed2 >= 0.2f)
        {
            lightPlay.Play();
            nextColor = Random.Range(1, 7);
            nextColor2 = Random.Range(1, 7);
            nextColor3 = Random.Range(1, 7);  

            if(nextColor == 1)
            {
                bulb.TurnRed();
            }
            if(nextColor == 2)
            {
                bulb.TurnGreen();
            }
            if(nextColor == 3)
            {
                bulb.TurnBlue();
            }
            if (nextColor == 4)
            {
                bulb.TurnYellow();
            }
            if (nextColor == 5)
            {
                bulb.TurnOrange();
            }
            if (nextColor == 6)
            {
                bulb.TurnPurple();
            }

            if (nextColor2 == 1)
            {
                bulb2.TurnRed();
            }
            if (nextColor2 == 2)
            {
                bulb2.TurnGreen();
            }
            if (nextColor2 == 3)
            {
                bulb2.TurnBlue();
            }
            if (nextColor2 == 4)
            {
                bulb2.TurnYellow();
            }
            if (nextColor2 == 5)
            {
                bulb2.TurnOrange();
            }
            if (nextColor2 == 6)
            {
                bulb2.TurnPurple();
            }

            if (nextColor3 == 1)
            {
                bulb3.TurnRed();
            }
            if (nextColor3 == 2)
            {
                bulb3.TurnGreen();
            }
            if (nextColor3 == 3)
            {
                bulb3.TurnBlue();
            }
            if (nextColor3 == 4)
            {
                bulb3.TurnYellow();
            }
            if (nextColor3 == 5)
            {
                bulb3.TurnOrange();
            }
            if (nextColor3 == 6)
            {
                bulb3.TurnPurple();
            }
            canClick = true;
            elapsed = 0;
            elapsed2 = 0;
            oldScore = scoreValue;
            turnOn1 = true;
            turnOn2 = true;
            turnOn3 = true;
        }
        if(lose)
        {
            canClick = false;
            if (!buzzPlayed)
            {
                if (GameData.data.vibrate == 1)
                    Handheld.Vibrate();
                score.text = scoreValue.ToString() + "!";
                finalScore.text = scoreValue.ToString() + "!";
                buzzPlay.Play();
                buzzPlayed = true;
                if (GameData.data.difficulty == 2)
                    lb.leadboardId = "CgkI3fz1i50WEAIQAw";
                else if (GameData.data.difficulty == 1)
                    lb.leadboardId = "CgkI3fz1i50WEAIQSg";
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
                if (GameData.data.difficulty == 1)
                {
                    if (!scorePosted)
                    {
                        GameData.data.PostSequenceScoreEasy(scoreValue);
                        if (scoreValue >= 5)
                            Achievements.unlock.SequenceEasy5Pts();
                        if (scoreValue >= 10)
                            Achievements.unlock.SequenceEasy10Pts();
                        if (scoreValue >= 25)
                            Achievements.unlock.SequenceEasy25Pts();
                        if (scoreValue >= 50)
                            Achievements.unlock.SequenceEasy50Pts();
                        if (scoreValue >= 100)
                            Achievements.unlock.SequenceEasy100Pts();
                        if (scoreValue >= 150)
                            Achievements.unlock.SequenceEasy150Pts();
                        if (scoreValue >= 200)
                            Achievements.unlock.SequenceEasy200Pts();
                        Achievements.unlock.Sequence10X();
                        Achievements.unlock.Sequence50X();
                        Achievements.unlock.Sequence100X();
                        scorePosted = true;
                    }
                }
                if (GameData.data.difficulty == 2)
                {
                    if (!scorePosted)
                    {
                        GameData.data.PostSequenceScore(scoreValue);
                        if (scoreValue >= 5)
                            Achievements.unlock.SequenceEasy5Pts();
                        if (scoreValue >= 10)
                            Achievements.unlock.SequenceEasy10Pts();
                        if (scoreValue >= 25)
                            Achievements.unlock.SequenceEasy25Pts();
                        if (scoreValue >= 50)
                            Achievements.unlock.SequenceEasy50Pts();
                        if (scoreValue >= 100)
                            Achievements.unlock.SequenceEasy100Pts();
                        if (scoreValue >= 150)
                            Achievements.unlock.SequenceEasy150Pts();
                        if (scoreValue >= 200)
                            Achievements.unlock.SequenceEasy200Pts();
                        if (scoreValue >= 5)
                            Achievements.unlock.SequenceHard5Pts();
                        if (scoreValue >= 10)
                            Achievements.unlock.SequenceHard10Pts();
                        if (scoreValue >= 25)
                            Achievements.unlock.SequenceHard25Pts();
                        if (scoreValue >= 50)
                            Achievements.unlock.SequenceHard50Pts();
                        if (scoreValue >= 100)
                            Achievements.unlock.SequenceHard100Pts();
                        if (scoreValue >= 150)
                            Achievements.unlock.SequenceHard150Pts();
                        if (scoreValue >= 200)
                            Achievements.unlock.SequenceHard200Pts();
                        Achievements.unlock.Sequence10X();
                        Achievements.unlock.Sequence50X();
                        Achievements.unlock.Sequence100X();
                        scorePosted = true;
                    }
                }
            }
        }

        if (turnOn1)
        {
            bulb.TurnOn();
        }
        else
            bulb.TurnOff();

        if (turnOn2)
        {
            bulb2.TurnOn();
        }
        else
            bulb2.TurnOff();

        if (turnOn3)
        {
            bulb3.TurnOn();
        }
        else
            bulb3.TurnOff();
	
	}
}
