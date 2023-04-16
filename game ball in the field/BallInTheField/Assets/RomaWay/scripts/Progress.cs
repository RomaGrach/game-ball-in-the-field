using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[System.Serializable]
public class LevelsProgresSever
{
    [SerializeField] public bool[] LevelsProgres;
    [SerializeField] public int[] LevelsScore;
    public LevelsProgresSever()
    {
        LevelsProgres = new bool[] { false, false, false, false, false };
        LevelsScore = new int[] { 0, 0, 0, 0, 0 };
    }
}

public class Progress : MonoBehaviour
{

    public int Coins;
    public int SkinIndeks = 0;
    //public Material materialNow;
    [SerializeField] public LevelsProgresSever _LPS;
    public bool[] LevelsProgres = new bool[] { false, false, false, false, false };
    public int[] LevelsScore = new int[] { 0, 0, 0, 0, 0 };
    public List<Material> materialsListBuyed;

    public static Progress Instance;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
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

        if (PlayerPrefs.HasKey("skin"))
        {
            SkinIndeks = PlayerPrefs.GetInt("skin");
        }
        else
        {
            PlayerPrefs.SetInt("skin", SkinIndeks);
        }

        if (PlayerPrefs.HasKey("LPS"))
        {
            /*
            string LoadedString = PlayerPrefs.GetString("LevelsScore");
            Debug.Log(LoadedString);
            Debug.Log("2");
            LevelsScore = JsonUtility.FromJson<int[]>(LoadedString);
            JsonUtility.FromJson<T>(LoadedString);
            Debug.Log(string.Join(",", LevelsScore));
            */

            string LoadedString = PlayerPrefs.GetString("LPS");
            var data = JsonUtility.FromJson<LevelsProgresSever>(LoadedString);
            LevelsScore = data.LevelsScore;
            LevelsProgres = data.LevelsProgres;
        }
        else
        {
            Save_LPS();
        }


    }
    /*
    public void Save_LevelsProgres()
    {
        _LPS.LevelsProgres = LevelsProgres;
        string jsonDataString = JsonUtility.ToJson(_LPS, true);
        PlayerPrefs.SetString("LevelsProgres", jsonDataString);
    }
    */
    public void Save_LPS()
    {
        _LPS.LevelsScore = LevelsScore;
        _LPS.LevelsProgres = LevelsProgres;
        string jsonDataString = JsonUtility.ToJson(_LPS, true);
        Debug.Log(jsonDataString + "-----");
        PlayerPrefs.SetString("LPS", jsonDataString);
    }

    /*
    public void Save_LevelsScore()
    {

        _LPS.LevelsScore = LevelsScore;
        Debug.Log(string.Join(",", _LPS.LevelsScore));
        string jsonDataString = JsonUtility.ToJson(_LPS, true);
        Debug.Log(jsonDataString+"-----");
        PlayerPrefs.SetString("LevelsScore", jsonDataString);
        //SaveManager.Save("LevelsScore", _MyStruct);
        //var data = SaveManager.Load<MyStruct>("LevelsScore");
        //Debug.Log("-----");
        //Debug.Log(string.Join(",", data.LevelsScore));
    }
    */
    public void abdateCoin(int number)
    {
        Coins += number;
        PlayerPrefs.SetInt("score", Coins);
    }
    public void ChangeSkinIndeks()
    {
        PlayerPrefs.SetInt("skin", SkinIndeks);
    }
    /*
    public void SavedLavels()
    {
        // Преобразование списка в JSON и сохранение в PlayerPrefs
        string jsonString = JsonUtility.ToJson(new IntListWrapper { items = intList });
        PlayerPrefs.SetString("IntList", jsonString);
        Debug.Log("intList: " + string.Join(", ", intList.Select(l => "[" + string.Join(", ", l) + "]").ToArray()));
        PrintSavedLavels();
    }
    */
}
