using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowUp : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Vector3 PlP;
    Vector3 Lp;
    // Start is called before the first frame update
    void Start()
    {
        Lp = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlP = Player.GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(PlP[0], Lp[1], PlP[2]);
    }
}
