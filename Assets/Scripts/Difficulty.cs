using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;

public class Difficulty : MonoBehaviour {

    Button easy, hard, mainMenu, rules;
    GameObject rulesDisplay;

    public float lightSpeedE, lightSpeedH;
    public float buttonSpeedE, buttonSpeedH;

    float elapsed;
    public bool shrink, grow;

    Text howToPlay;
    Outline hTPColor, lineColor;

	// Use this for initialization
	void Start () {
        elapsed = 0;
        shrink = false; grow = false;
        easy = transform.GetChild(0).gameObject.GetComponent<Button>();
        hard = transform.GetChild(1).gameObject.GetComponent<Button>();
        rules = transform.GetChild(2).gameObject.GetComponent<Button>();
        mainMenu = transform.GetChild(3).gameObject.GetComponent<Button>();
        easy.onClick.AddListener(PlayEasy);
        hard.onClick.AddListener(PlayHard);
        rules.onClick.AddListener(DisplayRules);
        mainMenu.onClick.AddListener(GoToMenu);


        howToPlay = transform.GetChild(5).transform.GetChild(2).GetComponent<Text>();
        hTPColor = transform.GetChild(5).transform.GetChild(0).GetComponent<Outline>();
        lineColor = transform.GetChild(5).transform.GetChild(1).GetComponent<Outline>();
        Time.timeScale = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("escape"))
        {
            if(transform.GetChild(5).gameObject.activeSelf)
            {
                transform.GetChild(5).transform.gameObject.SetActive(false);
            }
            else
                GoToMenu();
        }

