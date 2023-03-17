using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class playerMove : MonoBehaviour
{
    public float speed = 100.0f;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        _rb.AddForce(new Vector3(h, 0, v));
    }
}
