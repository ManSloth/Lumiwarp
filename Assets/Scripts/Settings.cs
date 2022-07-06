using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;

public class Settings : MonoBehaviour {


    GameObject musicSlider,fxSlider, overlay, gamerTag;
    public GameObject signOutSuccess;
    Button autoLog, back, vibration, discoMode, logout, ok;
    Text musicValue, fxValue;
    SpriteAnimation login;
    RawImage gamerPic;

    int musicNumber, fxNumber;
    int oldFxVolume;

    public Sprite red, redPushed, green, greenPushed;
    public Texture defaultPic;

    bool startUp;
    bool logPrev;
    bool firstFrame;
    bool vibePrev;
    bool discoPrev;
	// Use this for initialization
	void Start ()
    {
        startUp = true;
        logPrev = false;
        firstFrame = true;
        vibePrev = false;
        discoPrev = false;

        musicSlider = transform.GetChild(2).gameObject;
        musicValue = transform.GetChild(3).gameObject.GetComponent<Text>(); ;
        fxSlider = transform.GetChild(5).gameObject;
        fxValue = transform.GetChild(6).gameObject.GetComponent<Text>();
        autoLog = transform.GetChild(8).gameObject.GetComponent<Button>();
        back = transform.GetChild(9).gameObject.GetComponent<Button>();
        vibration = transform.GetChild(11).gameObject.GetComponent<Button>();
        discoMode = transform.GetChild(13).gameObject.GetComponent<Button>();
        logout = transform.GetChild(14).gameObject.GetComponent<Button>();
        signOutSuccess = transform.GetChild(15).gameObject;
        ok = signOutSuccess.transform.GetChild(2).GetComponent<Button>();
        login = transform.parent.GetChild(1).GetChild(4).GetComponent<SpriteAnimation>();
        overlay = transform.parent.GetChild(3).gameObject;
        gamerTag = overlay.transform.GetChild(1).gameObject;
        gamerPic = overlay.transform.GetChild(0).transform.GetComponent<RawImage>();

        autoLog.onClick.AddListener(AutoLogBehaviour);
        vibration.onClick.AddListener(VibrationBehaviour);
        discoMode.onClick.AddListener(DiscoBehaviour);
        back.onClick.AddListener(Back);

        logout.onClick.AddListener(SignOut);
        ok.onClick.AddListener(ExitWarning);

        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(GameData.data.loaded && startUp)
        {
            musicNumber = (int)(GameData.data.musicVol*100);
            fxNumber = (int)(GameData.data.fxVol*100);
            musicSlider.GetComponent<Slider>().value = musicNumber;
            fxSlider.GetComponent<Slider>().value = fxNumber;
            startUp = false;
        }
        if (oldFxVolume != fxSlider.GetComponent<Slider>().value)
        {
            if (!firstFrame)
                transform.GetComponent<AudioSource>().Play();
            else
                firstFrame = false;
        }
        if (logPrev == false && autoLog.GetComponent<ButtonPressed>().buttonPressed == true)
        {
            autoLog.GetComponent<AudioSource>().Play();
        }

        if (vibePrev == false && vibration.GetComponent<ButtonPressed>().buttonPressed == true)
        {
            vibration.GetComponent<AudioSource>().Play();
        }

        if (discoPrev == false && discoMode.GetComponent<ButtonPressed>().buttonPressed == true)
        {
            discoMode.GetComponent<AudioSource>().Play();
        }

        transform.GetComponent<AudioSource>().volume = GameData.data.fxVol;
        musicNumber = (int)musicSlider.GetComponent<Slider>().value;
        musicValue.text = musicNumber.ToString();
        fxNumber = (int)fxSlider.GetComponent<Slider>().value;
        fxValue.text = fxNumber.ToString();

        GameData.data.musicVol = (musicSlider.GetComponent<Slider>().value /100);
        GameData.data.fxVol = (fxSlider.GetComponent<Slider>().value /100f);

        if (GameData.data.autoLog == 0)
        {
            autoLog.GetComponent<Image>().sprite = red;
            SpriteState st = new SpriteState();
            st.pressedSprite = redPushed;
            autoLog.spriteState = st;
        }
        else
        {
            autoLog.GetComponent<Image>().sprite = green;
            SpriteState st = new SpriteState();
            st.pressedSprite = greenPushed;
            autoLog.spriteState = st;
        }

        if (GameData.data.vibrate == 0)
        {
            vibration.GetComponent<Image>().sprite = red;
            SpriteState st = new SpriteState();
            st.pressedSprite = redPushed;
            vibration.spriteState = st;
        }
        else
        {
            vibration.GetComponent<Image>().sprite = green;
            SpriteState st = new SpriteState();
            st.pressedSprite = greenPushed;
            vibration.spriteState = st;
        }

        if (GameData.data.discoMode == false)
        {
            discoMode.GetComponent<Image>().sprite = red;
            SpriteState st = new SpriteState();
            st.pressedSprite = redPushed;
            discoMode.spriteState = st;
        }
        else
        {
            discoMode.GetComponent<Image>().sprite = green;
            SpriteState st = new SpriteState();
            st.pressedSprite = greenPushed;
            discoMode.spriteState = st;
        }

        oldFxVolume = (int)fxSlider.GetComponent<Slider>().value;
        logPrev = autoLog.GetComponent<ButtonPressed>().buttonPressed;
        vibePrev = vibration.GetComponent<ButtonPressed>().buttonPressed;
        discoPrev = discoMode.GetComponent<ButtonPressed>().buttonPressed;

        transform.GetChild(8).GetComponent<AudioSource>().volume = GameData.data.fxVol;
        transform.GetChild(11).GetComponent<AudioSource>().volume = GameData.data.fxVol;
        transform.GetChild(13).GetComponent<AudioSource>().volume = GameData.data.fxVol;
    }

    void AutoLogBehaviour()
    {
        if(GameData.data.autoLog == 0)
        {
            GameData.data.autoLog = 1;
        }
        else
        {
            GameData.data.autoLog = 0;
        }
        
    }

    void VibrationBehaviour()
    {
        if (GameData.data.vibrate == 1)
            GameData.data.vibrate = 0;
        else
            GameData.data.vibrate = 1;
    }

    void DiscoBehaviour()
    {
        if (GameData.data.discoMode == false)
            GameData.data.discoMode = true;
        else
            GameData.data.discoMode = false;
    }

    void Back()
    {
        if (!signOutSuccess.activeSelf)
        {
            GameData.data.Save();
            transform.parent.GetChild(1).gameObject.SetActive(true);
            transform.gameObject.SetActive(false);
        }
    }

    void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
        login.loginSuccess = 0;
        signOutSuccess.SetActive(true);
        gamerTag.GetComponent<Text>().text = "Offline";
        gamerTag.SetActive(true);
        gamerPic.texture = defaultPic;
    }

    void ExitWarning()
    {
        signOutSuccess.SetActive(false);
    }
}
