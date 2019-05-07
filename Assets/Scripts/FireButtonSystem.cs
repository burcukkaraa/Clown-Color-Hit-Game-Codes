using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButtonSystem : MonoBehaviour {

    public Transform ratatuile;

    public AudioSource ses;
    public AudioClip ses4;

    public void colorchoosered ()
    {
        Color32 colorred = Color.red;
        Debug.Log("kırmızı renk olusturuldu");
        RenkAktar(colorred);
        AudioSource.PlayClipAtPoint(ses4, Camera.main.transform.position);
    }

    public void colorchooseblue()
    {
        Color32 colorblue = Color.blue;
        Debug.Log("mavi renk olusturuldu");
        RenkAktar(colorblue);
        AudioSource.PlayClipAtPoint(ses4, Camera.main.transform.position);
    }

    public void colorchoosegreen()
    {
        Color32 colorgreen = Color.green;
        Debug.Log("yeşil renk olusturuldu");
        RenkAktar(colorgreen);
        AudioSource.PlayClipAtPoint(ses4, Camera.main.transform.position);
    }

    public void colorchooseyellow()
    {
        Color32 coloryellow = Color.yellow;
        Debug.Log("sarı renk olusturuldu");
        RenkAktar(coloryellow);
        AudioSource.PlayClipAtPoint(ses4, Camera.main.transform.position);
    }

    void RenkAktar(Color32 c)
    {
        
      ratatuile.GetComponent<Soul_Basic>().ateset(c);
     
    }
}
