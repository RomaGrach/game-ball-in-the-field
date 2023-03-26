using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigCubeMove : MonoBehaviour
{
    private Rigidbody _rb;
    public float _speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        _rb.AddForce(new Vector3(-1, 0, 0) * _speed * Time.fixedDeltaTime);
    }
}
