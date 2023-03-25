using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticMove : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private int _movePosition_x = 0;
    [SerializeField] private int _movePosition_y = 0;
    [SerializeField] private int _movePosition_z = 0;
    [SerializeField] private float _position_x_to= 9f;
    [SerializeField] private float _position_x_from = -7f;
    [SerializeField] private float _position_y_to = 9f;
    [SerializeField] private float _position_y_from = -7f;
    [SerializeField] private float _position_z_to = 9f;
    [SerializeField] private float _position_z_from = -7f;
    private float _tuda_suda_x = 1f;
    private float _tuda_suda_y = 1f;
    private float _tuda_suda_z = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position.x > _position_x_to || transform.position.x < _position_x_from) && _movePosition_x == 1)
        {
            _tuda_suda_x = -_tuda_suda_x;
        }
        if ((transform.position.y > _position_y_to || transform.position.y < _position_y_from) && _movePosition_y == 1)
        {
            _tuda_suda_y = -_tuda_suda_y;
        }
        if ((transform.position.z > _position_z_to || transform.position.z < _position_z_from) && _movePosition_z == 1)
        {
            _tuda_suda_z = -_tuda_suda_z;
        }
        float x = transform.position.x + _speed * Time.deltaTime * _tuda_suda_x * _movePosition_x;
        float y = transform.position.y + _speed * Time.deltaTime * _tuda_suda_y * _movePosition_y;
        float z = transform.position.z + _speed * Time.deltaTime * _tuda_suda_z * _movePosition_z;
        //float z = transform.position.z + 3f * Time.deltaTime;
        transform.position = new Vector3(x, y, z);
         
    }
}
