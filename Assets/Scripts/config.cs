using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config : MonoBehaviour {
    public GameObject menu;
    static public bool pause;
	// Use this for initialization
	void Start () {
        menu = Instantiate(menu, menu.transform.position, menu.transform.rotation) as GameObject;
        Pause(false);
    }
	
    void Pause(bool statusPause)
    {
        pause = statusPause;
        menu.SetActive(pause);

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(!pause);
        }
	}

    public void Resume(bool statusPause)
    {
        pause = statusPause;
        menu.SetActive(!pause);
    }
}
