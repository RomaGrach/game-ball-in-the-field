using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatic : MonoBehaviour
{
    [SerializeField] GameObject _nastroykiMenue;

    public void NastroykyAktyve()
    {

        _nastroykiMenue.SetActive( ! _nastroykiMenue.activeSelf);
    }

}
