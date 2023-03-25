using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTime : MonoBehaviour
{
    public float SpavnTime = 7f;
    public GameObject effect;
    public Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create3dObjects(SpavnTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Create3dObjects(float wait)
    {
        // таймер
        yield return new WaitForSeconds(wait);
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
