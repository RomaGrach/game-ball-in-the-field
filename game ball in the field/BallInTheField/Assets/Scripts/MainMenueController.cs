using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
 
public class MainMenueController : MonoBehaviour
{
    public TextMeshProUGUI sccoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("score")){
            int s = PlayerPrefs.GetInt("score");
            sccoreText.text = "Лучший счёт: " + s;
            }
        
    }

    public void scenGo(){
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }
    public void resetScore(){
        if (PlayerPrefs.HasKey("score")){
            PlayerPrefs.SetInt("score", 0);
            sccoreText.text = "Лучший счёт: " + 0;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
