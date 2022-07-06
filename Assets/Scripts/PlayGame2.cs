using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

///////////////////Sprint && Sprint/Shift 2 players///////////////////////

public class PlayGame2 : MonoBehaviour {

    Image light;
    public Sprite loser;
    Button red, blue, green, yellow, orange, purple;
    Button red2, blue2, green2, yellow2, orange2, purple2;

    ButtonPressed redPressed, bluePressed, greenPressed, yellowPressed, orangePressed, purplePressed;
    ButtonPressed redPressed2, bluePressed2, greenPressed2, yellowPressed2, orangePressed2, purplePressed2;

    AudioSource buttonSoundSource, lightSoundSource, buzzerSoundSource;

    SpriteAnimation redParticle, blueParticle, goldParticle;

    Text score, score2;

    GameObject gameDraw, lightColor, lightBulb;
    GameObject exit;

    Bulb bulbSwitch;

    MetalSheet p1Metal, p2Metal;

    Image p2Winner, p1Winner;

    float elapsed, elapsed2, gameSpeed;

    int scoreValue, nextColor, oldScore, scoreValue2, oldScore2;
    int winScore;

    bool canClick, buttonClicked, lose, buzzPlayed, lose2, draw, canClick2, buzzPlayed2, restart;
    bool turnOn, incAchieve, incAd;

    public GameObject buttonSound, buzzerSound, lightSound;

    public float deltaTime;
    
	// Use this for initialization
	void Start () {
        
        light = transform.GetChild(0).gameObject.GetComponent<Image>();
        red = transform.GetChild(1).gameObject.GetComponent<Button>();
        blue = transform.GetChild(5).gameObject.GetComponent<Button>();
        green = transform.GetChild(4).gameObject.GetComponent<Button>();
        yellow = transform.GetChild(6).gameObject.GetComponent<Button>();
        orange = transform.GetChild(2).gameObject.GetComponent<Button>();
        purple = transform.GetChild(3).gameObject.GetComponent<Button>();
        score = transform.GetChild(7).gameObject.GetComponent<Text>();

        red2 = transform.GetChild(9).gameObject.GetComponent<Button>();
        blue2 = transform.GetChild(13).gameObject.GetComponent<Button>();
        green2 = transform.GetChild(12).gameObject.GetComponent<Button>();
        yellow2 = transform.GetChild(14).gameObject.GetComponent<Button>();
        orange2 = transform.GetChild(10).gameObject.GetComponent<Button>();
        purple2 = transform.GetChild(11).gameObject.GetComponent<Button>();
        score2 = transform.GetChild(15).gameObject.GetComponent<Text>();

        redPressed = red.GetComponent<ButtonPressed>();
        orangePressed = orange.GetComponent<ButtonPressed>();
        purplePressed = purple.GetComponent<ButtonPressed>();
        greenPressed = green.GetComponent<ButtonPressed>();
        bluePressed = blue.GetComponent<ButtonPressed>();
        yellowPressed = yellow.GetComponent<ButtonPressed>();

        redPressed2 = red2.GetComponent<ButtonPressed>();
        orangePressed2 = orange2.GetComponent<ButtonPressed>();
        purplePressed2 = purple2.GetComponent<ButtonPressed>();
        greenPressed2 = green2.GetComponent<ButtonPressed>();
        bluePressed2 = blue2.GetComponent<ButtonPressed>();
        yellowPressed2 = yellow2.GetComponent<ButtonPressed>();

        gameDraw = transform.GetChild(21).gameObject;

        lightColor = transform.GetChild(0).transform.GetChild(0).gameObject;
        lightBulb = transform.GetChild(0).gameObject;

        lightSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buzzerSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buttonSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;

        buttonSoundSource = buttonSound.GetComponent<AudioSource>();
        lightSoundSource = lightSound.GetComponent<AudioSource>();
        buzzerSoundSource = buzzerSound.GetComponent<AudioSource>();

        redParticle = transform.GetChild(17).GetComponent<SpriteAnimation>();
        blueParticle = transform.GetChild(18).GetComponent<SpriteAnimation>();
        goldParticle = transform.GetChild(19).transform.GetChild(0).GetComponent<SpriteAnimation>();

        bulbSwitch = lightBulb.GetComponent<Bulb>();

        p1Metal = transform.GetChild(8).transform.GetComponent<MetalSheet>();
        p2Metal = transform.GetChild(16).transform.GetComponent<MetalSheet>();

        p2Winner = transform.GetChild(19).transform.GetChild(4).gameObject.GetComponent<Image>();
        p1Winner = transform.GetChild(19).transform.GetChild(3).gameObject.GetComponent<Image>();

        elapsed = 0;
        elapsed2 = 0;
        gameSpeed = 0;
        oldScore = -1;
        oldScore2 = -1;

        canClick = false;
        canClick2 = false;
        buttonClicked = false;
        lose = false;
        lose2 = false;
        buzzPlayed = false;
        buzzPlayed2 = false;
        draw = false;
        restart = false;
        turnOn = false;
        incAchieve = false;
        incAd = false;

        winScore = 25;

        exit = transform.GetChild(23).gameObject;
        deltaTime = 0;
       
    }
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.deltaTime;
        score.text = scoreValue.ToString();
        score2.text = scoreValue2.ToString();

