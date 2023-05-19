using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeSlider : MonoBehaviour
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
    float Rand(float X, float Z)
    {
        if (Random.value > 0.5) return X += Mathf.Abs(deltaT);
        else return Z += Mathf.Abs(deltaT);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float rotx = transform.rotation.x + AmplitudeX * Mathf.Sin(deltaT);
        float roty = transform.rotation.y + AmplitudeY;
        float rotz = transform.rotation.z + AmplitudeZ * Mathf.Cos(deltaT);
        Rotx = rotx;
        Roty = roty;
        Rotz = rotz;
        Quaternion rot = Quaternion.Euler(rotx, roty, rotz);
        transform.rotation = rot;
        AmplitudeY += deltaT;
        if (AmplitudeY >= YMaxVel && flag)
        {
            Rand(AmplitudeX, AmplitudeZ);
            ultraT = -ultraT;
            flag = false;
        }
        if (AmplitudeY <= -YMaxVel && !flag)
        {
            Rand(AmplitudeX, AmplitudeZ);
            ultraT = -ultraT;
            flag = true;
        }
        deltaT += ultraT;
        //AmplitudeZ += deltaT;
    }
}
