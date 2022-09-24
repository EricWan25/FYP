using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public string nextScene;

    public void FadeComplete()
    {
        SceneManager.LoadScene(nextScene);
    }
}
