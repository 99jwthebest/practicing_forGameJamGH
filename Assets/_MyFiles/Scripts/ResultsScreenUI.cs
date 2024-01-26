using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScreenUI : MonoBehaviour
{
    public bool GameIsPaused = false;
    public float timeScaleValue;
    //public GameObject pauseMenuUI;

    public GameObject winMenuUI;
    public TextMeshProUGUI enemiesKilledNumText;
    public TextMeshProUGUI ticketsCollectedText;
    public TextMeshProUGUI piesCollectedText;
    public TextMeshProUGUI gameScoreText;
    public TextMeshProUGUI timeBonusText;
    public TextMeshProUGUI totalScoreNumText;
    public Transform rankIcons;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

        float timeBonus = CountupTimer.instance.GetCurrentTime();
        timeBonus *= 1000;
    }

    // Update is called once per frame
    void Update()
    {
        WinMenuPause();

    }


    void WinMenuPause()
    {

        //winMenuUI.SetActive(true);
        enemiesKilledNumText.text = ScoreManager.instance.GetTotalEnemies().ToString();
        ticketsCollectedText.text = ScoreManager.instance.GetTicketCountTotal().ToString();
        piesCollectedText.text = ScoreManager.instance.GetTotalPies().ToString();
        gameScoreText.text = ScoreManager.instance.GetTotalScore().ToString();
        timeBonusText.text = "-" + timeBonus();
        totalScoreNumText.text = sumOfScore().ToString();

        if (sumOfScore() >= 60000) rankIcons.GetChild(0).gameObject.SetActive(true);
        if (sumOfScore() < 60000 && sumOfScore() >= 50000) rankIcons.GetChild(1).gameObject.SetActive(true);
        if (sumOfScore() < 40000 && sumOfScore() >= 30000) rankIcons.GetChild(2).gameObject.SetActive(true);
        if (sumOfScore() < 20000 && sumOfScore() >= 10000) rankIcons.GetChild(3).gameObject.SetActive(true);
        if (sumOfScore() < 10000) rankIcons.GetChild(4).gameObject.SetActive(true);

        GameIsPaused = true;
        //Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public int sumOfScore()
    {
        int sum = ScoreManager.instance.GetTotalScore() - timeBonus();
        return sum;
    }

    int timeBonus()
    {
        float time = CountupTimer.instance.GetCurrentTime();
        int timeBonusF = Mathf.FloorToInt(time * 25);
        return timeBonusF;
    }


}
