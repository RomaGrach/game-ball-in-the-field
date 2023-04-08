using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenueUIController : MonoBehaviour
{
    [SerializeField] GameObject _StartMenue;
    [SerializeField] GameObject _LevelsMenue;
    [SerializeField] GameObject _StaticConvas;
    // Start is called before the first frame update
    public void LevelsButton()
    {
        _StartMenue.SetActive(false);
        _StaticConvas.SetActive(false);
        _LevelsMenue.SetActive(true);
    }
    public void HomeButton()
    {
        _StartMenue.SetActive(true);
        _StaticConvas.SetActive(true);
        _LevelsMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
