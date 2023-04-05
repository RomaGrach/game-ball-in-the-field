using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text_money;
    // Start is called before the first frame update
    void Start()
    {
        ApdateMoneyText();
    }

    // Update is called once per frame
    public void SetMoney(int money)
    {
        Progress.Instance.abdateCoin(money);
        ApdateMoneyText();
    }

    public void ApdateMoneyText()
    {
        _text_money.text = Progress.Instance.Coins.ToString();
    }
    
}
