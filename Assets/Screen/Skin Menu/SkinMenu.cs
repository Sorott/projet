using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinMenu : MonoBehaviour
{
    public void BouttonReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
