using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;

public class Menu : MonoBehaviour {

    Button speed, players1, players2, back1, Quit, back2;
    Button sprint, memory, tug, seq, shift, shift1;
    Button login, leaderboardButton, achievementButton, settings;
    Button unlockGame;

    Button saveGameToCloud, loadGameFromCloud;
    Text loadedText;
    

    Button showBanner;
    GameObject gameSelect, playerSelect, gameSelect2, shiftWindow, settingsMenu;

    RawImage gamerPic;
    Text gamerTag;

    bool showingBanner;
    bool triedLog;

    string leaderboard;

    public GameObject metalDoors;
    public int pendGame;

    float arrowElapsed;
    float fpsTimer;


    /// Trial variables
    Button deactivateButton, deactivateButton2, deactivateButton3, deactivateButton4;
    Text trialText;
    GameObject trialTextObject;
    GameObject unlockGameBanner;
    //////////////////

    // Component variables
    GameObject discoMode, exitApp, arrow, doorTitle2, mainLight;
    SpriteAnimation loginAnimation;
    Flicker loginFlicker;
    ButtonPressed lbPressed, achievePressed;
    GameTransition doorTrans;
    Image doorTitle;
    Settings settingsScript;
    //////////////////////


    // Use this for initialization
    void Start () 
    {
        arrowElapsed = 0;
        pendGame = 0;
        showingBanner = false;
        triedLog = false;

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();


        leaderboard = "CgkI3fz1i50WEAIQAQ";
        gameSelect = transform.GetChild(0).gameObject;
        playerSelect = transform.GetChild(1).gameObject;
        gameSelect2 = transform.GetChild(2).gameObject;
        settingsMenu = transform.GetChild(4).gameObject;

        speed = gameSelect.transform.GetChild(0).GetComponent<Button>();
        speed.onClick.AddListener(PendClassic);

        sprint = gameSelect2.transform.GetChild(0).GetComponent<Button>();
        sprint.onClick.AddListener(PendSprint);

        memory = gameSelect.transform.GetChild(1).GetComponent<Button>();
        memory.onClick.AddListener(PendMemory);

        tug = gameSelect2.transform.GetChild(1).GetComponent<Button>();
        tug.onClick.AddListener(PendTug);

        seq = gameSelect.transform.GetChild(2).GetComponent<Button>();
        seq.onClick.AddListener(PendSeq);

        shift = gameSelect2.transform.GetChild(2).GetComponent<Button>();
        shift.onClick.AddListener(ShiftBehavior);

        shift1 = gameSelect.transform.GetChild(4).GetComponent<Button>();
        shift1.onClick.AddListener(PendShift);

        login = playerSelect.transform.GetChild(4).GetComponent<Button>();
        login.onClick.AddListener(GooglePlusStart);

        leaderboardButton = playerSelect.transform.GetChild(3).GetComponent<Button>();
        leaderboardButton.onClick.AddListener(ShowLeaderBoard);

        achievementButton = playerSelect.transform.GetChild(5).GetComponent<Button>();
        achievementButton.onClick.AddListener(ShowAchievements);

        settings = playerSelect.transform.GetChild(7).GetComponent<Button>();
        settings.onClick.AddListener(ShowSettings);

        gamerPic = transform.GetChild(3).transform.GetChild(0).GetComponent<RawImage>();
        gamerTag = transform.GetChild(3).transform.GetChild(1).GetComponent<Text>();

        shiftWindow = gameSelect2.transform.GetChild(4).gameObject;

        players1 = playerSelect.transform.GetChild(0).GetComponent<Button>();
        players2 = playerSelect.transform.GetChild(1).GetComponent<Button>();
        players1.onClick.AddListener(Players1Behavior);
        players2.onClick.AddListener(Players2Behavior);

        back1 = gameSelect.transform.GetChild(3).GetComponent<Button>();
        back1.onClick.AddListener(BackBehavior);

        back2 = gameSelect2.transform.GetChild(3).GetComponent<Button>();
        back2.onClick.AddListener(BackBehavior2);

        Quit = playerSelect.transform.GetChild(2).GetComponent<Button>();
        Quit.onClick.AddListener(QuitBehavior);

        unlockGame = transform.GetChild(6).transform.GetChild(0).gameObject.GetComponent<Button>();
        unlockGame.onClick.AddListener(BuyGame);

        saveGameToCloud = transform.GetChild(1).transform.GetChild(8).gameObject.GetComponent<Button>();
        saveGameToCloud.onClick.AddListener(SaveGameToCloud);
        loadGameFromCloud = transform.GetChild(1).transform.GetChild(9).gameObject.GetComponent<Button>();
        loadGameFromCloud.onClick.AddListener(LoadGameFromCloud);
        loadedText = transform.GetChild(1).transform.GetChild(10).gameObject.GetComponent<Text>();

        settingsScript = settingsMenu.GetComponent<Settings>();

        // Trial variable initializations
        deactivateButton = transform.GetChild(0).transform.GetChild(1).GetComponent<Button>();
        deactivateButton2 = transform.GetChild(0).transform.GetChild(2).GetComponent<Button>();
        deactivateButton3 = transform.GetChild(2).transform.GetChild(1).GetComponent<Button>();
        deactivateButton4 = transform.GetChild(2).transform.GetChild(2).GetComponent<Button>();
        trialText = transform.GetChild(9).transform.GetChild(0).GetComponent<Text>();
        trialTextObject = transform.GetChild(9).gameObject;
        unlockGameBanner = transform.GetChild(6).gameObject;
        if(GameData.data.trialBuild)
        {
            Quit.gameObject.transform.localPosition = new Vector3(0, -615, 0);
        }
        /////////////////////////////////

        // Component variables
        discoMode = transform.GetChild(7).gameObject;
        mainLight = transform.GetChild(11).gameObject;
        loginAnimation = login.gameObject.GetComponent<SpriteAnimation>();
        loginFlicker = transform.GetChild(1).transform.GetChild(4).transform.GetComponent<Flicker>();
        exitApp = transform.GetChild(1).transform.GetChild(6).gameObject;
        arrow = transform.GetChild(3).transform.GetChild(2).gameObject;
        lbPressed = leaderboardButton.GetComponent<ButtonPressed>();
        achievePressed = achievementButton.GetComponent<ButtonPressed>();
        doorTrans = metalDoors.gameObject.GetComponent<GameTransition>();
        doorTitle = metalDoors.transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<Image>();
        doorTitle2 = metalDoors.transform.GetChild(0).transform.GetChild(2).transform.gameObject;
        //////////////////////
    }
    public static String GetUTCFormattedTimestamp()
    {
        DateTime datTimeUTC = DateTime.Now.ToUniversalTime();
        DateTime dt = new DateTime(datTimeUTC.Year, datTimeUTC.Month, datTimeUTC.Day, datTimeUTC.Hour, datTimeUTC.Minute, datTimeUTC.Second, datTimeUTC.Millisecond);
        return String.Format("{0:yyyy-MM-dd}", dt);
    }
    // Update is called once per frame
    void Update() {
        TrialVersion();

        if (GameData.data.discoMode)
        {
            discoMode.SetActive(true);
            mainLight.SetActive(false);
        }
        else
        {
            discoMode.SetActive(false);
            mainLight.SetActive(true);
        }

        if (!triedLog)
        {
            if (GameData.data.autoLog == 1)
            {
                Social.localUser.Authenticate((bool success) => {
                    //Do something depending on the success achieved
                    //Debug.Log(Social.localUser.userName + " Logged In!");
                    if (success)
                    {
                        loginAnimation.loginSuccess = 1;
                        gamerTag.text = Social.localUser.userName;
                        gamerPic.texture = Social.localUser.image;
                        gamerTag.gameObject.SetActive(false);
                        string date = GetUTCFormattedTimestamp();
                        if (date.Equals(GameData.data.date))
                        {
                            //do nothing
                        }
                        else
                        {
                            Achievements.unlock.Week();
                            Achievements.unlock.Month();
                            GameData.data.date = date;
                            GameData.data.Save();
                        }
                    }
                    else
                        loginAnimation.loginSuccess = 2;

                    loginFlicker.TurnOn();
                });
                triedLog = true;
            }
        }

        if (Social.localUser.authenticated)
        {
            gamerPic.texture = Social.localUser.image;
        }

        if (Input.GetKeyDown("escape"))
        {
            if (playerSelect.gameObject.activeSelf)
            {
                if (exitApp.activeSelf)
                    exitApp.SetActive(false);
                else
                    exitApp.SetActive(true);
            }
            else if (gameSelect.gameObject.activeSelf)
            {
                playerSelect.gameObject.SetActive(true);
                gameSelect.gameObject.SetActive(false);
            }
            else if (gameSelect2.gameObject.activeSelf)
            {
                if (shiftWindow.activeSelf)
                {
                    shiftWindow.SetActive(false);
                    sprint.gameObject.SetActive(true);
                    tug.gameObject.SetActive(true);
                    shift.gameObject.SetActive(true);
                    back2.gameObject.SetActive(true);
                }
                else
                {
                    playerSelect.gameObject.SetActive(true);
                    gameSelect2.gameObject.SetActive(false);
                }
            }
            else if (settingsMenu.gameObject.activeSelf)
            {
                if (!settingsScript.signOutSuccess.activeSelf)
                {
                    settingsMenu.gameObject.SetActive(false);
                    playerSelect.gameObject.SetActive(true);
                }
            }
        }

        if(arrow.activeSelf)
        {
            arrowElapsed += Time.deltaTime;
        }
        if (lbPressed.buttonPressed
        || achievePressed.buttonPressed)
        {
            if (!Social.localUser.authenticated)
            {
                arrow.SetActive(true);
            }
        }
        else
        {
            if (arrowElapsed >= 3.0)
            {
                arrow.SetActive(false);
                arrowElapsed = 0;
            }
        }
        if (Input.GetKeyDown("space"))
        {
        }

        if(doorTrans.closed)
        {
            LoadGame();
        }
    }

