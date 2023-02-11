using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPause;

    public void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if (isPause)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        isPause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        isPause = false;
    }

    public void BouttonOptions()
    {
        SceneManager.LoadScene("Options Menu");
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
