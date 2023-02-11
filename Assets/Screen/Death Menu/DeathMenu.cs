using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void BouttonRestart()
    {
        SceneManager.LoadScene("RealMap");
    }

    public void BouttonReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void BouttonQuitter()
    {
        Application.Quit();
        Debug.Log("Le jeu devrait etre fermé mais sa marche pas ta capté pck on est sur Unity fréro");
    }
}
