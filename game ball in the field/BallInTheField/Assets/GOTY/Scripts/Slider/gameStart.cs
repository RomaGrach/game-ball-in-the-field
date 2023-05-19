using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour
{
    public bool Gstart = false;
    private void Start()
    {    
    }
    public void _Start()
    {
        Gstart = true;
        //Time start
        GetComponent<TimeChanger>().enabled = true;
        //player scripts
        FindAnyObjectByType<WindFlow>().enabled = true;
        FindAnyObjectByType<ParticleSystem>().Play();
        FindAnyObjectByType<ConstantForce>().enabled = true;
        FindAnyObjectByType<PlayerMoveForse>().enabled = true;
        //platform scripts
        FindAnyObjectByType<SlopeSliderV2>().enabled = true;
        Debug.Log("Game Is Active!");
    }
}
