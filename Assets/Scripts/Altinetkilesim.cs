using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Altinetkilesim : MonoBehaviour
{
    public AudioSource ses;
    public AudioClip ses2;
    public float speed;
    public int katsayı;


    private void Start()
    {
        ses = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Soul_Basic SB = other.GetComponent<Soul_Basic>();
        if (SB != null && other.gameObject.name=="Palyaçoviç")
        {
            
           
            Debug.Log("altin ile tamas algılandı");
            SB.altindeger += katsayı;
            AudioSource.PlayClipAtPoint(ses2, Camera.main.transform.position);
            Destroy(gameObject);
           
           
        }

    }

    private void Update()
    {
        if (fly)
        {
            transform.Translate((targt.position - transform.position).normalized*speed * Time.deltaTime, Space.World);
        }
    }
    public void callmeBaby(Transform target)
    {
        fly = true;
        targt = target;
    }Transform targt;bool fly;
}
