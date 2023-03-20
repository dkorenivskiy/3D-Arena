using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{
    public GameObject DeadMenuUI;
    public Score GameManagerScore;
    public Text Score;

    public void PauseGame()
    {
        DeadMenuUI.SetActive(true);
        Score.text = "Killed Enemies - " + GameManagerScore.KilledEnemies;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}
