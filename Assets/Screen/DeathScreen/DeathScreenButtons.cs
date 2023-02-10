using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    public void ReStartGame()
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
    }
}
