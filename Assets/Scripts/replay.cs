using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour {


    public Scene scene;

	public void replayscenenow()
    {
        SceneManager.LoadScene("palyaco", LoadSceneMode.Single);
    }
}
