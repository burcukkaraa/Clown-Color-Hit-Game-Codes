using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settingmenu : MonoBehaviour {

    public Button musicoff_btn;
    public Button musicon_btn;
    public Button soundeffecton_btn;
    public Button soundeffectoff_btn;

    public AudioSource ses;
    public AudioClip sessetting;

    public void sescal()
    {
        AudioSource.PlayClipAtPoint(sessetting, Camera.main.transform.position);

    }
    public void musicoff()
    {
        // ses.volume = 0;
        //AudioListener.volume = 1;
        sescal();
        musicoff_btn.gameObject.active=true;
        musicon_btn.gameObject.active = false;
    }
    public void musicon()
    {
        //ses.volume = 1;
        //AudioListener.volume = 0;
        sescal();
        musicoff_btn.gameObject.active = false;
        musicon_btn.gameObject.active = true;
    }
    public void ses_durum(string durum)
    {
        if (durum=="acik")
        {
            sescal();
            musicoff_btn.gameObject.active = true;
            musicon_btn.gameObject.active = false;
            PlayerPrefs.SetInt("sesDurum", 0);
            PlayerPrefs.Save();
        }
        else if (durum=="kapali")
        {
            sescal();
            musicoff_btn.gameObject.active = false;
            musicon_btn.gameObject.active = true;
            PlayerPrefs.SetInt("sesDurum", 1);
            PlayerPrefs.Save();
        }
    }


    // 
    void Start ()
    {
        musicoff_btn.gameObject.active = false;
        musicon_btn.gameObject.active = true;

        //soundeffectoff_btn.gameObject.active = false;
        // soundeffecton_btn.gameObject.active = true;

        PlayerPrefs.SetInt("sesDurum", 1);

    }

    // 
    void Update ()
    {
        if (PlayerPrefs.GetInt("sesDurum")==1)
        {
            musicoff_btn.gameObject.active = false;
            musicon_btn.gameObject.active = true;
        }
        else
        {
            musicoff_btn.gameObject.active = true;
            musicon_btn.gameObject.active = false;
        }
	}
}
