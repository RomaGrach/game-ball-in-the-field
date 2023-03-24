using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeSliderV2 : MonoBehaviour
{
    [SerializeField] float deltaT = 0;
    [SerializeField] float ultraT = 1;
    [SerializeField] float Rotx = 0;
    [SerializeField] float Roty = 0;
    [SerializeField] float Rotz = 0;
    [SerializeField] float AmplitudeX = 1;
    [SerializeField] float AmplitudeY = 1;
    [SerializeField] float AmplitudeZ = 1;
    [SerializeField] float YMaxVel = 360;
    [SerializeField] bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float rotx = transform.rotation.x + AmplitudeX * Mathf.Sin(10*deltaT);
        float roty = transform.rotation.y + AmplitudeY;
        float rotz = transform.rotation.z + AmplitudeZ * Mathf.Sin(10*deltaT);
        Rotx = rotx;
        Roty = roty;
        Rotz = rotz;
        Quaternion rot = Quaternion.Euler(rotx, roty, rotz);
        transform.rotation = rot;
        AmplitudeY += deltaT;
        if (AmplitudeY >= YMaxVel && flag)
        {
            AmplitudeX += Mathf.Abs(deltaT);
            ultraT = -ultraT;
            flag = false;
        }
        if (AmplitudeY <= -YMaxVel && !flag)
        {
            AmplitudeZ += Mathf.Abs(deltaT);
            ultraT = -ultraT;
            flag = true;
        }
        deltaT += ultraT;

        //AmplitudeZ += deltaT;
    }
}
