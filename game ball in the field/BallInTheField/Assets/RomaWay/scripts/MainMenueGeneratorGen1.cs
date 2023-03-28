using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenueGeneratorGen1 : MonoBehaviour
{
    public GameObject obj;
    //private float _time = 30.0f;
    public float SpavnTime = 5f;
    public int kolichestvo = 10;


    private int RN(int num1, int num2)
    {   // RandomeNamber
        return UnityEngine.Random.Range(num1, num2);
    }

    private void FixedUpdate()
    {

    }

    void Create()
    {
        for (int i = 0; i < kolichestvo; i++)
        {
            Instantiate(obj, new Vector3(RN(-500, 500), RN(-300, 300), RN(300, 700)), Quaternion.Euler(RN(-5, 5), RN(0, 360), RN(-5, 5)));
        }
        StartCoroutine(Create3dObjects(SpavnTime));
    }

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
}
