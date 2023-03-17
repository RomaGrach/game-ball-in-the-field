using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class BollGenerater : MonoBehaviour
{
    public GameObject obj;
    private float _time = 30.0f;
    public float SpavnTime = 5f;


    private int RN(int num1, int num2)
    {   // RandomeNamber
        return UnityEngine.Random.Range(num1, num2);
    }

    private void FixedUpdate()
    {

    }

    void Create()
    {
        for (int i = 0; i < 5; i++)
        {
            obj.GetComponent<Rigidbody>().mass= RN(1, 6);
            obj.GetComponent<Rigidbody>().drag = RN(0, 1);
            Instantiate(obj, new Vector3(8, 12f + RN(-1, 3), RN(-5,5)), Quaternion.Euler(0f, 0f, 0f));
        }
        StartCoroutine(Create3dObjects(SpavnTime));
    }

    private IEnumerator Create3dObjects(float wait)
    {
        // таймер
        yield return new WaitForSeconds(wait);
        Create();
    }

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
