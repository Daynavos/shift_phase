using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject LevelScreen;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void levelSelect()
    {
        startScreen.SetActive(false);
        LevelScreen.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
