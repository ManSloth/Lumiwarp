using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.UI;

public class AccessLeaderboard : MonoBehaviour {

    public string leadboardId;
    Button thisButton;


	// Use this for initialization
	void Start () {
        thisButton = transform.GetComponent<Button>();
        thisButton.onClick.AddListener(ShowLeaderboard);
	}

    // Update is called once per frame
    void Update()
    {
        if (thisButton.GetComponent<ButtonPressed>().buttonPressed)
        {
            thisButton.transform.GetChild(0).GetComponent<Text>().color = Color.HSVToRGB(0.128f, 1.0f, 0.78f);
        }
        else
        {
            thisButton.transform.GetChild(0).GetComponent<Text>().color = Color.HSVToRGB(0.128f, 1.0f, 1.0f);
        }
    }

    void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leadboardId);
        }
    }
}
