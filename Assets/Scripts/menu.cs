﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CarregaFase(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void sair()
    {
        Application.Quit();
    }
}
