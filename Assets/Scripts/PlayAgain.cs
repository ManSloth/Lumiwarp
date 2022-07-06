using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour {

    Button yes, no;

	// Use this for initialization
	void Start () {
        yes = transform.GetChild(0).transform.GetComponent<Button>();
        no = transform.GetChild(1).transform.GetComponent<Button>();

        yes.onClick.AddListener(YesButton);
        no.onClick.AddListener(NoButton);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void YesButton()
    {
        if(GameData.data.game == 1)
            GameData.data.ReloadSpeed();
        if (GameData.data.game == 2)
            GameData.data.ReloadSprint();
        if (GameData.data.game == 3)
            GameData.data.ReloadMemory();
        if (GameData.data.game == 4)
            GameData.data.ReloadTug();
        if (GameData.data.game == 5)
            GameData.data.ReloadSequence();
        if (GameData.data.game == 6)
            GameData.data.ReloadShift();
        if (GameData.data.game == 7)
            GameData.data.ReloadShiftT();
        if (GameData.data.game == 8)
            GameData.data.ReloadShift1();
    }

    void NoButton()
    {
        GameData.data.LoadMenu();
        //Application.Quit();
    }
}
