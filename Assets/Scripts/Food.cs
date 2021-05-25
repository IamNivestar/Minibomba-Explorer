using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    CircleCollider2D co;

    public int foodlevel;

    AudioSource audioS;
    // Use this for initialization
    void Start () {
        audioS = gameObject.GetComponent<AudioSource>();
        co = gameObject.GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play(); 
            GameManager.gm.SetFood(foodlevel);
            co.enabled = false;
            Destroy(gameObject, 0.1f);
        }
    }
}

