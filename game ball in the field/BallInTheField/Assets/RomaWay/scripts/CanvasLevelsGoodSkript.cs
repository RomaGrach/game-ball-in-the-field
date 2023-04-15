using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLevelsGoodSkript : MonoBehaviour
{
    [SerializeField] GameObject Level2im;
    [SerializeField] GameObject Level3im;
    [SerializeField] GameObject Level4im;
    [SerializeField] GameObject Level5im;
    [SerializeField] GameObject Level6im;
    public Button Level2;
    public Button Level3;
    public Button Level4;
    public Button Level5;
    public Button Level6;
    int s = 2;
    public GameManager _GameManager;
    // Start is called before the first frame update
    void Start()
    {
        if (Progress.Instance.LevelsProgres[0])
        {
            Level2.interactable = true;
            Level2im.SetActive(false);
        }
        if (Progress.Instance.LevelsProgres[1])
        {
            Level3.interactable = true;
            Level3im.SetActive(false);
        }
        if (Progress.Instance.LevelsProgres[2])
        {
            Level4.interactable = true;
            Level4im.SetActive(false);
        }
        if (Progress.Instance.LevelsProgres[3])
        {
            Level5.interactable = true;
            Level5im.SetActive(false);
        }
        if (Progress.Instance.LevelsProgres[4])
        {
            Level6.interactable = true;
            Level6im.SetActive(false);
        }

    }

    // Update is called once per frame
    public void level1()
    {
        _GameManager.GoToLevel(1);
    }
}
