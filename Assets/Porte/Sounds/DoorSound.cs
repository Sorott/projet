using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public GameObject porte;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;

    void Start()
    {
        off = true;
        porte.SetActive(false);
    }

    void Update()
    {
        if(off && Input.GetButtonDown("F"))
        {
            porte.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("E"))
        {
            porte.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }



    }
}
