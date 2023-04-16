using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetSkinInGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = Progress.Instance.materialsListBuyed[Progress.Instance.SkinIndeks];
    }
}
