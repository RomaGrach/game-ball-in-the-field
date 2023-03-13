using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destCube", 7f);
    }
    private void destCube(){
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
