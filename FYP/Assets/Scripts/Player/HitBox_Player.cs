using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Player : MonoBehaviour
{
    public Controller controller;

    public Animator hurtAnim;

    private int damageToTake;

    private void Start()
    {
        damageToTake = controller.thisLvlEnemyDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Col_EnemyAtk")
        {
            if (gameObject.tag == "HitBox_Player")
            {
                controller.playerHPSlider.value -= (damageToTake - controller.playerDef);
                hurtAnim.Play("Hurt");
            }
        }
    }
}
