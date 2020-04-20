using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Function to change Scene to CinematicScene
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    // Function to quit the game
    public void QuitButton()
    {
        Application.Quit();
    }
}
