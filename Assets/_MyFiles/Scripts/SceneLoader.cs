using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);

    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = CountupTimer.instance.GetStartTimeScale();

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = CountupTimer.instance.GetStartTimeScale();

    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Qutting Game...");
    }
}
