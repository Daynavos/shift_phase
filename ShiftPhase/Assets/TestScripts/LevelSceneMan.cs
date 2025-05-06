using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSceneMan : MonoBehaviour
{
    public GameObject pauseMenu;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void pauseScreen()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void levelSelect()
    {
        LoadScene("level_select");
    }
    
    
    public void LoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            Debug.Log("No more levels!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        LoadScene("level_1");
    }
    
}
