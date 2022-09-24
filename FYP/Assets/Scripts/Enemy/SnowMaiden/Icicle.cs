using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icicle : MonoBehaviour
{
    public Controller controller;
    public Slider icicleHP;
    public SnowMaiden snowMaiden;

    public float rotateSpeed = 1.5f;

    public int takeDamage;

    void Update()
    {
        takeDamage = controller.atkDamage;

        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Col_PlayerATK")
        {
            icicleHP.value -= takeDamage;

            if (icicleHP.value <= 0)
            {
                controller.thisLvlEnemyHP.value -= 1;
                snowMaiden.icicleCount += 1;
                Destroy(gameObject);
            }
        }
    }
}
