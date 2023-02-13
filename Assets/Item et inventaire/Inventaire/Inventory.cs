using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventaire;
    public static bool isOn;

    public void Start()
    {
        inventaire.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOn)
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
        inventaire.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        
        isOn = true;
    }

    public void Resume()
    {
        inventaire.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isOn = false;
    }
}
