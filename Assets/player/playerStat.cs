using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStat : MonoBehaviour
{

    [SerializeField]
    public float PlayerHP = 100f;


    public void ApplyDamage(float Damage)
    {
        PlayerHP -= Damage;
    }

}
