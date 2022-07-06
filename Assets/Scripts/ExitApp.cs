using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitApp : MonoBehaviour {

    Button yes, no;
    bool prevFrame;

	// Use this for initialization
	void Start () {
	
	}

	
	// Update is called once per frame
	void Update () {
        if(!prevFrame)
        {
            yes = transform.GetChild(1).GetComponent<Button>();
            yes.onClick.AddListener(Yes);

            no = transform.GetChild(2).GetComponent<Button>();
            no.onClick.AddListener(No);
            prevFrame = true;
        }
    }

    void Yes()
    {
        GameData.data.Save();
        transform.gameObject.SetActive(false);
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
        //Application.Quit();
    }

    void No()
    {
        prevFrame = false;
        transform.gameObject.SetActive(false);
    }
}
