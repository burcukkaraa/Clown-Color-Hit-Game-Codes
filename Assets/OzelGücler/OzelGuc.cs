using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="ozelg",menuName ="Special Power")]
public class OzelGuc : ScriptableObject
{
    public Sprite Icon;

    public float Nadirlik; //nadirlik

    public int Fiyat; //fiyat

    public float beklemeSuresi;

    public Guc GucCesidi;

    public void Use()
    {

    }
}
public enum Guc { Ucmak, Manyetik, Hayalet, IkiKat, Sans, Zaman };

