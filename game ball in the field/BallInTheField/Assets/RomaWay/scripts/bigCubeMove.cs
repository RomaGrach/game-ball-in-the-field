using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bigCubeMove : MonoBehaviour
{
    private Rigidbody _rb;
    public float _speed = 100.0f;
    public GameObject obj_end;
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
        if (obj_end)
        {
            var heading = obj_end.transform.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.

            //_rb.AddForce(new Vector3(-1, 0, 0) * _speed * Time.fixedDeltaTime);
            _rb.AddForce(new Vector3(direction.x, direction.y, direction.z) * _speed * Time.fixedDeltaTime);

        }
    }
}
