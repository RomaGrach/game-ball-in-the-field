using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsR : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI _text;
    [SerializeField] private GameObject _buttenGiroscop;
    public PlayerMoveForse _playerMove;
    bool girascop = false;
    [SerializeField] private TextMeshProUGUI _text_aksilirometr_settings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiroscopEneble()
    {
        if (_buttenGiroscop.activeInHierarchy)
        {
            _buttenGiroscop.SetActive(false);
            //_playerMove.change_game_mode_acceleration(false);
        }
        else
        {
            _buttenGiroscop.SetActive(true);
            //_playerMove.change_game_mode_acceleration(true);
        }
    }
    public void Akselirometr()
    {
        if (girascop)
        {
            girascop = false;
            _playerMove.change_game_mode_acceleration(girascop);
            _text_aksilirometr_settings.text = " Аксилирометр - Выключен.";
        }
        else
        {
            girascop = true;
            _playerMove.change_game_mode_acceleration(girascop);
            _text_aksilirometr_settings.text = " Аксилирометр - Включен.";
        }
    }
}
