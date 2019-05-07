using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SesKontrol : MonoBehaviour {

    public AudioSource ses_kontrol;

	// 
	void Start ()
    {
        ses_kontrol = GetComponent<AudioSource>();


        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {   //ses_kontrol.Play();
            ses_kontrol.mute = false;

        }
        else
            ses_kontrol.mute = true;




    }
    private void Update()
    {
    }

}
