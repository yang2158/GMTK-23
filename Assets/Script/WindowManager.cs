using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class WindowManager : MonoBehaviour
{

    public GameObject gameOverWindow;
    public GameObject UI;
    public TextMeshProUGUI stats;
    public TextMeshProUGUI wave;

    public bool gameOver = false;
    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {

            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game 1");
    }

    public void GameOverScreen()
    {
        System.TimeSpan theTime = System.DateTime.Now.Subtract(PlayerController.instance.startTime);
        stats.text = "Money Earned : " + PlayerController.instance.earned + "<br>" +
            "TimeSpent : " + theTime.Minutes + "M" + theTime.Seconds + "S<br>" +
            "Killed : " + PlayerController.instance.emyKilled + "<br>";
            ;
        Time.timeScale = 0;
        gameOverWindow.SetActive(true);
        gameOver = true;
        UI.SetActive(false);
    }

}
