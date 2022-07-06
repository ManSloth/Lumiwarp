using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using GooglePlayGames;
using ChartboostSDK;

public class GameData : MonoBehaviour
{
    public float totalTimePlayed;
    public string date;

    public float fps;
    public static GameData data;

    public GameObject menus;
    //GUI Variables
    public float xAxis, yAxis;
    public Text x, y;


    public float musicVol, fxVol;

    public GameObject game1Fab, game2Fab, game3Fab, game4Fab, game5Fab, game6Fab, game7Fab, game8Fab;
    GameObject thisInstance;

    public int numPlayers, game, difficulty, autoLog;

    public float speed, bSpeed;

    public int classicHigh;

    public bool loaded;

    bool loadMenu;

    public GameObject metalDoors;

    public int vibrate;
    public bool discoMode;


    public float trialTimeLeft;
    public bool trialBuild;

    public Text fpsText;
    float fpsTimer;

    int playNextAd;

    void Start()
    {
        discoMode = true;
        loadMenu = false;
        totalTimePlayed = 0;
        date = "";
        musicVol = 0.20f;
        fxVol = 1.0f;
        loaded = false;
        autoLog = 0;
        difficulty = 1;
        classicHigh = 0;
        game = 0;
        numPlayers = 1;
        vibrate = 1;
        trialTimeLeft = 0;
        Load();
        Application.targetFrameRate = 60;

        fpsTimer = 0;
        fps = 0;
        fpsText.text = "";
        playNextAd = 6;


        /////// SHOW ADS at the beginning of the game ///////
        if (trialBuild)
        {
            PlayNextAd();
        }
        ////////////////////////////////////////////////////
 
    }

    public void PlayNextAd()
    {
        playNextAd++;
        if (playNextAd >= 5)
        {
            Chartboost.showInterstitial(CBLocation.HomeScreen);
            playNextAd = UnityEngine.Random.Range(0, 3);
        }
    }

    void OnApplicationQuit()
    {
        Save();
    }

    void Awake()
    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        fps = 1.0f / Time.unscaledDeltaTime;
        fpsTimer += Time.unscaledDeltaTime;
        if (fpsTimer >= 0.5f)
        {
            int fpsInt = (int)fps;
            fpsText.text = "Fps: " + fpsInt;
            fpsTimer = 0;
        }
        if(loadMenu)
        {
            if (metalDoors.GetComponent<GameTransition>().closed)
            {
                Destroy(thisInstance);
                menus.SetActive(true);
                Time.timeScale = 1.0f;
                metalDoors.GetComponent<GameTransition>().OpenDoors();
                loadMenu = false;
            }
        }
        transform.gameObject.GetComponent<AudioSource>().volume = musicVol* 0.20f;
        
        //fps = Time.timeScale;
        //fps = Time.deltaTime;
        //fps = Screen.width;
        transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = fps.ToString();

        if (Input.GetKeyDown("escape"))
        {
            //Application.Quit();
        }

        if(totalTimePlayed >= 60)
        {
            if (Social.localUser.authenticated)
            {
                totalTimePlayed -= 60;
                Achievements.unlock.Minutes60();
                Achievements.unlock.Hours5();
                Achievements.unlock.Hours10();
                Save();
            }
        }

