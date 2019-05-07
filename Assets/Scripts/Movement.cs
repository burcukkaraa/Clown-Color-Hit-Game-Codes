using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float AksAralıgı,Hiz,Zıplama;
    float a;

    Vector3 Input,GlobalVelocity,Direction;
	void Start ()
    {
		
	}
	

	void Update ()
    {
        Input = LocalSpeedInput();
    //    GlobalVelocity = SpeedConvertToGlobal(Input, Direction,Hiz,Zıplama);
	}

    public virtual Vector3 LocalSpeedInput()
    {
        Vector3 loclsped = Vector3.zero;
        loclsped.x = UnityEngine.Input.GetAxis("Horizontal");
        loclsped.z = 1;
        if (UnityEngine.Input.GetKey(KeyCode.Space)) { loclsped.y = 1; }
        return loclsped;
    }
    public virtual Vector3 SpeedConvertToGlobal(Vector3 local,Transform Ground, float speed, float JumpPower)
    {
        Vector3 GlobalVector;
        float Y = local.y;

        local.y = 0;
        GlobalVector = Ground.TransformDirection(local.normalized);
        GlobalVector *= speed;
        GlobalVector.y = Y * JumpPower;

        return GlobalVector;
    }
}
