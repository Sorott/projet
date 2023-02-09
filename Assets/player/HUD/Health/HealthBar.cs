using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthbar;
    public float health;
    private float maxhealth = 100f;
    playerStat player;

    void Start()
    {
        healthbar = GetComponent<Image>();
        player = FindObjectOfType<playerStat>();
    }

    void Update()
    {
        
    }
}