    void UnlockAchievement()
    {
        
    }

    void ShowAd()
    {
        
    }

    void BackBehavior()
    {
        playerSelect.gameObject.SetActive(true);
        gameSelect.gameObject.SetActive(false);
    }

    void BackBehavior2()
    {
        playerSelect.gameObject.SetActive(true);
        gameSelect2.gameObject.SetActive(false);
    }

    void QuitBehavior()
    {
        exitApp.SetActive(true);
    }

    void SpeedBehavior()
    {
        showingBanner = false;
        playerSelect.gameObject.SetActive(true);
        gameSelect.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        GameData.data.LoadSpeed();
    }

    void SprintBehavior()
    {
        showingBanner = false;
        playerSelect.gameObject.SetActive(true);
        gameSelect2.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        GameData.data.LoadSprint();
    }

    void MemoryBehavior()
    {
        showingBanner = false;
        playerSelect.gameObject.SetActive(true);
        gameSelect.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        GameData.data.LoadMemory();
    }

    void TugBehavior()
    {
        showingBanner = false;
        playerSelect.gameObject.SetActive(true);
        gameSelect2.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        GameData.data.LoadTug();
    }

    void SeqBehavior()
    {
        showingBanner = false;
        playerSelect.gameObject.SetActive(true);
        gameSelect.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        GameData.data.LoadSequence();
    }

