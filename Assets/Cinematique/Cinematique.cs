using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematique : MonoBehaviour
{
    public void SignaleEnd()
    {
        SceneManager.LoadScene("RealMap");
    }
}