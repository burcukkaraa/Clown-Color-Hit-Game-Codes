using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balonetkilesim : MonoBehaviour {

    bool fly;
    Transform targt;
    public int katsayı;
    public AudioSource ses;
    public AudioClip ses3;

    private void OnTriggerEnter(Collider other)
    {
        Soul_Basic SB = other.GetComponent<Soul_Basic>();
        if (SB != null)
        {
            Debug.Log("balon ile tamas algılandı");
            SB.balondeger+=katsayı;
            AudioSource.PlayClipAtPoint(ses3, Camera.main.transform.position);
            Destroy(gameObject);
        }

    }
    public void callmeBaby(Transform target)
    {
        fly = true;
        targt = target;
    }

    private void Update()
    {
        if (fly)
        {
            transform.Translate((targt.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
        }
    }
    public float speed;
}
