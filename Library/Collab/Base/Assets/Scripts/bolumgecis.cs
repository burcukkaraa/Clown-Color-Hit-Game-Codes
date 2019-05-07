using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class bolumgecis : MonoBehaviour {

    public GameObject panel_pause;
    public static bool isPaused=false;
    public Scene scene;
    public Button durdur;
    public Soul_Basic SB;
    public GameObject panel_gameover;
    Scene sahne;

    public AudioSource ses;
    public AudioClip sesbuton;

    public void sescal()
    {
        AudioSource.PlayClipAtPoint(sesbuton, Camera.main.transform.position);

    }


    public void bolumyukle(string bolumyukle)
    {
        
        if (Random.Range(0f,10f)<0.35f) { Advertisement.Show();i = 0; }
        Application.LoadLevel(bolumyukle);
        sescal();
        Debug.Log(bolumyukle + " yuklendi");
        isPaused = false;
    }
    int i = 0;
 

    public void replayscenenow ()
    {
        Advertisement.Show();
        SceneManager.LoadScene("palyaco", LoadSceneMode.Single);
        isPaused = false;
    }

    public void oyuncikis()
    {
        Application.Quit();
        Debug.Log("oyundan cikildi");
    }
    public void pausemenuac ()
    {
      sescal();
      panel_pause.SetActive(true);
      isPaused = true;
      



    }
    public void pausemenukapat()
    {
        sescal();
        if (isPaused)
        {
            panel_pause.SetActive(false);
            isPaused = false;
           
        }
      
    }
    public void durdurfonk()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
    public void durdurbtnvisible()
    {
        if (sahne.name == "palyaco")
        {
            if (SB.panel_gameover.active)
            {
                durdur.enabled = false;
            }
            else if (!SB.panel_gameover.active)
            {
                durdur.enabled = true;
            }
        }
    }

    void Start ()
    {
        // panel_gameover = GameObject.Find("Panel_qameover").GetComponent<GameObject>();
        // panel_pause = GameObject.Find("Panel_pause").GetComponent<GameObject>();

        sahne = SceneManager.GetActiveScene();

        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            Debug.Log("escape");
            Application.LoadLevel("quitmenu");
        }

        if (sahne.name == "palyaco")
        {
            panel_pause.SetActive(false);
        }
        
         
        
    }


    void Update ()
    {
        sahne = SceneManager.GetActiveScene();

        if (sahne.name=="Mainmenu")
        {
            panel_gameover = null;
            panel_pause = null;
        }

        durdurfonk();
        durdurbtnvisible();



    }
}
