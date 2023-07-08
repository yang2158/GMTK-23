using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{

    public GameObject gameOverWindow;
    public GameObject UI;

    public bool gameOver = false;
    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    public void GameOverScreen()
    {
        gameOverWindow.SetActive(true);
        gameOver = true;
        UI.SetActive(false);
    }

}