    void ShiftBehavior()
    {
        shiftWindow.SetActive(true);
        sprint.gameObject.SetActive(false);
        tug.gameObject.SetActive(false);
        shift.gameObject.SetActive(false);
        back2.gameObject.SetActive(false);
    }

    void Shift1Behavior()
    {
        showingBanner = false;
        GameData.data.game = 8;
        playerSelect.gameObject.SetActive(true);
        gameSelect.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        GameData.data.LoadShift1();
    }

    void Players1Behavior()
    {
        playerSelect.gameObject.SetActive(false);
        gameSelect.gameObject.SetActive(true);
    }

    void Players2Behavior()
    {
        playerSelect.gameObject.SetActive(false);
        gameSelect2.gameObject.SetActive(true);
    }

    
    //Called from a UI Button
    public void GooglePlusStart()
    {
        
        //Start the Google Plus Overlay Login
        Social.localUser.Authenticate((bool success) => {
            //Do something depending on the success achieved
            //Debug.Log(Social.localUser.userName + " Logged In!");
            if (success)
            {
                loginAnimation.loginSuccess = 1;
                gamerTag.text = Social.localUser.userName;
                gamerPic.texture = Social.localUser.image;
                gamerTag.gameObject.SetActive(false);
                string date = GetUTCFormattedTimestamp();
                if (date.Equals(GameData.data.date))
                {
                    //do nothing
                }
                else
                {
                    Achievements.unlock.Week();
                    Achievements.unlock.Month();
                    GameData.data.date = date;
                    GameData.data.Save();
                }
            }
            else
                loginAnimation.loginSuccess = 2;

            loginFlicker.TurnOn();
        });
    }

