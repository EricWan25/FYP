using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string startLevel;
    [SerializeField] string levelSelect;
    public GameObject howToPlayPlane;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void HowToPlay()
    {
        howToPlayPlane.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayPlane.SetActive(false);
    }
}
