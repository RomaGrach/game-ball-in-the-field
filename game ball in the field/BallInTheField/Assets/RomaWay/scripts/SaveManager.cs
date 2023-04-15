using UnityEngine;

public static class SaveManager
{
    public static void Save<T>(string key, T saveData)
    {
        string jsonDataString = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(key, jsonDataString);
    }

    public static T Load<T>(string key) where T : new()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string LoadedString = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(LoadedString);
        }
        else
            return new T();
    }
}

