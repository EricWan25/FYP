using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
    public Controller controller;

    public SoundManager soundManager;

    Animator playerAnim;

    bool comboPossible;
    public int comboStep;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void NextAtk()
    {
        if (controller.canAttack == true)
        {
            if (comboStep == 2)
            {
                playerAnim.Play("Attack2");
            }
        }
    }

    public void ResetCombo()
    {
        comboPossible = false;
        comboStep = 0;
    }

    void NormalAttack()
    {
        if (controller.canAttack == true)
        {
            if (comboStep == 0)
            {
                playerAnim.Play("Attack1");        
                comboStep = 1;
                return;
            }
            if (comboStep != 0)
            {
                if (comboPossible)
                {
                    comboPossible = false;
                    comboStep += 1;
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            NormalAttack();
    }

    void FreezePlayer()
    {
        controller.enableToMove = false;
    }

    void UnFreezePlayer()
    {
        controller.enableToMove = true;
    }

    void PlaySlashSFX()
    {
        soundManager.sfxList[1].Play();
    }
}
