using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindFlow : MonoBehaviour
{
    [SerializeField] GameObject Pointer;
    [SerializeField] GameObject Anchor;
    [SerializeField] float windStrength = 0f;
    [SerializeField] float windStrengthAcc = 0f;
    private int i;
    private float oldTime = 0;
    private float dice;
    private void Start()
    {
        Pointer = GameObject.Find("WindPointer");

        Anchor = GameObject.Find("ParticleAnchor");

        GetComponent<ConstantForce>().torque = new Vector3(windStrength, 0, 0);
    }
    void FixedUpdate()
    {
        float currTime = FindAnyObjectByType<TimeChanger>().time;
        if (FindAnyObjectByType<gameStart>().Gstart)
        {
            if (currTime - oldTime > 8f) { 
                oldTime = currTime;
                if (Random.value > 0.5)
                {
                    var PointT = Pointer.GetComponent<Transform>();
                    float rand = Random.Range(1f, 1.2f);
                    float randWind = windStrength * rand;
                    dice = Random.Range(1f, 4f);
                        // +x
                        if (dice < 2)
                        {
                            Anchor.GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);

                            GetComponent<ConstantForce>().torque = new Vector3(0, 0, -randWind);
   
                            PointT.rotation = Quaternion.Euler(-35, 0, 0);
                            PointT.localPosition = new Vector3(0, 0, 5);
                        }
                        // -x
                        else if (dice < 3 && dice >= 2)
                        {
                            Anchor.GetComponent<Transform>().rotation = Quaternion.Euler(0, 270, 0);

                            GetComponent<ConstantForce>().torque = new Vector3(0, 0, randWind);

                            PointT.rotation = Quaternion.Euler(-35, 0, 180);
                            PointT.localPosition = new Vector3(0, 0, 5);
                    }
                        //-z
                        else if (dice < 4 && dice >= 3)
                        {
                            Anchor.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);

                            GetComponent<ConstantForce>().torque = new Vector3(-randWind, 0, 0);

                            PointT.rotation = Quaternion.Euler(0, 90, -35);
                            PointT.localPosition = new Vector3(0, 0, 6);
                    }
                        //+z
                        else
                        {
                            Anchor.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);

                            GetComponent<ConstantForce>().torque = new Vector3(randWind, 0, 0);

                            PointT.rotation = Quaternion.Euler(0, 270, 35);
                            PointT.localPosition = new Vector3(0, 0, 6);
                    }
                }
                windStrength += windStrengthAcc;
            }
        }
    }
    //void ChangeDirection()
}
