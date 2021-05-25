using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public MusicPlayer mp;

    private void Awake()
    {

        /*if (mp != null)
        {
            Destroy(gameObject);
        }*/

        if (mp == null)
        {
            mp = this;
            //DontDestroyOnLoad(mp);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
