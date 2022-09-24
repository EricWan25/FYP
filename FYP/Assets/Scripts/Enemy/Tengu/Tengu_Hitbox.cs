using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tengu_Hitbox : MonoBehaviour
{
    public Controller controller;
    public Tengu tengu;

    public int takeDamage;

    private void Update()
    {
        takeDamage = controller.atkDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Col_PlayerATK")
        {
            tengu.tenguHP.value -= takeDamage;
        }
    }
}
