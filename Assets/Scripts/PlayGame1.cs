using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GooglePlayGames;

////////////////Speed && Shift 1 Player//////////////////////////

public class PlayGame1 : MonoBehaviour {

    float timePlayed;
    
    Button red, blue, green, yellow, orange, purple;
    ButtonPressed redPressed, bluePressed, greenPressed, yellowPressed, orangePressed, purplePressed;
    Bulb bulb;

    Text score;
    Text finalScore;

    public float speed;

    float elapsed, elapsed2;
    public float gameSpeed;

    int scoreValue, nextColor, oldScore, starValue;

    bool canClick, buttonClicked, lose, buzzPlayed, turnOn, scorePosted;

    public GameObject buttonSound, buzzerSound, lightSound, discoMode, background;

    GameObject lightColor, lightBulb, loseScreen, uiElements;

    AudioSource buttonPlay, lightPlay, buzzPlay;

    SpriteAnimation particle;

    AccessLeaderboard lb;

    //public SpriteRenderer bgColor;

    // Use this for initialization
    void Start() {
        if (GameData.data.discoMode)
            discoMode.SetActive(true);
        else
            discoMode.SetActive(false);

        //Light base == 0
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

        //Score GUI == 8
        score = transform.GetChild(0).GetChild(9).gameObject.GetComponent<Text>();
        finalScore = transform.GetChild(1).GetChild(2).GetComponent<Text>();

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

        elapsed = 0;
        elapsed2 = 0;
        gameSpeed = 0;
        oldScore = -1;
        timePlayed = 0;
        starValue = 0;

        canClick = false;
        buttonClicked = false;
        lose = false;
        buzzPlayed = false;
        turnOn = false;
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
        if (gameSpeed < 0.5f)
            gameSpeed = 0.5f;
        elapsed += Time.deltaTime;

        

        if (redPressed.buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 1)
                {
                    buttonPlay.Play();
                    scoreValue++;
                    starValue = scoreValue % 10;
                    if (starValue == 0 || starValue ==5)
                    {
                        particle.StartParticle();
                    }
                }
                else
                    lose = true;
                turnOn = false;
            }
            buttonClicked = true;
            canClick = false;
            
        }

        if (greenPressed.buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 2)
                {
                    buttonPlay.Play();
                    scoreValue++;
                    starValue = scoreValue % 10;
                    if (starValue == 0 || starValue == 5)
                    {
                        particle.StartParticle();
                    }
                }
                else
                    lose = true;
                turnOn = false;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (bluePressed.buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 3)
                {
                    buttonPlay.Play();
                    scoreValue++;
                    starValue = scoreValue % 10;
                    if (starValue == 0 || starValue == 5)
                    {
                        particle.StartParticle();
                    }
                }
                else
                    lose = true;
                turnOn = false;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (yellowPressed.buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 4)
                {
                    buttonPlay.Play();
                    scoreValue++;
                    starValue = scoreValue % 10;
                    if (starValue == 0 || starValue == 5)
                    {
                        particle.StartParticle();
                    }
                }
                else
                    lose = true;
                turnOn = false;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (orangePressed.buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 5)
                {
                    buttonPlay.Play();
                    scoreValue++;
                    starValue = scoreValue % 10;
                    if (starValue == 0 || starValue == 5)
                    {
                        particle.StartParticle();
                    }
                }
                else
                    lose = true;
                turnOn = false;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (purplePressed.buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 6)
                {
                    buttonPlay.Play();
                    scoreValue++;

                    starValue = scoreValue % 10;
                    if (starValue == 0 || starValue == 5)
                    {
                        particle.StartParticle();
                    }
                }
                else
                    lose = true;
                turnOn = false;
            }
            buttonClicked = true;
            canClick = false;
        }

        if(elapsed >= gameSpeed)
        {
            if (oldScore == scoreValue)
            {
                lose = true;
            }
            else
            {
                elapsed2 += Time.deltaTime;
            }
        }
        if(elapsed2 >= 0.2f)
        {
            lightPlay.Play();
            nextColor = Random.Range(1, 7);
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
            turnOn = true;
            canClick = true;
            elapsed = 0;
            elapsed2 = 0;
            oldScore = scoreValue;

        }
        if(lose)
        {
            canClick = false;
            if (!buzzPlayed)
            {
                if(GameData.data.vibrate == 1)
                    Handheld.Vibrate();
                buzzPlay.Play();
                buzzPlayed = true;
                finalScore.text = scoreValue.ToString() + "!";
                if(GameData.data.game == 1)
                {
                    if(GameData.data.difficulty == 2)
                        lb.leadboardId = "CgkI3fz1i50WEAIQAQ";
                    else if(GameData.data.difficulty == 1)
                        lb.leadboardId = "CgkI3fz1i50WEAIQSQ";
                }
                else if(GameData.data.game == 8)
                {
                    if (GameData.data.difficulty == 2)
                        lb.leadboardId = "CgkI3fz1i50WEAIQAg";
                    else if (GameData.data.difficulty == 1)
                        lb.leadboardId = "CgkI3fz1i50WEAIQSA";
                }
                GameData.data.totalTimePlayed += timePlayed;
                GameData.data.Save();
                GameData.data.PlayNextAd();
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
                        if (GameData.data.game == 1)
                        {
                            GameData.data.PostClassicScoreEasy(scoreValue);
                            if (scoreValue >= 5)
                                Achievements.unlock.ClassicEasy5Pts();
                            if (scoreValue >= 10)
                                Achievements.unlock.ClassicEasy10Pts();
                            if (scoreValue >= 25)
                                Achievements.unlock.ClassicEasy25Pts();
                            if (scoreValue >= 50)
                                Achievements.unlock.ClassicEasy50Pts();
                            if (scoreValue >= 100)
                                Achievements.unlock.ClassicEasy100Pts();
                            if (scoreValue >= 150)
                                Achievements.unlock.ClassicEasy150Pts();
                            if (scoreValue >= 200)
                                Achievements.unlock.ClassicEasy200Pts();
                            Achievements.unlock.Classic10X();
                            Achievements.unlock.Classic50X();
                            Achievements.unlock.Classic100X();
                        }
                        else if (GameData.data.game == 8)
                        {
                            GameData.data.PostShiftScoreEasy(scoreValue);
                            if (scoreValue >= 5)
                                Achievements.unlock.ShiftEasy5Pts();
                            if (scoreValue >= 10)
                                Achievements.unlock.ShiftEasy10Pts();
                            if (scoreValue >= 25)
                                Achievements.unlock.ShiftEasy25Pts();
                            if (scoreValue >= 50)
                                Achievements.unlock.ShiftEasy50Pts();
                            if (scoreValue >= 100)
                                Achievements.unlock.ShiftEasy100Pts();
                            if (scoreValue >= 150)
                                Achievements.unlock.ShiftEasy150Pts();
                            if (scoreValue >= 200)
                                Achievements.unlock.ShiftEasy200Pts();
                            Achievements.unlock.Shift10X();
                            Achievements.unlock.Shift50X();
                            Achievements.unlock.Shift100X();
                        }
                        scorePosted = true;
                    }
                }
                if (GameData.data.difficulty == 2)
                {
                    if (!scorePosted)
                    {
                        if (GameData.data.game == 1)
                        {
                            GameData.data.PostClassicScore(scoreValue);
                            if (scoreValue >= 5)
                                Achievements.unlock.ClassicEasy5Pts();
                            if (scoreValue >= 10)
                                Achievements.unlock.ClassicEasy10Pts();
                            if (scoreValue >= 25)
                                Achievements.unlock.ClassicEasy25Pts();
                            if (scoreValue >= 50)
                                Achievements.unlock.ClassicEasy50Pts();
                            if (scoreValue >= 100)
                                Achievements.unlock.ClassicEasy100Pts();
                            if (scoreValue >= 150)
                                Achievements.unlock.ClassicEasy150Pts();
                            if (scoreValue >= 200)
                                Achievements.unlock.ClassicEasy200Pts();
                            if (scoreValue >= 5)
                                Achievements.unlock.ClassicHard5Pts();
                            if (scoreValue >= 10)
                                Achievements.unlock.ClassicHard10Pts();
                            if (scoreValue >= 25)
                                Achievements.unlock.ClassicHard25Pts();
                            if (scoreValue >= 50)
                                Achievements.unlock.ClassicHard50Pts();
                            if (scoreValue >= 100)
                                Achievements.unlock.ClassicHard100Pts();
                            if (scoreValue >= 150)
                                Achievements.unlock.ClassicHard150Pts();
                            if (scoreValue >= 200)
                                Achievements.unlock.ClassicHard200Pts();
                            Achievements.unlock.Classic10X();
                            Achievements.unlock.Classic50X();
                            Achievements.unlock.Classic100X();
                        }
                        else if (GameData.data.game == 8)
                        {
                            GameData.data.PostShiftScore(scoreValue);
                            if (scoreValue >= 5)
                                Achievements.unlock.ShiftEasy5Pts();
                            if (scoreValue >= 10)
                                Achievements.unlock.ShiftEasy10Pts();
                            if (scoreValue >= 25)
                                Achievements.unlock.ShiftEasy25Pts();
                            if (scoreValue >= 50)
                                Achievements.unlock.ShiftEasy50Pts();
                            if (scoreValue >= 100)
                                Achievements.unlock.ShiftEasy100Pts();
                            if (scoreValue >= 150)
                                Achievements.unlock.ShiftEasy150Pts();
                            if (scoreValue >= 200)
                                Achievements.unlock.ShiftEasy200Pts();
                            if (scoreValue >= 5)
                                Achievements.unlock.ShiftHard5Pts();
                            if (scoreValue >= 10)
                                Achievements.unlock.ShiftHard10Pts();
                            if (scoreValue >= 25)
                                Achievements.unlock.ShiftHard25Pts();
                            if (scoreValue >= 50)
                                Achievements.unlock.ShiftHard50Pts();
                            if (scoreValue >= 100)
                                Achievements.unlock.ShiftHard100Pts();
                            if (scoreValue >= 150)
                                Achievements.unlock.ShiftHard150Pts();
                            if (scoreValue >= 200)
                                Achievements.unlock.ShiftHard200Pts();
                            Achievements.unlock.Shift10X();
                            Achievements.unlock.Shift50X();
                            Achievements.unlock.Shift100X();
                        }
                        scorePosted = true;
                    }
                }
            }
        }

        if(turnOn)
        {
            bulb.TurnOn();
        }
        else
            bulb.TurnOff();
	
	}
}
