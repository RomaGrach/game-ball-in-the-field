using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class saver : MonoBehaviour
{
    public int[] abs;
    public int[,] abs2;
    public List<List<int>> intList;
    // Start is called before the first frame update

    private const string saveKey = "mainSave";
    public void InputFieldCange()
    {
        Save();
    }
    void Start()
    {
        Load();
    }

    public void Load()
    {
        var data = SaveManager.Load<SaveData.ForSaving>(saveKey);
        abs = data.listabs;
        intList = data.intListSave;
        abs2 = data.listabs2;
        for (int i = 0; i < abs.Length; i++)
        {
            Debug.Log(abs[i]);
        }
        Debug.Log("intList: " + string.Join(", ", intList.Select(l => "[" + string.Join(", ", l) + "]").ToArray()));
        Debug.Log(string.Join(", ", abs2.Cast<int>()));
    }

    public void Save()
    {
        SaveManager.Save(saveKey, GateSaveSnapshot());
        for (int i = 0; i < abs.Length; i++)
        {
            Debug.Log(abs[i]);
        }
        Debug.Log("intList: " + string.Join(", ", intList.Select(l => "[" + string.Join(", ", l) + "]").ToArray()));
        Debug.Log(string.Join(", ", abs2.Cast<int>()));
    }

    public void Change1()
    {
        intList[0][0] = intList[0][0] + 1;
        Debug.Log("intList: " + string.Join(", ", intList.Select(l => "[" + string.Join(", ", l) + "]").ToArray()));
    }

    public void Change2()
    {
        abs2[0, 0] += 1;
        Debug.Log(string.Join(", ", abs2.Cast<int>()));
    }



    private SaveData.ForSaving GateSaveSnapshot()
    {
        var data = new SaveData.ForSaving()
        {
            listabs = abs,
            intListSave = intList,
        };
        return data;
    }
}
