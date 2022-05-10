using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //references
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    //called once per frame
    void Update()
    {
        //if esc key pressed, check if game is already paused
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else Pause();
        }
    }

    //turns off menu UI, turns time back on, and sets GameIsPaused to false
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //turns on menu UI, turns time off, and sets GameIsPaused to true
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //for loading into the main menu (for an actual build)
    public void LoadMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    //quits game (for an actual build)
    public void QuitGame()
    {
        Application.Quit();
    }
}
