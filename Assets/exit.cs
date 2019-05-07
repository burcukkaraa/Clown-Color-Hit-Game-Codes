using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        setactive(false);
	}
    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            setactive(true);
        }
    }

    public void setactive(bool a)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(a);
        }
    }
    public void quit()
    {
        Application.Quit();
    }
}
