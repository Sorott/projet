using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiMenu : MonoBehaviour
{
    public void BouttonNewMultiGame()
    {
        Debug.Log("New Multi Game");
    }

    public void BouttonJoinGame()
    {
        Debug.Log("Join Multi Game");
    }

    public void BouttonReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
