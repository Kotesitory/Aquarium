using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    static public bool gameOver = false;
    public GameObject gameOverPanelUi;

    public void GameOver() {
        gameOverPanelUi.SetActive(true);
        gameOverPanelUi.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        gameOverPanelUi.transform.forward = Camera.main.transform.forward;
        Time.timeScale = 0f;
        gameOver = true;
    }

    public void GoToMainMenu() {
        gameOver = false;
        Time.timeScale = 1f;
        gameOverPanelUi.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void QuieGame() {
        Application.Quit();
    }

    public void RestartGame() {
        gameOver = false;
        Time.timeScale = 1f;
        gameOverPanelUi.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
