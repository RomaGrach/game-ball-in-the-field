using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDeskTrigger : MonoBehaviour
{
    public GameObject _obj_end;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        bigCubeMove _bigCubeMove = other.attachedRigidbody.GetComponent<bigCubeMove>();
        if (_bigCubeMove)
        {
            Debug.Log("Сообщение для отладки");
            _bigCubeMove.obj_end = _obj_end;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
