using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToLevel(int a)
    {
        SceneManager.LoadScene(a);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Получаем количество сцен в сборке
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        // Проверяем, существует ли следующая сцена
        if (currentSceneIndex + 1 < sceneCount)
        {
            // Загружаем следующую сцену по порядку
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogWarning("There is no next scene in the build settings.");
            GoToLevel(0);
        }
    }

}
