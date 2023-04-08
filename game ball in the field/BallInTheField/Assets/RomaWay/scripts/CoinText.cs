using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text_money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _text_money.text = Progress.Instance.Coins.ToString();
    }
}
