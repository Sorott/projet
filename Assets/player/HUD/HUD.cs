using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject flashLightON;
    public GameObject flashLightOFF;
    public GameObject flashLightLight;

    void Start()
    {
        flashLightON.SetActive(false);
        flashLightOFF.SetActive(false);
    }

    void Update()
    {
        if (flashLightLight.activeInHierarchy && !Input.GetButtonDown("F"))
        {
            flashLightON.SetActive(false);
            flashLightOFF.SetActive(true);
        }
        else if (flashLightLight.activeInHierarchy && Input.GetButtonDown("F"))
        {
            flashLightON.SetActive(true);
            flashLightOFF.SetActive(false);
        }
        else if (Input.GetButtonDown("F"))
        {
            flashLightON.SetActive(true);
            flashLightOFF.SetActive(false);
        }
    }
}
