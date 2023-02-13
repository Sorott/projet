using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventaire;
    public static bool isOn;
    public PlayerCam camlpayer;
    private float Sens_x_default;
    private float Sens_y_default;

    public void Start()
    {
        inventaire.SetActive(false);
        Sens_x_default = camlpayer.sensX;
        Sens_y_default = camlpayer.sensY;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOn)
            {
                Resume();
                camlpayer.sensX = Sens_x_default;
                camlpayer.sensY = Sens_y_default;
                
            }
            else
            {
                Pause();
                camlpayer.sensX = 0;
                camlpayer.sensY = 0;
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
