using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatic : MonoBehaviour
{
    [SerializeField] GameObject _nastroykiMenue;
    [SerializeField] TextMeshProUGUI _text_ControlTipeButton;
    [SerializeField] PlayerUIController _playerUIController;

    public void NastroykyAktyve()
    {
        _nastroykiMenue.SetActive( ! _nastroykiMenue.activeSelf);
    }
    public void ControlTipeChange()
    {
        if (_playerUIController)
        {
            if (_text_ControlTipeButton.text == "Control Type - PC")
            {
                _playerUIController.SetActiveJostic(true);
                _text_ControlTipeButton.text = "Control Type - Android";

            }
            else
            {
                _playerUIController.SetActiveJostic(false);
                _text_ControlTipeButton.text = "Control Type - PC";

            }
        }
    }

}
