using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Advertisements;

public class SceneManage : MonoBehaviour
{
    public string sahne;
    public float reklamolasiligi;


    public void load()
    {
        if (Random.Range(0, 100) < reklamolasiligi)
        { Advertisement.Show(); }

        SceneManager.LoadScene(sahne);
    }
}
