using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isPaused = false;
    public Button pauseButton;
    public Sprite pause, play;
    
    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseButton.image.sprite = pause;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseButton.image.sprite = play;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
