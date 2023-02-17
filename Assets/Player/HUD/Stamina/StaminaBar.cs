using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    Rect staminaRect;
    Texture2D staminaTexture;

    PlayerMovement PM;

    void Start()
    {
        PM.GetComponent<PlayerMovement>();

        staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10,
        Screen.width / 3, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.white, 50);
        staminaTexture.Apply();
    }

    void OnGUI()
    {
        float ratio = PM.stamina / PM.maxStamina;
        float rectWidh = ratio * Screen.width / 3;
        staminaRect.width = rectWidh;
        GUI.DrawTexture(staminaRect, staminaTexture);
    }

}