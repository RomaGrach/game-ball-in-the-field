using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float _time = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        // не основ
        Generator.SetActive(false);
        _time = 0;
    }
    void Start()
    {
        CanvasBeforeAfterGame.SetActive(true);
        playButton.SetActive(true);
        RestartButton.SetActive(false);
        NextButton.SetActive(false);
        //NowSkore.text = "Текущие время: " + _time.ToString();
        //BeastSkore.text = "Лучшие время: " + Progress.Instance.LevelsScore[0].ToString();
        GameSchet();
        GameUslovie.text = "Собери: " + _sobranoNujno.ToString() + " кубов";
        Time.timeScale = 0;

    }
    void FixedUpdate()
    {
        _time += 1 * Time.fixedDeltaTime;
        /*
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
        _GameManager.LoadNextScene();
    }

    public void GameDefeat()
    {
        CanvasBeforeAfterGame.SetActive(true);
        playButton.SetActive(false);
        RestartButton.SetActive(true);
        NextButton.SetActive(false);
        //GameSchet();
        GameUslovie.text = "ПОМЕР";
        Time.timeScale = 0;
    }

    public void GameWin()
    {
        CanvasBeforeAfterGame.SetActive(true);
        playButton.SetActive(false);
        RestartButton.SetActive(false);
        NextButton.SetActive(true);
        //GameSchet();
        GameUslovie.text = "Победа";
        Time.timeScale = 0;
    }
    public void SoberTextFunk()
    {
        _sobrano += 1;
        SoberText.text = "Собрано:  " + _sobrano.ToString() + " / " + _sobranoNujno.ToString();
        if (_sobrano == _sobranoNujno)
        {
            GameSchet();
            Progress.Instance.LevelsProgres[SceneManager.GetActiveScene().buildIndex - 1] = true;
            Progress.Instance.Save_LPS();
            GameWin();
        }
    }
    public void GameSchet()
    {
        NowSkore.text = "Текущие время: " + _time.ToString();                                
        if ((_time < Progress.Instance.LevelsScore[0] || Progress.Instance.LevelsScore[0] == 0)&& _time != 0)
        {
            Progress.Instance.LevelsScore[0] = Mathf.RoundToInt(_time); 
        }
        BeastSkore.text = "Лучшие время: " + Progress.Instance.LevelsScore[0].ToString();

    }
    public void sbrosPlayerPrefs()
    {
        //PlayerPrefs.DeleteAll();
    }
}
