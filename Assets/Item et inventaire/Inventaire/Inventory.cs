using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventaire;
    public static bool isOn;
    public PlayerCam camera;
    private float Sens_x_default;
    private float Sens_y_default;

    public void Start()
    {
        inventaire.SetActive(false);
        Sens_x_default = camera.sensX;
        Sens_y_default = camera.sensY;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOn)
            {
                Resume();
                camera.sensX = Sens_x_default;
                camera.sensY = Sens_y_default;
                
            }
            else
            {
                Pause();
                camera.sensX = 0;
                camera.sensY = 0;
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
