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
}
