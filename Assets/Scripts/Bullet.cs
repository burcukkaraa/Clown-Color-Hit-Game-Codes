using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {


    Vector3 startingscale,Gundirection; //başlangıç büyüklüğü, nişan yönü
    public float inflatingSpeed, TravelSpeed, lifeLenght; //şişme hızı, hareket hızı
    public Transform root;
    bool inflating; //şişiyor
    public int colorcode;
    public Color32 BulletColor;
    Material mat;
   

    void Awake ()
    {
        inflating = true;
        startingscale = transform.localScale;  //başlangıç büyüklüğünü kaydediyorum.
        transform.localScale = Vector3.zero;   //objenin büyüklüğünü sıfırlıyorum.

        mat = transform.GetComponent<MeshRenderer>().material;
        mat.color = BulletColor;

       
    }
    private void Start()
    {
        
    }
    float timer;
	void Update ()
    {
        if (inflating)    //eğer şişme faslındaysak
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startingscale, Time.deltaTime * inflatingSpeed);
            //yavaşça objeyi başlangıç büyüklüğüne getir.


            if (transform.localScale.x > 0.9f*startingscale.x)//eğer yeterince büyüdüyse
            {
                transform.GetComponent<Rigidbody>().isKinematic = false;
                inflating = false;  //şişme faslını bitir.
                root = transform.root.GetComponent<Soul_Basic>().Path;
                Gundirection = root.forward; //silahın yönünü kaydet 
            transform.parent = null;  //özgürleş!
                mat.color = BulletColor;
            }
        }
        else
        {
            transform.Translate(Gundirection * Time.deltaTime * TravelSpeed,Space.World);  //atıl kurt!
        }
        timer += Time.deltaTime;
        if (timer >= lifeLenght) { Destroy(gameObject); }
	}

    private void OnCollisionEnter(Collision collision)
    {
        ColorLock CL =collision.collider.GetComponent<ColorLock>();
        Debug.Log("Çarpışma algılandı");
        if (CL != null)
        {
            CL.OpenThatDamnGateUlan(BulletColor);
            Debug.Log("renk kodu iletildi!");
           
            Destroy(gameObject);
        }

    }
}
