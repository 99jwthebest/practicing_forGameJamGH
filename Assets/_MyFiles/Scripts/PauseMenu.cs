using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool pauseMenuActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PausingGame();
        }
    }

    public void ResumeButton()
    {
        PausingGame();
    }

    void PausingGame()
    {
        pauseMenuActive = !pauseMenuActive;
        UIManager.instance.ActivatePauseMenuUI(pauseMenuActive);
        CountupTimer.instance.SetTime(pauseMenuActive);
    }

}
