using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Progress : MonoBehaviour
{
    public int Coins;
    public List<List<int>> intList;
    //public List<int> intList1 = new List<int>(intList[0]);
    public int[,] LevelsProgress = new int[1,2] { { 1, 0 } }; // первое пройден/не пройден   второе прогрес
    public Material materialNow;
    public List<Material> materialsListBuyed;
    public int[] myArray11 = new int[] { 1, 2, 3, 4, 5 };

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

        if (PlayerPrefs.HasKey("myArray"))
        {
            string json = PlayerPrefs.GetString("myArray");

            // десериализуем строку JSON в массив
            myArray11 = JsonUtility.FromJson<int[]>(json);

            Debug.Log("1");
        }
        else
        {
            // сериализуем массив в строку JSON
            string json = JsonUtility.ToJson(myArray11, true);

            // сохраняем строку в PlayerPrefs
            PlayerPrefs.SetString("myArray", json);
        }

        if (PlayerPrefs.HasKey("score"))
        {
            Coins = PlayerPrefs.GetInt("score");
        }
        else
        {
            PlayerPrefs.SetInt("score", Coins);
        }

        if (PlayerPrefs.HasKey("IntList"))
        {
            string savedJson = PlayerPrefs.GetString("IntList");
            IntListWrapper savedWrapper = JsonUtility.FromJson<IntListWrapper>(savedJson);
            if (savedWrapper.items != null)
            {
                intList = savedWrapper.items;
            }
            Debug.Log("1");
        }
        else
        {
            // Преобразование списка в JSON и сохранение в PlayerPrefs
            string jsonString = JsonUtility.ToJson(new IntListWrapper { items = intList });
            PlayerPrefs.SetString("IntList", jsonString);
            Debug.Log("2");
        }
        if (intList == null)
        {

            intList = new List<List<int>> { new List<int> { 0, 0 } };
        }
        //intList = new List<List<int>> { new List<int> { 2, 1 } };
        Debug.Log("intList: " + string.Join(", ", intList.Select(l => "[" + string.Join(", ", l) + "]").ToArray()));
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
    public void SavedMyArrey()
    {
        // сериализуем массив в строку JSON
        string json = JsonUtility.ToJson(myArray11, true);

        // сохраняем строку в PlayerPrefs
        PlayerPrefs.SetString("myArray", json);
        Debug.Log("1rgtgt");
        PrintSavedMyArrey();
    }

    public void PrintSavedMyArrey()
    {
        string json = PlayerPrefs.GetString("myArray");

        // десериализуем строку JSON в массив
        myArray11 = JsonUtility.FromJson<int[]>(json);

        for (int i = 0; i < myArray11.Length; i++)
        {
            Debug.Log(myArray11[i]);
        }
    }


    public void SavedLavels()
    {
        // Если список intList пустой, то создаем в нем хотя бы один элемент для сохранения
        if (intList.Count == 0)
        {
            intList.Add(new List<int> { 0, 0 });
        }

        // Преобразование списка в JSON и сохранение в PlayerPrefs
        string jsonString = JsonUtility.ToJson(new IntListWrapper { items = intList });
        PlayerPrefs.SetString("IntList", jsonString);
        PlayerPrefs.Save(); // сохраняем изменения
        Debug.Log("intList: " + string.Join(", ", intList.Select(l => "[" + string.Join(", ", l) + "]").ToArray()));
        PrintSavedLavels();
    }

    public void PrintSavedLavels()
    {
        Debug.Log("fff");
        string savedJson = PlayerPrefs.GetString("IntList");
        IntListWrapper savedWrapper = JsonUtility.FromJson<IntListWrapper>(savedJson);
        if (savedWrapper.items != null)
        {
            intList = savedWrapper.items;
            Debug.Log("intList: " + string.Join(", ", intList.Select(l => "[" + string.Join(", ", l) + "]").ToArray()));
        }
        else
        {
            Debug.Log("yyyy");
        }
    }

    public void abdateCoin(int number)
    {
        Coins += number;
        PlayerPrefs.SetInt("score", Coins);
    }

    [Serializable]
    public class IntListWrapper
    {
        public List<List<int>> items;
    }

}
