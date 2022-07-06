using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayGame6 : MonoBehaviour {

    Image light;
    Button red, blue, green, yellow, orange, purple;
    Button red2, blue2, green2, yellow2, orange2, purple2;

    Text score, score2;

    GameObject gameDraw;

    float elapsed, elapsed2, gameSpeed;

    int scoreValue, nextColor, oldScore, scoreValue2, oldScore2;
    int winScore;

    bool canClick, buttonClicked, lose, buzzPlayed, lose2, draw, canClick2, buzzPlayed2, restart;

    public GameObject buttonSound, buzzerSound, lightSound;

    //public GameObject eventData;

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

        gameDraw = transform.GetChild(20).gameObject;

        lightSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buzzerSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        buttonSound.GetComponent<AudioSource>().volume = GameData.data.fxVol;

        //red.onClick.AddListener(Red);
        //green.onClick.AddListener(Green);
        //blue.onClick.AddListener(Blue);
        //yellow.onClick.AddListener(Yellow);
        //orange.onClick.AddListener(Orange);
        //purple.onClick.AddListener(Purple);

        elapsed = 0;
        elapsed2 = 0;
        gameSpeed = 0;
        oldScore = -1;
        oldScore2 = -1;

        canClick = false;
        canClick2 = false;
        buttonClicked = false;
        lose = false;
        buzzPlayed = false;
        buzzPlayed2 = false;
        draw = false;
        restart = false;

        winScore = 25;
	}
	
	// Update is called once per frame
	void Update () {
        score.text = scoreValue.ToString();
        score2.text = scoreValue2.ToString();

        gameSpeed = 0.75f;
        elapsed += Time.deltaTime;

        if(red.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 1)
                {
                    if (red2.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue++;
                        canClick2 = false;
                    }
                    elapsed = 0;
                }
                else
                    lose = true;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (green.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 2)
                {
                    if (green2.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue++;
                        canClick2 = false;
                    }
                    elapsed = 0;
                }
                else
                    lose = true;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (blue.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 3)
                {
                    if (blue2.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue++;
                        canClick2 = false;
                    }
                    elapsed = 0;
                }
                else
                    lose = true;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (yellow.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 4)
                {
                    if (yellow2.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue++;
                        canClick2 = false;
                    }
                    elapsed = 0;
                }
                else
                    lose = true;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (orange.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 5)
                {
                    if (orange2.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue++;
                        canClick2 = false;
                    }
                    elapsed = 0;
                }
                else
                    lose = true;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (purple.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick)
            {
                if (nextColor == 6)
                {
                    if (purple2.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue++;
                        canClick2 = false;
                    }
                    elapsed = 0;
                }
                else
                    lose = true;
            }
            buttonClicked = true;
            canClick = false;
        }

        if (red2.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick2)
            {
                if (nextColor == 1)
                {
                    if (red.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue2++;
                        canClick = false;
                    }
                    elapsed = 0;
                }
                else
                    lose2 = true;
            }
            buttonClicked = true;
            canClick2 = false;
        }

        if (green2.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick2)
            {
                if (nextColor == 2)
                {
                    if (green.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue2++;
                        canClick = false;
                    }
                    elapsed = 0;
                }
                else
                    lose2 = true;
            }
            buttonClicked = true;
            canClick2 = false;
        }

        if (blue2.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick2)
            {
                if (nextColor == 3)
                {
                    if (blue.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue2++;
                        canClick = false;
                    }
                    elapsed = 0;
                }
                else
                    lose2 = true;
            }
            buttonClicked = true;
            canClick2 = false;
        }

        if (yellow2.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick2)
            {
                if (nextColor == 4)
                {
                    if (yellow.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue2++;
                        canClick = false;
                    }
                    elapsed = 0;
                }
                else
                    lose2 = true;
            }
            buttonClicked = true;
            canClick2 = false;
        }

        if (orange2.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick2)
            {
                if (nextColor == 5)
                {
                    if (orange.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue2++;
                        canClick = false;
                    }
                    elapsed = 0;
                }
                else
                    lose2 = true;
            }
            buttonClicked = true;
            canClick2 = false;
        }

        if (purple2.GetComponent<ButtonPressed>().buttonPressed)
        {
            if (canClick2)
            {
                if (nextColor == 6)
                {
                    if (purple.GetComponent<ButtonPressed>().buttonPressed)
                    {
                        draw = true;
                    }
                    else
                    {
                        buttonSound.GetComponent<AudioSource>().Play();
                        scoreValue2++;
                        canClick = false;
                    }
                    elapsed = 0;
                }
                else
                    lose2 = true;
            }
            buttonClicked = true;
            canClick2 = false;
        }

        if(elapsed >= gameSpeed)
        {
            if (oldScore == scoreValue)
            {
                //lose = true;
            }
            else
            {
                light.color = new Color(1, 1, 1, 1);
                elapsed2 += Time.deltaTime;
                transform.GetChild(8).gameObject.SetActive(false);
                transform.GetChild(16).gameObject.SetActive(false);
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
                light.color = new Color(1, 1, 1, 1);
                elapsed2 += Time.deltaTime;
                transform.GetChild(8).gameObject.SetActive(false);
                transform.GetChild(16).gameObject.SetActive(false);
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
            lightSound.GetComponent<AudioSource>().Play();
            nextColor = Random.Range(1, 7);
            if(nextColor == 1)
            {
                light.color = new Color(1, 0, 0, 1);
                //light = red.GetComponent<Image>();
            }
            if(nextColor == 2)
            {
                light.color = new Color(0, 0.6313f, 0, 1);
            }
            if(nextColor == 3)
            {
                light.color = new Color(0, 0, 1, 1);
            }
            if (nextColor == 4)
            {
                light.color = new Color(1, 1, 0, 1);
            }
            if (nextColor == 5)
            {
                light.color = new Color(1, 0.6823f, 0, 1);
            }
            if (nextColor == 6)
            {
                light.color = new Color(0.6549f, 0, 1, 1);
            }
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
                buzzerSound.GetComponent<AudioSource>().Play();
                buzzPlayed = true;
            }
            //Time.timeScale = 0;
            transform.GetChild(8).gameObject.SetActive(true);
            //transform.GetChild(9).gameObject.SetActive(true);
        }

        if(lose2)
        {
            if (!buzzPlayed2)
            {
                buzzerSound.GetComponent<AudioSource>().Play();
                buzzPlayed2 = true;
            }
            //Time.timeScale = 0;
            transform.GetChild(16).gameObject.SetActive(true);
            //transform.GetChild(9).gameObject.SetActive(true);
        }

        if(lose && lose2)
        {
            //elapsed = 0;
            //elapsed = 0;
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
            transform.GetChild(17).gameObject.GetComponent<Text>().text = "Winner!";
            transform.GetChild(17).gameObject.SetActive(true);
            transform.GetChild(18).gameObject.GetComponent<Text>().text = "Loser!";
            transform.GetChild(18).gameObject.SetActive(true);
            canClick = false;
            canClick2 = false;
            transform.GetChild(19).gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (scoreValue2 == winScore)
        {
            transform.GetChild(18).gameObject.GetComponent<Text>().text = "Winner!";
            transform.GetChild(18).gameObject.SetActive(true);
            transform.GetChild(17).gameObject.GetComponent<Text>().text = "Loser!";
            transform.GetChild(17).gameObject.SetActive(true);
            canClick = false;
            canClick2 = false;
            transform.GetChild(19).gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
	
	}
}
