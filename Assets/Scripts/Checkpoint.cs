using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private GameMaster gm;

    private Animator anim;

    AudioSource songAudio; 

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        songAudio = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            gm.lastCheckPointPos = transform.position;
            anim.SetTrigger("save");
            songAudio.Play();
        }
    }
}
