using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloMenu : MonoBehaviour
{
    public void BouttonContinu()
    {
        SceneManager.LoadScene("RealMap");
    }

    public void BouttonNewSoloGame()
    {
        SceneManager.LoadScene("RealMap");
    }

    public void BouttonReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}