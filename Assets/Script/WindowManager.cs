using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{

    public GameObject gameOverWindow;

    public void GameOverScreen()
    {
        gameOverWindow.SetActive(true);
        gameOverWindow.transform.LeanMoveLocalY(0, 1f).setEaseOutQuart();
    }

    public void StartOverButton()
    {
        gameOverWindow.LeanDelayedCall(0.8f, StartOver);
        gameOverWindow.LeanScale(new Vector3(0, 0, 0), 0.8f);
    }
    public void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
