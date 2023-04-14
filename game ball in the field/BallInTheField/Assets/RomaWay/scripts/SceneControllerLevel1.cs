using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneControllerLevel1 : MonoBehaviour
{
    [SerializeField] GameObject CanvasBeforeAfterGame;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject RestartButton;
    [SerializeField] GameObject NextButton;
    [SerializeField] GameObject Generator;
    [SerializeField] TextMeshProUGUI NowSkore;
    [SerializeField] TextMeshProUGUI BeastSkore;
    [SerializeField] TextMeshProUGUI GameUslovie;
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] TextMeshProUGUI SoberText;
    public GameManager _GameManager;
    public int _sobrano = 0;
    public int _sobranoNujno;
    public float _time = 30.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        // не основ
        Generator.SetActive(false);
    }
    void Start()
    {
        CanvasBeforeAfterGame.SetActive(true);
        playButton.SetActive(true);
        RestartButton.SetActive(false);
        NextButton.SetActive(false);
        NowSkore.text = "Текущий счет: " + _sobrano.ToString();
        BeastSkore.text = "Лучший счет: " + Progress.Instance.intList[0][0].ToString();
        GameUslovie.text = "Собери: 15 кубов";
        Time.timeScale = 0;

    }
    void FixedUpdate()
    {  /*
        if (_time > 0f && ! CanvasBeforeAfterGame.activeSelf)
        {
            _time = _time - Time.fixedDeltaTime;
            int a = (int)_time;
            TimeText.text = "Время: " + a;
        }
        */

    }
    // Update is called once per frame
    public void StartButton()
    {
        CanvasBeforeAfterGame.SetActive(false);
        Time.timeScale = 1;
        // не основ
        Generator.SetActive(true);
    }

    public void RestartButtonFunk()
    {
        _GameManager.GoToLevel(1);
    }

    public void NextButtonFunk()
    {
        _GameManager.GoToLevel(0);
    }

    public void GameDefeat()
    {
        CanvasBeforeAfterGame.SetActive(true);
        playButton.SetActive(false);
        RestartButton.SetActive(true);
        NextButton.SetActive(false);
        NowSkore.text = "Текущий счет: " + _sobrano.ToString();
        if (_sobrano > Progress.Instance.intList[0][1])
        {
            Progress.Instance.intList[0][1] = _sobrano;
        }
        BeastSkore.text = "Лучший счет: " + Progress.Instance.intList[0][0].ToString();
        GameUslovie.text = "ПОМЕР";
        Time.timeScale = 0;
    }

    public void GameWin()
    {
        CanvasBeforeAfterGame.SetActive(true);
        playButton.SetActive(false);
        RestartButton.SetActive(false);
        NextButton.SetActive(true);
        NowSkore.text = "Текущий счет: " + _sobrano.ToString();
        if (_sobrano > Progress.Instance.intList[0][1])
        {
            Progress.Instance.intList[0][1] = _sobrano;
        }
        BeastSkore.text = "Лучший счет: " + Progress.Instance.intList[0][1].ToString();
        GameUslovie.text = "Победа";
        Time.timeScale = 0;
    }
    public void SoberTextFunk()
    {
        _sobrano += 1;
        SoberText.text = "Собрано:  " + _sobrano.ToString() + " / " + _sobranoNujno.ToString();
        if (_sobrano == _sobranoNujno)
        {
            Progress.Instance.intList[0][1] = _sobrano;
            Progress.Instance.SavedLavels();
            GameWin();
        }
    }
}
