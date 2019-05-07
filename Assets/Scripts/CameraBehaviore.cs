using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviore : MonoBehaviour {

    public Transform Target;

    public Vector3 Zoom;
    Quaternion targetrot;
    Vector3 Targetpos;
    public float LookPosition, camSpeed, zoomLimit;
    float currentZoon, angle,angleY;


    private void Start()
    {
        Cursor.visible = false;
        Zoom.Set(0, 2f, 2);
        angle = 0;
        angleY = 0;
        
    }
    void LateUpdate()
    {
        currentZoon -= Input.GetAxis("Mouse ScrollWheel")*2;
        currentZoon = Mathf.Clamp(currentZoon, 1f, zoomLimit);

        angle += Input.GetAxis("Mouse X");
        angleY -= Input.GetAxis("Mouse Y");
        angleY = Mathf.Clamp(angleY, -25, 65);
     

        Targetpos = Target.position + Vector3.up * LookPosition - transform.forward * currentZoon;
        targetrot = Quaternion.Euler(angleY, angle, 0);

        transform.position = Vector3.Lerp(transform.position,Targetpos, camSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation,targetrot , camSpeed * Time.deltaTime);
    }

}