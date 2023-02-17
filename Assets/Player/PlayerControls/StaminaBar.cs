using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    float stamina = 5, maxStamina = 5;
    float walkSpeed, runSpeed;
    CharacterController cm;
    bool isRunning;

    Rect staminaRect;
    Texture2D staminaTexture;

    void Start()
    {
        cm = gameObject.GetComponent<CharacterController>();
        walkSpeed = cm.movement.maxForwardSpeed;
        runSpeed = walkSpeed * 4;

        staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10,
            Screen.width / 3, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.white);
        staminaTexture.Apply();
    }

    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        cm.movement.MaxForwardSpeed = isRunning ? runSpeed : walkSpeed;
       
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            SetRunning(true);
        if (Input.GetKeyUp(KeyCode.LeftShift))
            SetRunning(false);

        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }else if (stamina<maxStamina)
        {
            stamina += Time.deltaTime;
        }      
    }

    void OnGUI()
    {
        float ratio = stamina / maxStamina;
        float rectWidh = ratio*Screen.width / 3;
        staminaRect.width = rectWidh;
        GUI.DrawTexture(staminaRect, staminaTexture);
    }
}
