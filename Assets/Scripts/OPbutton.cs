using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPbutton : MonoBehaviour {

    public Transform Gamer;

    public void UseYourPower()
    {
        Gamer.GetComponent<Gamer>().poweruse();
    }
}
