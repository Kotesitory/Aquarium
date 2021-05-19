using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUi;

    void Update() {
        if (Input.GetKeyDown("escape") && !GameOverMenu.gameOver)
        {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void Resume() {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause() {
        pauseMenuUi.SetActive(true);
        pauseMenuUi.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        pauseMenuUi.transform.forward = Camera.main.transform.forward;
        Time.timeScale = 0f;
        isPaused = true;
    }
}