    public void ShowLeaderBoard()
    {
        //        Social.ShowLeaderboardUI (); // Show all leaderboard
        //((PlayGamesPlatform)Social.Active).ShowLeaderboardUI();// Show current (Active) leaderboard
        if(Social.localUser.authenticated)
            Social.Active.ShowLeaderboardUI();
    }

    public void ShowAchievements()
    {
        if (Social.localUser.authenticated)
        {
            Social.Active.ShowAchievementsUI();
        }
    }

    public void ShowSettings()
    {
        settingsMenu.SetActive(true);
        playerSelect.gameObject.SetActive(false);
    }

    void BuyGame()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.nianticlabs.pokemongo");
    }

    void CloseDoors()
    {
        doorTrans.CloseDoors();
    }

	// DOORS CLOSE -- TITLE IMAGE CALLED

    void PendClassic()
    {
        GameData.data.game = 1;
        doorTitle.sprite = doorTrans.classic;
        pendGame = 1;
        CloseDoors();
    }
    void PendShift()
    {
        GameData.data.game = 8;
        doorTitle.sprite = doorTrans.shift;
        pendGame = 2;
        CloseDoors();
    }
    void PendMemory()
    {
        GameData.data.game = 3;
        doorTitle.sprite = doorTrans.memory;
        pendGame = 3;
        CloseDoors();
    }
    void PendSeq()
    {
        GameData.data.game = 5;
        doorTitle.sprite = doorTrans.sequence;
        pendGame = 4;
        CloseDoors();
    }
    void PendSprint()
    {
        GameData.data.game = 2;
        doorTitle.sprite = doorTrans.sprint;
        pendGame = 5;
        CloseDoors();
    }
    void PendTug()
    {
        GameData.data.game = 4;
        doorTitle.sprite = doorTrans.tug;
        pendGame = 6;
        CloseDoors();
    }
    public void PendSShift()
    {
        GameData.data.game = 6;
        doorTitle.sprite = doorTrans.sprint;
        doorTitle2.SetActive(true);
        pendGame = 7;
        CloseDoors();
    }
    public void PendTShift()
    {
        GameData.data.game = 7;
        doorTitle.sprite = doorTrans.tug;
        doorTitle2.SetActive(true);
        pendGame = 8;
        CloseDoors();
    }

    void LoadGame()
    {
        if (pendGame == 1)
            SpeedBehavior();
        else if (pendGame == 2)
            Shift1Behavior();
        else if (pendGame == 3)
            MemoryBehavior();
        else if (pendGame == 4)
            SeqBehavior();
        else if (pendGame == 5)
            SprintBehavior();
        else if (pendGame == 6)
            TugBehavior();
    }

    void TrialVersion()
    {
        if(GameData.data.trialBuild)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(GameData.data.trialTimeLeft);
            trialText.text = "Trial Time - " + 
                string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            if (GameData.data.trialTimeLeft <= 0)
            {
                deactivateButton.interactable = false;
                deactivateButton2.interactable = false;
                deactivateButton3.interactable = false;
                deactivateButton4.interactable = false;
            }
        }
        else
        {
            trialTextObject.SetActive(false);
            unlockGameBanner.gameObject.SetActive(false);
        }
    }

    void SaveGameToCloud()
    {
        GPG_CloudSaveSystem.Instance.SaveToCloud();
    }

    void LoadGameFromCloud()
    {
        GPG_CloudSaveSystem.Instance.LoadFromCloud();
        loadedText.text = GPG_CloudSaveSystem.Instance.ReturnLoadedFloat().ToString();
    }
    
}
