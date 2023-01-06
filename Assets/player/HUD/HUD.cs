using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject flashLightON;
    public GameObject flashLightOFF;
    public GameObject flashLightInv;
    public GameObject flashLightLight;

    public bool UILightOn;
    public bool UILightOff;

    void Start()
    {
        flashLightON.SetActive(false);
        flashLightOFF.SetActive(false);
    }

    void Update()
    {
        if (flashLightInv.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            flashLightON.SetActive(false);
            flashLightOFF.SetActive(true);
        }
        else if (flashLightInv.activeInHierarchy && flashLightLight.activeInHierarchy)
        {
            flashLightON.SetActive(true);
            flashLightOFF.SetActive(false);
        }
        else if (flashLightInv.activeInHierarchy && !flashLightLight.activeInHierarchy)
        {
            flashLightON.SetActive(false);
            flashLightOFF.SetActive(true);
        }
    }
}
