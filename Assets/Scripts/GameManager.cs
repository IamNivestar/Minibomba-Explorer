using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    AudioSource audioUP;

    private int vidas = 3;
    private int food = 0;
	// Use this for initialization
	void Awake () {

        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
	}

    void Start()
    {
        AtualizarHud();
        audioUP = gameObject.GetComponent<AudioSource>();
    }
    public void SetVidas(int life)
    {
        vidas += life;
        if (vidas > 0)
            AtualizarHud();
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void SetFood(int meat)
    {
        food += meat;
        if (food >= 10)
        {
            //GameObject.Find("UP").GetComponent<Text>().text = 
            audioUP.Play();
            food = food - 10;
            vidas += 1;
        }

        AtualizarHud();
    }
        
    public void AtualizarHud()
    {
        GameObject.Find("VidasTexto").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("FoodTexto").GetComponent<Text>().text = food.ToString();
    }

    public void AtualizarMorte()
    {
        vidas = 3;
        food = 0;
      
    }
}

