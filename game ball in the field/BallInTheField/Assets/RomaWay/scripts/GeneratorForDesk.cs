using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorForDesk : MonoBehaviour
{
    public GameObject[] obj;
    public float SpavnTime = 5f;
    public int kolichestvo = 10;
    
    private IEnumerator Create3dObjects(float wait)
    {
        // таймер
        yield return new WaitForSeconds(wait);
        Create();
    }

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }
    private int RN(int num1, int num2)
    {   // RandomeNamber
        return UnityEngine.Random.Range(num1, num2);
    }

    void Create()
    {
        Instantiate(obj[RN(0,obj.Length)], transform.position, Quaternion.Euler(0f, 0f, 0f));
        StartCoroutine(Create3dObjects(SpavnTime));
    }
}
