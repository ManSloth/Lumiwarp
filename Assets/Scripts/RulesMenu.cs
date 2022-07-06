using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RulesMenu : MonoBehaviour {

    Button back;

	// Use this for initialization
	void Start () {
        back = transform.GetChild(3).gameObject.GetComponent<Button>();
        back.onClick.AddListener(BackBehavior);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BackBehavior()
    {
        transform.gameObject.SetActive(false);
    }
}
