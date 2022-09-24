using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSeclet : MonoBehaviour
{
    [SerializeField] string level1;
    [SerializeField] string level2;
    [SerializeField] string level3;
    [SerializeField] string MainMenu;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Level1()
    {
        SceneManager.LoadScene(level1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(level2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(level3);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

}

