using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // load the first screen
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUiiiitttt");
    }
}
