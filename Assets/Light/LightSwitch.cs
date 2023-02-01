using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject onOB;
    public GameObject offOB;

    public GameObject lightsText;

    public GameObject lightOB1;
    public GameObject lightOB1;

    public AudioSource lightclick;

    public bool lightAreOn;
    public bool lightAreOff;
    public bool inReach;

    void Start()
    {
        inReach = false;
        lightAreOn = false;
        lightAreOff = true;
        onOB.SetActive(false);
        offOB.SetActive(true);
        lightOB1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            lightsText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            lightsText.SetActive(false);
        }
    }

    void Update()
    {
        if(lightAreOn && inReach && Input.GetButtonDown("Interact"))
        {
            lightOB1.SetActive(false);
            onOB.SetActive(false);
            offOB.SetActive(true);
            lightclick.Play();
            lightAreOff = true;
            lightAreOn = false;


        }
        else if (lightAreOff && inReach && Input.GetButtonDown("Interact"))
        {
            lightOB1.SetActive(true);
            onOB.SetActive(true);
            offOB.SetActive(false);
            lightclick.Play();
            lightAreOff = false;
            lightAreOn = true;

        }
    }
}
