using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLock : MonoBehaviour {
    Animator gateAnimator;

    Color32[] colors;
    Color32 lockcolor;

    private void Awake()
    {
        gateAnimator = transform.GetComponent<Animator>();


        colors = new Color32[] { Color.green, Color.red, Color.blue, Color.yellow };

        lockcolor = colors[Random.Range(0, 4)];

        transform.GetChild(5).GetComponent<SkinnedMeshRenderer>().material.color = lockcolor;
        transform.GetChild(6).GetComponent<SkinnedMeshRenderer>().material.color = lockcolor;
    }

    public void OpenThatDamnGateUlan(Color32 mermiRengi)
    {
        if (mermiRengi.r==lockcolor.r && mermiRengi.g==lockcolor.g && mermiRengi.b==lockcolor.b)
        {
            gateAnimator.SetBool("acık", true);
            transform.GetComponent<SphereCollider>().enabled = false;
            Camera.main.GetComponent<YolScript>().AddScore(10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
