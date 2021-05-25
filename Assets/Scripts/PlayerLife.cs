using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

    Animator anim;

    bool vivo = true;

    public AudioClip deathsound;

    AudioSource audioS;

    // Use this for initialization
    void Start() {
    
        anim = gameObject.GetComponent<Animator>();
        GameManager.gm.AtualizarHud();
        audioS = gameObject.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
		
	}
    public void PerdeVida()
    {
        if (vivo)
        {
            audioS.clip = deathsound;
            audioS.Play();
            vivo = false;
            anim.SetTrigger("die");
            GameManager.gm.SetVidas(-1);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
        
    }

    public void Reset()
    {       
        if (GameManager.gm.GetVidas() > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else{
            GameManager.gm.AtualizarMorte();
            SceneManager.LoadScene(4);
        }
    }
}
