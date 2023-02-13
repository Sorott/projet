using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public GameObject m_light;
    public bool isON;

    public void Start()
    {
        m_light.SetActive(false);
        isON = false;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isON == false)
            {
                m_light.SetActive(true);
                isON = true;
            }

            else if (isON == true)
            {
                m_light.SetActive(false);
                isON = false;
            }
        }
    }
}
