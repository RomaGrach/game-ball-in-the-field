using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticMove : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _position_x_to= 9f;
    [SerializeField] private float _position_x_from = -7f;
    private float _tuda_suda = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > _position_x_to || transform.position.x < -7)
        {
            _tuda_suda = -_tuda_suda;
        }
        float x = transform.position.x + _speed * Time.deltaTime * _tuda_suda;
        //float z = transform.position.z + 3f * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
         
    }
}
