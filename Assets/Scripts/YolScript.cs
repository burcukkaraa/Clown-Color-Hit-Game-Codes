using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YolScript : MonoBehaviour {

    // tek bir seferde oyunda yer alacak olan yol sayısı
    public int yolSayisi;
    public float engelYogunlugu;
    // yol prefabı
    public GameObject yolPrefab;
    public Transform Karakter;
    // ekrandaki yolları depolayan array
    private Transform[] yollar;

    // en başta kalan yolun index'ini depolayan değişken
    private int BastakiYolIndisi;

    int ScoreValue;
    public Text Score;
    public Text gameoverscore;

    private float yolUzunluk;

    Vector3 objekonum = new Vector3(-3,0,400);


    public GameObject[] Objeler;
    public float[] objeOlasiliklari;

    void Start ()
    {
        yollar = new Transform[yolSayisi];
        BastakiYolIndisi = 0;

        // ObjectList = new List<GameObject>();

        // yolSayisi kadar yol oluşturup bunları uç uca diz
        yolUzunluk = yolPrefab.GetComponent<MeshFilter>().sharedMesh.bounds.size.z;
        Debug.Log("Yol uzunluğu " + yolUzunluk + " olarak algılandı.");

        for (int i = 0; i < yolSayisi; i++)
        {
            Vector3 pozisyon = new Vector3(Karakter.position.x, Karakter.position.y-2, Karakter.position.z+ i * yolUzunluk);
            yollar[i] = (Instantiate(yolPrefab, pozisyon, Quaternion.identity)).transform;

           
        }
        
        
    }
	

	private void Update ()
    {
        float kameraZ = Karakter.position.z;
        float bastakiYolZ = yollar[BastakiYolIndisi].position.z;

        // eğer en baştaki yol objesi kameranın hizasına kadar gelmişse
        // (yani karakterin gerisinde kalmışsa) v
        if (kameraZ >= bastakiYolZ + yolUzunluk)
        {
            // baştaki yolu en sona taşı
            yollar[BastakiYolIndisi].position += new Vector3(0, 0, yolUzunluk * yolSayisi);

            if (yollar[BastakiYolIndisi].childCount > 1)
            { Destroy(yollar[BastakiYolIndisi].GetChild(1).gameObject); }

            //olasilik matrisine göre obje ekleme
            int i = Random.Range(0, Objeler.Length);
            if (Random.Range(0, 100) < objeOlasiliklari[i])
            {
                ObjeEkle(yollar[BastakiYolIndisi], Objeler[i], engelYogunlugu);
            }





            BastakiYolIndisi++;
            if (BastakiYolIndisi >= yolSayisi)
            {

                BastakiYolIndisi = 0;
            }
        }
    }

    void ObjeEkle(Transform Yol, GameObject Obje,float chance)
    {
            GameObject a = Instantiate(Obje);
        a.transform.position =Yol.transform.position + new Vector3(Random.Range(-2,2), 0, 0);
        a.transform.parent = null;

    }

    public void AddScore(int skor)
    {
        ScoreValue += skor;
        Score.text = "" + ScoreValue;
        gameoverscore.text= "" + ScoreValue;
        engelYogunlugu = 10 + ScoreValue / 1000;
    }
   


}
