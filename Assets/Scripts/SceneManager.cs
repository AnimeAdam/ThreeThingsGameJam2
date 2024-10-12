using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneManager : MonoBehaviour
{
    public void GoToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    static public void GoToGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    static public void GoToYouWin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
