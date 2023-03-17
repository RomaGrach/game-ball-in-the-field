using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        //transform.parent = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_target)
        {
            transform.position = _target.position + new Vector3(0, 0.7f, -1.4f);
        }
    }
}
