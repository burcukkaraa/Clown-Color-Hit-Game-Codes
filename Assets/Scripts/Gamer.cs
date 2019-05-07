using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamer : MonoBehaviour {

    public Transform OPButton;
    Image image;
    OzelGuc OG;
    public float timer;
    public Text gerisayim;
    public GameObject gerisayimimage;
    bool ozelgucaktif ;

    void Start () {
        image = OPButton.GetChild(0).GetComponent<Image>();  //özel güç düğmesinin içindeki görseli al ve kapat
        image.enabled = false;

        gerisayimimage.active = false;
        gerisayim.enabled = false;
        timer = 6;
        gerisayim.text = "" + (int) timer;
        ozelgucaktif = false;

    }
    private void Update()
    {
        if (ozelgucaktif)
        {
            gerisayimimage.active = true;
            gerisayim.enabled = true;

            timer -= Time.deltaTime;
            gerisayim.text = "" + (int)timer;
            if (timer <= 0)
            {
                ozelgucaktif = false;
                timer = 5;
                gerisayim.text = "" + (int)timer;
                gerisayimimage.active = false;
                gerisayim.enabled = false;

               
                
            }
        }
       
    }



    public void AddPower(OzelGuc P)  //özel güç al ve butonun içindki görsele yaz
    {
        Debug.Log(P.name + " gücü alındı");
        OG = P;
        image.sprite= OG.Icon;
        image.enabled = true;
    }
    IEnumerator ReturnSpeed()
    {
        yield return new WaitForSeconds(5);
        transform.GetComponent<Soul_Basic>().MaxSpeed *= 2;
    }
    public void poweruse()  //düğmeye basıldığında çalışır.
    {
        ozelgucaktif = true;
        //use power

        image.enabled = false;

        if (OG.GucCesidi == Guc.Hayalet)
        {
            //hayalet güç çalışması...
           

            Collider[] etraf = Physics.OverlapSphere(transform.position, 100f);

            foreach (Collider C in etraf)
            {
                if (C.GetComponent<ColorLock>() != null)
                {
                    C.enabled = false;
                }
            }
        }
        if(OG.GucCesidi == Guc.Manyetik)
        {
            //manyetik güç çalışması...
           

            Collider[] etraf = Physics.OverlapSphere(transform.position, 100f);

            foreach(Collider C in etraf)
            {
                if (C.GetComponent<balonetkilesim>() != null)
                {
                    C.GetComponent<balonetkilesim>().callmeBaby(transform);
                }
                else if(C.GetComponent<Altinetkilesim>()!=null){
                    C.GetComponent<Altinetkilesim>().callmeBaby(transform);
                }
            }
        }
        if(OG.GucCesidi == Guc.Ucmak)
        {
            //şapka animasyonu
           

            transform.GetComponent<Soul_Basic>().jum = true;
        }

        if (OG.GucCesidi == Guc.Zaman)
        {
            transform.GetComponent<Soul_Basic>().MaxSpeed /= 2;
            StartCoroutine(ReturnSpeed());
        }
        if(OG.GucCesidi == Guc.IkiKat)
        {
            Collider[] etraf = Physics.OverlapSphere(transform.position, 100f);

            foreach (Collider C in etraf)
            {
                if (C.GetComponent<balonetkilesim>() != null)
                {
                    C.GetComponent<balonetkilesim>().katsayı *= 2; ;
                }
                else if (C.GetComponent<Altinetkilesim>() != null)
                {
                    C.GetComponent<Altinetkilesim>().katsayı *= 2;
                }
            }

        }
    }
}
