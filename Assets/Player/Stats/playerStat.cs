using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStat : MonoBehaviour
{

    [SerializeField]
    public float PlayerHP = 100f;
    public GameObject HUD;
    public GameObject player;


    public void ApplyDamage(float Damage)
    {
        PlayerHP -= Damage;
        Debug.Log("l'enemie ta fait " + Damage + " de dégats , il te reste " + PlayerHP + " de vie");
    }

    public void Update()
    {
        if (PlayerHP <= 0)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Death Menu");
        }

        if (PlayerHP > 100)
        {
            PlayerHP = 100;
        }
    }

}