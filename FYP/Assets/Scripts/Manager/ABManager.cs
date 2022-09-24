using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABManager : MonoBehaviour
{
    public Controller controller;

    public Image ab_Image;
    public Sprite[] ab_Sprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ab_Image.sprite = ab_Sprite[0];

            controller.atkDamage = 20;
            controller.playerSpeed = 3.5f;
            controller.heal = 0;
            controller.playerDef = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ab_Image.sprite = ab_Sprite[1];

            controller.atkDamage = 20;
            controller.playerSpeed = 2.5f;
            controller.heal = 10;
            controller.playerDef = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ab_Image.sprite = ab_Sprite[2];

            controller.atkDamage = 40;
            controller.playerSpeed = 2.5f;
            controller.heal = 0;
            controller.playerDef = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ab_Image.sprite = ab_Sprite[3];

            controller.atkDamage = 20;
            controller.playerSpeed = 2.5f;
            controller.heal = 0;
            controller.playerDef = 10;
        }
    }
}
