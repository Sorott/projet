using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStat : MonoBehaviour
{

    [SerializeField]
    public float PlayerHP = 100f;
    public GameObject HUD;
    public GameObject inventaire;
    public GameObject deathscreen;
    public GameObject player;
    public AudioSource SonMort;

    public void Start()
    {
        deathscreen.SetActive(false);
        SonMort.Stop();
    }

    public void ApplyDamage(float Damage)
    {
        PlayerHP -= Damage;
        Debug.Log("l'enemie ta fait " + Damage + " de dégats , il te reste " + PlayerHP + " de vie");
    }

    public void Update()
    {
        if ( PlayerHP <= 0)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            HUD.SetActive(false);
            inventaire.SetActive(false);
            deathscreen.SetActive(true);
            SonMort.Play();

        }

        if (PlayerHP > 100)
        {
            PlayerHP = 100;
        }
    }

}