        gameSpeed = 0.75f;
        elapsed += Time.deltaTime;

        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale != 0.0f)
            {
                exit.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }

        if (Time.timeScale == 1.0f)
        {
            if (redPressed.buttonPressed)
            {
                if (canClick)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 1)
                    {
                        if (redPressed2.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue++;
                            canClick2 = false;
                            redParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose = true;

                }
                buttonClicked = true;
                canClick = false;
            }

            if (greenPressed.buttonPressed)
            {
                if (canClick)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 2)
                    {
                        if (greenPressed2.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue++;
                            canClick2 = false;
                            redParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose = true;
                }
                buttonClicked = true;
                canClick = false;
            }

            if (bluePressed.buttonPressed)
            {
                if (canClick)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 3)
                    {
                        if (bluePressed2.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue++;
                            canClick2 = false;
                            redParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose = true;
                }
                buttonClicked = true;
                canClick = false;
            }

            if (yellowPressed.buttonPressed)
            {
                if (canClick)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 4)
                    {
                        if (yellowPressed2.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue++;
                            canClick2 = false;
                            redParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose = true;
                }
                buttonClicked = true;
                canClick = false;
            }

            if (orangePressed.buttonPressed)
            {
                if (canClick)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 5)
                    {
                        if (orangePressed2.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue++;
                            canClick2 = false;
                            redParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose = true;
                }
                buttonClicked = true;
                canClick = false;
            }

            if (purplePressed.buttonPressed)
            {
                if (canClick)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 6)
                    {
                        if (purplePressed2.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue++;
                            canClick2 = false;
                            redParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose = true;
                }
                buttonClicked = true;
                canClick = false;
            }

            if (redPressed2.buttonPressed)
            {
                if (canClick2)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 1)
                    {
                        if (redPressed.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue2++;
                            canClick = false;
                            blueParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose2 = true;
                }
                buttonClicked = true;
                canClick2 = false;
            }

            if (greenPressed2.buttonPressed)
            {
                if (canClick2)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 2)
                    {
                        if (greenPressed.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue2++;
                            canClick = false;
                            blueParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose2 = true;
                }
                buttonClicked = true;
                canClick2 = false;
            }

            if (bluePressed2.buttonPressed)
            {
                if (canClick2)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 3)
                    {
                        if (bluePressed.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue2++;
                            canClick = false;
                            blueParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose2 = true;
                }
                buttonClicked = true;
                canClick2 = false;
            }

            if (yellowPressed2.buttonPressed)
            {
                if (canClick2)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 4)
                    {
                        if (yellowPressed.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue2++;
                            canClick = false;
                            blueParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose2 = true;
                }
                buttonClicked = true;
                canClick2 = false;
            }

            if (orangePressed2.buttonPressed)
            {
                if (canClick2)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 5)
                    {
                        if (orangePressed.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue2++;
                            canClick = false;
                            blueParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose2 = true;
                }
                buttonClicked = true;
                canClick2 = false;
            }

            if (purplePressed2.buttonPressed)
            {
                if (canClick2)
                {
                    buttonSoundSource.Play();
                    if (nextColor == 6)
                    {
                        if (purplePressed.buttonPressed)
                        {
                            draw = true;
                        }
                        else
                        {
                            scoreValue2++;
                            canClick = false;
                            blueParticle.StartParticle();
                        }
                        elapsed = 0;
                        turnOn = false;
                    }
                    else
                        lose2 = true;
                }
                buttonClicked = true;
                canClick2 = false;
            }
        }

        if(elapsed >= gameSpeed)
        {
            if (oldScore == scoreValue)
            {
                //lose = true;
            }
            else
            {
                bulbSwitch.TurnOff();
                elapsed2 += Time.deltaTime;
                p1Metal.active = false;
                p2Metal.active = false;
                lose = false;
                lose2 = false;
                buzzPlayed = false;
                buzzPlayed2 = false;
                restart = false;
                gameDraw.SetActive(false);
            }

            if (oldScore2 == scoreValue2)
            {
                //lose = true;
            }
            else
            {
                turnOn = false;
                elapsed2 += Time.deltaTime;
                p1Metal.active = false;
                p2Metal.active = false;
                lose = false;
                lose2 = false;
                buzzPlayed = false;
                buzzPlayed2 = false;
                restart = false;
                gameDraw.SetActive(false);
            }
        }
        if(elapsed2 >= 0.2f)
        {
            lightSoundSource.Play();
            nextColor = Random.Range(1, 7);
            if(nextColor == 1)
            {
                bulbSwitch.TurnRed();
            }
            if(nextColor == 2)
            {
                bulbSwitch.TurnGreen();
            }
            if(nextColor == 3)
            {
                bulbSwitch.TurnBlue();
            }
            if (nextColor == 4)
            {
                bulbSwitch.TurnYellow();
            }
            if (nextColor == 5)
            {
                bulbSwitch.TurnOrange();
            }
            if (nextColor == 6)
            {
                bulbSwitch.TurnPurple();
            }
            turnOn = true;
            canClick = true;
            canClick2 = true;
            elapsed = 0;
            elapsed2 = 0;
            oldScore = scoreValue;
            oldScore2 = scoreValue2;
            
            
            
        }

        if (draw)
        {
            gameDraw.SetActive(true);
        }

        if (restart)
        {
            oldScore = -1;
            buttonClicked = true;
        }
        if(lose)
        {
            if (!buzzPlayed)
            {
                if (GameData.data.vibrate == 1)
                    Handheld.Vibrate();
                buzzerSoundSource.Play();
                buzzPlayed = true;
            }
            p1Metal.active = true;
        }

        if(lose2)
        {
            if (!buzzPlayed2)
            {
                if (GameData.data.vibrate == 1)
                    Handheld.Vibrate();
                buzzerSoundSource.Play();
                buzzPlayed2 = true;
            }
            p2Metal.active = true;
        }

        if(lose && lose2)
        {
            turnOn = false;
            restart = true;
            elapsed = 0;
            lose = false;
            lose2 = false;
        }

        if(draw)
        {
            restart = true;
            elapsed = 0;
            draw = false;
        }

        if(scoreValue == winScore)
        {
            if (Social.localUser.authenticated)
            {
                if (!incAchieve)
                {
                    Achievements.unlock.Multiplayer5Rounds();
                    Achievements.unlock.Multiplayer25Rounds();
                    incAchieve = true;
                }
            }
            transform.GetChild(19).gameObject.SetActive(true);
            p2Winner.sprite = loser;
            transform.GetChild(19).transform.GetChild(0).transform.localPosition = new Vector3(0, -535, 0);
            transform.GetChild(19).transform.GetChild(1).transform.localPosition = new Vector3(-230, -535, 0);
            transform.GetChild(19).transform.GetChild(2).transform.localPosition = new Vector3(230, -535, 0);
            goldParticle.StartParticle();
            transform.GetChild(20).gameObject.SetActive(true);
            canClick = false;
            canClick2 = false;
            if (GameData.data.trialBuild)
            {
                if (!incAd)
                {
                    GameData.data.PlayNextAd();
                    incAd = true;
                }
            }

            Time.timeScale = 0.0f;
        }

        if (scoreValue2 == winScore)
        {
            if (Social.localUser.authenticated)
            {
                if (!incAchieve)
                {
                    Achievements.unlock.Multiplayer5Rounds();
                    Achievements.unlock.Multiplayer25Rounds();
                    incAchieve = true;
                }
            }
            transform.GetChild(19).gameObject.SetActive(true);
            p1Winner.sprite = loser;
            transform.GetChild(19).transform.GetChild(0).transform.localPosition = new Vector3(0, 535, 0);
            transform.GetChild(19).transform.GetChild(1).transform.localPosition = new Vector3(-230, 535, 0);
            transform.GetChild(19).transform.GetChild(2).transform.localPosition = new Vector3(230, 535, 0);
            goldParticle.StartParticle();
            transform.GetChild(20).gameObject.SetActive(true);
            canClick = false;
            canClick2 = false;
            if (GameData.data.trialBuild)
            {
                if (!incAd)
                {
                    GameData.data.PlayNextAd();
                    incAd = true;
                }
            }
            Time.timeScale = 0.0f;
        }

        if (turnOn)
        {
            bulbSwitch.TurnOn();
        }
        else
            bulbSwitch.TurnOff();
	}
}
