using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOgranichenie : MonoBehaviour
{
    [SerializeField] float _ogr_x;
    [SerializeField] float _ogr_z;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_rb.transform.position.x > _ogr_x)
        {
            transform.position = new Vector3(_ogr_x, _rb.transform.position.y, _rb.transform.position.z);
        }
        if (_rb.transform.position.x < -_ogr_x)
        {
            transform.position = new Vector3(-_ogr_x, _rb.transform.position.y, _rb.transform.position.z);
        }
        if (_rb.transform.position.z > _ogr_z)
        {
            transform.position = new Vector3(_rb.transform.position.x, _rb.transform.position.y, _ogr_z);
        }
        if (_rb.transform.position.z < -_ogr_z)
        {
            transform.position = new Vector3(_rb.transform.position.x, _rb.transform.position.y, -_ogr_z);
        }
    }
}
