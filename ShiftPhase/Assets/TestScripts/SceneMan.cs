using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void levelSelect()
    {
        LoadScene("level_select");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
