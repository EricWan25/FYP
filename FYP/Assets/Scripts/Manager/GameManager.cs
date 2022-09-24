using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Controller controller;

    public Animator fadeAnim;

    public GameObject EnemyObject;

    [Header("Panel")]
    public GameObject deadPanel;
    public GameObject hurtPlane;

    public int nextSceneLoad;

    void Start()
    {
        Time.timeScale = 1;

        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {
        CheckHP();
    }

    public void CheckHP()
    {
        if (controller.playerHPSlider.value <= 0)
        {
            controller.canCamMove = false;
            controller.enableToMove = false;
            controller.canAttack = false;

            deadPanel.SetActive(true);
            hurtPlane.SetActive(false);

            Time.timeScale = 0;
        }

        if (controller.thisLvlEnemyHP.value <= 0)
        {
            controller.canCamMove = false;
            controller.enableToMove = false;
            controller.canAttack = false;
            Destroy(EnemyObject);

            fadeAnim.SetTrigger("FadeOut");

            hurtPlane.SetActive(false);

            FadeToLevel();

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }

    public void FadeToLevel()
    {
        fadeAnim.SetTrigger("FadeOut");
    }
}
