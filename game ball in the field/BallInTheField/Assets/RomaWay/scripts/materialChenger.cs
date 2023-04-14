using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChenger : MonoBehaviour
{
    public Material[] Materials;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCollor()
    {
        Renderer renderer = GetComponent<Renderer>();
        //renderer.material = newMaterial;
        
    }
}
