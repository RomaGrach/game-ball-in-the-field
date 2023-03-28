using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFlow : MonoBehaviour
{
    private int i;
    [SerializeField] float dice;
    void FixedUpdate()
    {
        if (FindAnyObjectByType<TimeChanger>().time > 10f)
        {
            if (Random.value > 0.8)
            {
                dice = Random.Range(1f, 4f);
               // if (dice < 2f) 

            }
        }
    }
    //void ChangeDirection()
}
