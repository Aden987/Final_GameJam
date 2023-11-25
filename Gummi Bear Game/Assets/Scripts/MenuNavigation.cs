using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public void PauseBtn()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeBtn()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PuzzleLevelOne()
    {
        SceneManager.LoadScene("PuzzleLevel1");
    }

    public void PuzzleLevelTwo()
    {
        SceneManager.LoadScene("PuzzleLevel2");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
