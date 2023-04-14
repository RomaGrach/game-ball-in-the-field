using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGeneratorLevel1 : MonoBehaviour
{
    public float SpavnTime = 5f;
    public GameObject obj;
    private int RN()
    {   // RandomeNamber
        return UnityEngine.Random.Range(-8, 8);
    }
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create()
    {
        //Instantiate(obj, new Vector3(0, 5, 0), Quaternion.Euler(12f,-15f,40f));
        //GameObject newGameobject = Instantiate(obj, new Vector3(0, 5, 0), Quaternion.Euler(12f,-15f,40f)) as GameObject;
        //newGameobject.GetComponent<Transform>().Translate(new Vector3(5, 5, 0));
        for (int i = 0; i < 5; i++)
        {
            Instantiate(obj, new Vector3(RN(), 1f, RN()), Quaternion.Euler(0f, 0f, 0f));
        }
        StartCoroutine(Create3dObjects(SpavnTime));
    }
    private IEnumerator Create3dObjects(float wait)
    {
        // таймер
        yield return new WaitForSeconds(wait);
        Create();
    }
}
