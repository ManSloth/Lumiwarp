using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exit2Player : MonoBehaviour {

    Button yes, no;
    

	// Use this for initialization
	void Start () {
        yes = transform.GetChild(1).GetComponent<Button>();
        no = transform.GetChild(2).GetComponent<Button>();

        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void Yes()
    {
        GameData.data.LoadMenu();
    }

    void No()
    {
        transform.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
