using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hediye : MonoBehaviour {

    public OzelGuc[] Hediyeler;
    
    public AudioSource ses;
    public AudioClip seshediye;

    IEnumerator destroyla()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(1);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Gamer>() != null)
        {
            StartCoroutine(destroyla());
            AudioSource.PlayClipAtPoint(seshediye, Camera.main.transform.position);
            

            int loopsafety = 0;

            while (true)  //bir hediye seçilene kadar tekrar edecek döngü
            {
                int i = Random.Range(0, Hediyeler.Length); //rastgele hediye

                if (Hediyeler[i].Nadirlik > Random.Range(0, 100))
                {
                    other.GetComponent<Gamer>().AddPower(Hediyeler[i]);  //gamer'a sanal objeyi gönder
                    GetComponent<Animator>().SetTrigger("open");  //hediye kutusu açılma animasyonu
                    break;
                }
                else { i = Random.Range(0, Hediyeler.Length); } //eğer hediyenin şansı yetmezse başka hediye seç

                if (loopsafety++ > 100) { break; } //döngü çok uzarsa durdur.
            }
        }
    }
}
