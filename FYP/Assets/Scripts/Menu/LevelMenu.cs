using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Controller controller;

    [SerializeField] string nextLevel;
    [SerializeField] string mainMenu;
    public GameObject pausePlane;

    private void Update()
    {
        Pause();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            controller.canCamMove = false;

            pausePlane.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ClosePausePlane()
    {
        controller.canCamMove = true;

        pausePlane.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }
}
