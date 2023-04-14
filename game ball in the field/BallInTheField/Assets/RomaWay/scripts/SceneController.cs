using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject CanvasMagazin;
    [SerializeField] GameObject CanvasLevelsGood;
    [SerializeField] GameObject CanvasStartMenueTest;
    [SerializeField] GameObject Magazin;

    // Start is called before the first frame update
    void Start()
    {
        StartMenueActive();
    }

    // Update is called once per frame
    public void StartMenueActive()
    {
        allDisactive();
        CanvasStartMenueTest.SetActive(true);
    }

    public void CanvasMagazinActive()
    {
        allDisactive();
        CanvasMagazin.SetActive(true);
        Magazin.SetActive(true);
    }

    public void CanvasLevelsGoodActive()
    {
        allDisactive();
        CanvasLevelsGood.SetActive(true);
    }

    public void allDisactive()
    {
        CanvasMagazin.SetActive(false);
        CanvasLevelsGood.SetActive(false);
        CanvasStartMenueTest.SetActive(false);
        Magazin.SetActive(false);
    }
}
