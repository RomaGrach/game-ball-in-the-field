using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Progress;


[System.Serializable]
public class level
{
    [SerializeField]
    public bool passed { get; set; }

    [SerializeField]
    public int score { get; set; }
}
/*
public class level
{
    public bool passed { get; set; }
    public int score { get; set; }
}
*/
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}


public class SawingTest : MonoBehaviour
{

    level[] levels = new level[2];

    // Start is called before the first frame update
    void Start()
    {
        levels[0] = new level();
        levels[0].passed = false;
        levels[0].score = 0;
        levels[1] = new level();
        levels[1].passed = true;
        levels[1].score = 110;

        //Convert to JSON
        //string levelsToJson = JsonHelper.ToJson(levels, true);
        string levelsToJson = JsonHelper.ToJson<level>(levels, true);
        Debug.Log(levels[1].score);
        Debug.Log(levelsToJson);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
