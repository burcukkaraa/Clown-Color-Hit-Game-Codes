using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{

    public Transform Target;
    
    Quaternion targetrot;
    Vector3 Targetpos;
    
    public float  smoothSpeed, camHeight, minCamDistance,maxCamDistance,HorizontalArcWidth,VerticalArcWidth,HorizontalCalibration,VerticalCalibration;
    public bool smooth,turnWithTarget;
    float  camDistance, angle, angleY;

    Vector3 tr;
    private void Start()
    {
     //   Cursor.visible = false;
       
        angle = 0;
        angleY = 0;
        camDistance = (minCamDistance + maxCamDistance) / 2;
        tr.Set(0, 0, 0);
    }
    void LateUpdate()
    {
        camDistance -= Input.GetAxis("Mouse ScrollWheel") * 2;
        camDistance = Mathf.Clamp(camDistance, minCamDistance, maxCamDistance);

        angle += Input.GetAxis("Mouse X");
        angle = Mathf.Clamp(angle, -HorizontalArcWidth, HorizontalArcWidth);
        float cangle = angle/2 + HorizontalCalibration;

        angleY -= Input.GetAxis("Mouse Y");
        angleY = Mathf.Clamp(angleY, -VerticalArcWidth, VerticalArcWidth);
        float calibratedangley = angleY/2 + VerticalCalibration;

        if (turnWithTarget) { tr = Target.rotation.eulerAngles; }
        Targetpos = Target.position + Vector3.up * camHeight - transform.forward * camDistance;
        targetrot = Quaternion.Euler(tr[0]+ calibratedangley,tr[1]+ cangle, 0);

        if (smooth)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetrot, smoothSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, Targetpos, smoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Targetpos, smoothSpeed * Time.deltaTime);
         //   transform.position = Targetpos;
            transform.rotation = targetrot;
        }
    }

}