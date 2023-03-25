using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorJampBollsForStartMenue : MonoBehaviour
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
            obj.GetComponent<Rigidbody>().mass = RN(1, 6);
            obj.GetComponent<Rigidbody>().drag = RN(0, 1);
            Instantiate(obj, new Vector3(RN(-10, 10), 16f + RN(-1, 3), RN(-9, 9)), Quaternion.Euler(0f, 0f, 0f));
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
