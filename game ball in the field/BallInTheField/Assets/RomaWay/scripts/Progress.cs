using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public int Coins;
    public int[] LevelsProgress;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("score"))
        {
            Coins = PlayerPrefs.GetInt("score");
        }
        else
        {
            PlayerPrefs.SetInt("score", Coins);
        }

    }
    public void abdateCoin(int number)
    {
        Coins += number;
        PlayerPrefs.SetInt("score", Coins);
    }
    
}
