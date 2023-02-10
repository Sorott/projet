using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("RealMap");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options Menu Main");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Le jeu devrait etre ferm� mais sa marche pas ta capt� pck on est sur Unity fr�ro");
    }

    public void QuitterGame()
    {
        Application.Quit();
    }
}