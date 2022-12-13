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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
