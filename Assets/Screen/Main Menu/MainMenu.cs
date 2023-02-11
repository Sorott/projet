using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BouttonSolo()
    {
        SceneManager.LoadScene("Solo Menu");
    }

    public void BouttonMulti()
    {
        SceneManager.LoadScene("Multi Menu");
    }

    public void BouttonOptions()
    {
        SceneManager.LoadScene("Options Menu");
    }
    public void BouttonSkin()
    {
        SceneManager.LoadScene("Skin Menu");
    }
    public void BouttonCredits()
    {
        SceneManager.LoadScene("Credits Menu");
    }

    public void BouttonQuitter()
    {
        Application.Quit();
        Debug.Log("Le jeu devrait etre ferm� mais sa marche pas ta capt� pck on est sur Unity fr�ro");
    }
}