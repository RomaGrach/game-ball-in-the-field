using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForLevel1 : MonoBehaviour
{
    public SceneControllerLevel1 sceneControllerLevel1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            sceneControllerLevel1.SoberTextFunk();
            Destroy(other.gameObject);
        }
    }
}
