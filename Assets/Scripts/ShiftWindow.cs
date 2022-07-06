using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShiftWindow : MonoBehaviour {

    Button sprint, tugOfWar, back;
    GameObject playerSelect, gameSelect2, menu;
    public GameObject metalDoors;

	// Use this for initialization
	void Start () {
        gameSelect2 = transform.parent.gameObject;
        menu = gameSelect2.transform.parent.gameObject;
        playerSelect = menu.transform.GetChild(1).gameObject;

        sprint = transform.GetChild(1).GetComponent<Button>();
        sprint.onClick.AddListener(pendSprint);

        tugOfWar = transform.GetChild(2).GetComponent<Button>();
        tugOfWar.onClick.AddListener(pendTug);

        back = transform.GetChild(3).GetComponent<Button>();
        back.onClick.AddListener(BackBehavior);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (metalDoors.gameObject.GetComponent<GameTransition>().closed)
        {
            LoadGame();
        }
    }

    void SprintBehavior()
    {
        playerSelect.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
        gameSelect2.gameObject.SetActive(false);
        gameSelect2.transform.GetChild(0).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(1).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(2).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(3).gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
        GameData.data.LoadShift();
        //metalDoors.gameObject.GetComponent<GameTransition>().OpenDoors();
    }

    void TugOfWarBehavior()
    {
        playerSelect.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
        gameSelect2.gameObject.SetActive(false);
        gameSelect2.transform.GetChild(0).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(1).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(2).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(3).gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
        GameData.data.LoadShiftT();
        //metalDoors.gameObject.GetComponent<GameTransition>().OpenDoors();
    }

    void BackBehavior()
    {
        transform.gameObject.SetActive(false);
        gameSelect2.transform.GetChild(0).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(1).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(2).gameObject.SetActive(true);
        gameSelect2.transform.GetChild(3).gameObject.SetActive(true);
    }

    void pendSprint()
    {
        transform.parent.transform.parent.gameObject.GetComponent<Menu>().PendSShift();
    }

    void pendTug()
    {
        transform.parent.transform.parent.gameObject.GetComponent<Menu>().PendTShift();
    }

    void LoadGame()
    {
        if (transform.parent.transform.parent.gameObject.GetComponent<Menu>().pendGame == 7)
            SprintBehavior();
        else if (transform.parent.transform.parent.gameObject.GetComponent<Menu>().pendGame == 8)
            TugOfWarBehavior();
    }
}
