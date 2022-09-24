using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerATK : MonoBehaviour
{
    public Controller controller;

    /* public int atkDamage;

    private void OnEnable()
    {
        atkDamage = controller.atkDamage;
    } */

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitBox_Enemy")
        {
            controller.playerHPSlider.value += controller.heal;
        }
    }
}
