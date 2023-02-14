using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventaire;
    public static bool isOn;
    public PlayerCam camplayer;
    private float Sens_x_default;
    private float Sens_y_default;

    public void Start()
    {
        inventaire.SetActive(false);
        Sens_x_default = camplayer.sensX;
        Sens_y_default = camplayer.sensY;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOn)
            {
                Resume();
                camplayer.sensX = Sens_x_default;
                camplayer.sensY = Sens_y_default;
                
            }
            else
            {
                Pause();
                camplayer.sensX = 0;
                camplayer.sensY = 0;
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
