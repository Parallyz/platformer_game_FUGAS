using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;


    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }

    public void Pause()
    {

        pauseMenu.SetActive(true);

        Time.timeScale = 0;

    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        ScoreManager.instanse.RestartLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