        if (shrink)
            Shrink();
        if (grow)
            Grow();

        

    }

    void DisplayRules()
    {
        if(GameData.data.game ==1)
        {
            howToPlay.text = "When the light changes color, press the button below of the same color.  If you press the incorrect button or wait too long, you lose. \n \n On hard difficulty the rules remain the same, but the speed at which the light changes is faster.";
            hTPColor.effectColor = new Color(0f, 0.972f, 1f);
            lineColor.effectColor = new Color(0f, 0.972f, 1f);
        }

        if(GameData.data.game == 2)
        {
            howToPlay.text = "When the light changes color, the first player to hit the correct button color gets a point.  Whoever reaches 25 points first wins the game.  \n \n If you hit the incorrect button, a metal shield blocks you from pressing any buttons until the other player presses a button.";
            hTPColor.effectColor = new Color(0f, 0.972f, 1f);
            lineColor.effectColor = new Color(0f, 0.972f, 1f);
        }

        if (GameData.data.game == 3)
        {
            howToPlay.text = "The light bulb will flash a color.  When the text in the upper right hand corner changes from 'wait' to 'go', hit the corresponding button below. If you get it correct, you get a point.\n \nAn additional color to memorize is added to the sequence every turn.";
            hTPColor.effectColor = new Color(1f, 1f, 0f);
            lineColor.effectColor = new Color(1f, 1f, 0f);
        }

        if (GameData.data.game == 4)
        {
            howToPlay.text = "Both players start with 15 points.  When the light changes color, the first player to hit the corresponding button steals a point from the other player.  Whoever reaches 30 points first wins the game. \n \n If you hit the incorrect button, a metal shield blocks you from pressing any buttons until the other player presses a button.";
            hTPColor.effectColor = new Color(1f, 0.6f, 0f);
            lineColor.effectColor = new Color(1f, 0.6f, 0f);
        }

        if (GameData.data.game == 5)
        {
            howToPlay.text = "All 3 light bulbs will light up with color.  Press the corresponding buttons below in order from left to right.  If you press an incorrect button or wait too long, you lose. \n \n On hard difficulty the rules remain the same, but the speed at which the lights change is faster.";
            hTPColor.effectColor = new Color(1f, 0.6f, 0f);
            lineColor.effectColor = new Color(1f, 0.6f, 0f);
        }

        if (GameData.data.game == 6)
        {
            howToPlay.text = "When the light changes color, the first player to hit the correct button color gets a point.  Whoever reaches 25 points first wins the game.  \n \n If you hit the incorrect button, a metal shield blocks you from pressing any buttons until the other player presses a button.";
            hTPColor.effectColor = new Color(0.6f, 0f, 1f);
            lineColor.effectColor = new Color(0.6f, 0f, 1f);
        }

        if (GameData.data.game == 7)
        {
            howToPlay.text = "Both players start with 15 points.  When the light changes color, the first player to hit the corresponding button steals a point from the other player.  Whoever reaches 30 points first wins the game. \n \n If you hit the incorrect button, a metal shield blocks you from pressing any buttons until the other player presses a button.";
            hTPColor.effectColor = new Color(0.6f, 0f, 1f);
            lineColor.effectColor = new Color(0.6f, 0f, 1f);
        }

        if (GameData.data.game == 8)
        {
            howToPlay.text = "When the light changes color, press the button below of the same color.  If you press the incorrect button or wait too long, you lose. \n \n On hard difficulty the rules remain the same, but the speed at which the light changes is faster.";
            hTPColor.effectColor = new Color(0.6f, 0f, 1f);
            lineColor.effectColor = new Color(0.6f, 0f, 1f);
        }
        transform.GetChild(5).transform.gameObject.SetActive(true);
    }

    void GoToMenu()
    {
        GameData.data.LoadMenu();
    }

    void PlayEasy()
    {
        if (GameData.data.game == 1)
        {
            GameData.data.speed = 1.5f;
            GameData.data.bSpeed = 0.0f;
        }
        else if (GameData.data.game == 8)
        {
            GameData.data.speed = 1.5f;
            GameData.data.bSpeed = 0.4f;
        }
        else if (GameData.data.game == 2)
        {
            GameData.data.speed = 1.5f;
            GameData.data.bSpeed = 0.4f;
        }
        else if (GameData.data.game == 3)
        {
            GameData.data.speed = 0.5f;
            GameData.data.bSpeed = 0.4f;
        }
        else if (GameData.data.game == 4)
        {
            GameData.data.speed = 1.5f;
            GameData.data.bSpeed = 0.4f;
        }
        else if (GameData.data.game == 5)
        {
            GameData.data.speed = 2.9f;
            GameData.data.bSpeed = 0.4f;
        }
        else if (GameData.data.game == 6)
        {
            GameData.data.speed = 1.5f;
            GameData.data.bSpeed = 0.4f;
        }
        else if (GameData.data.game == 7)
        {
            GameData.data.speed = 1.5f;
            GameData.data.bSpeed = 0.4f;
        }


        GetComponentInParent<GameTransition>().OpenDoors();
        Time.timeScale = 1.0f;
        shrink = true;
        GameData.data.difficulty = 1;
    }

    void PlayHard()
    {
        if (GameData.data.game == 1)
        {
            GameData.data.speed = 1.0f;
            GameData.data.bSpeed = 0.0f;
        }
        else if (GameData.data.game == 8)
        {
            GameData.data.speed = 1.0f;
            GameData.data.bSpeed = 0.6f;
        }
        else if (GameData.data.game == 5)
        {
            GameData.data.speed = 1.9f;
            GameData.data.bSpeed = 0.6f;
        }
        

        GetComponentInParent<GameTransition>().OpenDoors();
        Time.timeScale = 1.0f;
        shrink = true;
        GameData.data.difficulty = 2;
    }

    public void Shrink()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 0.005)
        {
            float newY = transform.localScale.y - 0.1f;
            transform.localScale = new Vector3(1, newY, 1);
            elapsed = 0;
        }

        if(transform.localScale.y <= 0)
        {
            shrink = false;
            transform.gameObject.SetActive(false);
        }
    }

    public void Grow()
    {
        Time.timeScale = 0.0f;
        elapsed += Time.unscaledDeltaTime;
        if (elapsed >= 0.005)
        {
            float newY = transform.localScale.y + 0.1f;
            transform.localScale = new Vector3(1, newY, 1);
            elapsed = 0;
        }

        if (transform.localScale.y >= 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            grow = false;
        }
    }


}