        if(trialBuild)
        {
            trialTimeLeft -= Time.unscaledDeltaTime;
            if (trialTimeLeft < 0)
                trialTimeLeft = 0;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameData.dat");

        GameInfo info = new GameInfo();

        info.musicVol = musicVol;
        info.fxVol = fxVol;
        info.autoLog = autoLog;
        info.totalTimePlayed = totalTimePlayed;
        info.date = date;
        info.vibrate = vibrate;
        info.discoMode = discoMode;
        info.trialTimeLeft = trialTimeLeft;

        bf.Serialize(file, info);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            GameInfo info = (GameInfo)bf.Deserialize(file);
            file.Close();


            musicVol = info.musicVol;
            fxVol = info.fxVol;
            autoLog = info.autoLog;
            totalTimePlayed = info.totalTimePlayed;
            date = info.date;
            vibrate = info.vibrate;
            discoMode = info.discoMode;
            trialTimeLeft = info.trialTimeLeft;
        }
        else
        {
            musicVol = 0.20f;
            fxVol = 0.100f;
            autoLog = 0;
            totalTimePlayed = 0;
            date = "";
            vibrate = 1;
            discoMode = false;
            trialTimeLeft = 0;
        }
        loaded = true;
    }

    public void LoadMenu()
    {
        if(metalDoors.transform.GetComponent<GameTransition>().opened)
            game = 0;
        loadMenu = true;
        metalDoors.GetComponent<GameTransition>().CloseDoors();
    }

    public void ReloadSpeed()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game1Fab);
        Time.timeScale = 1.0f;
    }

    public void ReloadSprint()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game2Fab);
        Time.timeScale = 1.0f;
    }

    public void ReloadMemory()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game3Fab);
        Time.timeScale = 1.0f;
    }

    public void ReloadTug()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game4Fab);
        Time.timeScale = 1.0f;
    }

    public void ReloadSequence()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game5Fab);
        Time.timeScale = 1.0f;
    }

    public void ReloadShift()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game6Fab);
        Time.timeScale = 1.0f;
    }

    public void ReloadShiftT()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game7Fab);
        Time.timeScale = 1.0f;
    }

    public void ReloadShift1()
    {
        Destroy(thisInstance);
        thisInstance = Instantiate(game8Fab);
        Time.timeScale = 1.0f;
    }

    public void LoadSpeed()
    {
        thisInstance = Instantiate(game1Fab);
    }

    public void LoadSprint()
    {
        thisInstance = Instantiate(game2Fab);
    }

    public void LoadMemory()
    {
        thisInstance = Instantiate(game3Fab);
    }

    public void LoadTug()
    {
        thisInstance = Instantiate(game4Fab);
    }

    public void LoadSequence()
    {
        thisInstance = Instantiate(game5Fab);
    }

    public void LoadShift()
    {
        thisInstance = Instantiate(game6Fab);
    }

    public void LoadShiftT()
    {
        thisInstance = Instantiate(game7Fab);
    }

    public void LoadShift1()
    {
        thisInstance = Instantiate(game8Fab);
    }

    public void PostClassicScore(int score)
    {
        Social.Active.ReportScore(score, "CgkI3fz1i50WEAIQAQ", (bool success) =>
        {

        });
    }

    public void PostShiftScore(int score)
    {
        Social.Active.ReportScore(score, "CgkI3fz1i50WEAIQAg", (bool success) =>
        {

        });
    }

    public void PostSequenceScore(int score)
    {
        Social.Active.ReportScore(score, "CgkI3fz1i50WEAIQAw", (bool success) =>
        {

        });
    }

    public void PostMemoryScore(int score)
    {
        Social.Active.ReportScore(score, "CgkI3fz1i50WEAIQBA", (bool success) =>
        {

        });
    }

    public void PostClassicScoreEasy(int score)
    {
        Social.Active.ReportScore(score, "CgkI3fz1i50WEAIQSQ", (bool success) =>
        {

        });
    }

    public void PostShiftScoreEasy(int score)
    {
        Social.Active.ReportScore(score, "CgkI3fz1i50WEAIQSA", (bool success) =>
        {

        });
    }

    public void PostSequenceScoreEasy(int score)
    {
        Social.Active.ReportScore(score, "CgkI3fz1i50WEAIQSg", (bool success) =>
        {

        });
    }

    public void CloudSave()
    {
        //((PlayGamesPlatform)Social.Active).SavedGame.ShowSelectSavedGameUI("Saved Game", 1,
        //    false, false, SaveGameSelected);
    }

 



}

[Serializable]
class GameInfo
{
    public float fxVol;
    public float musicVol;
    public int autoLog;
    public float totalTimePlayed;
    public string date;
    public int vibrate;
    public bool discoMode;
    public float trialTimeLeft;
}
