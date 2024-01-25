using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScreenUI : MonoBehaviour
{
    //public bool GameIsPaused = false;
    //public float timeScaleValue;
    ////public GameObject pauseMenuUI;

    //public GameObject winMenuUI;
    //public TextMeshProUGUI zombiesKilledNumText;
    //public TextMeshProUGUI highestComboText;
    //public TextMeshProUGUI gameScoreText;
    //public TextMeshProUGUI timeBonusText;
    //public TextMeshProUGUI totalScoreNumText;
    //[SerializeField]
    //private int numOfZombiesToKill;
    //private int totalScore;
    //public Transform rankIcons;
    //PlayerController playerController;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    //    float timeBonus = CountdownTimer.Instance.GetCurrentTime();
    //    timeBonus *= 1000;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (ScoreSystem.instance.zombiesPlayerKilled() >= numOfZombiesToKill ||
    //        playerController.GetCurrentHealth() <= 0 ||
    //        CountdownTimer.Instance.GetCurrentTime() <= 0)
    //    {
    //        WinMenuPause();
    //    }

    //}


    //void WinMenuPause()
    //{

    //    winMenuUI.SetActive(true);
    //    zombiesKilledNumText.text = ScoreSystem.instance.zombiesPlayerKilled().ToString();
    //    highestComboText.text = playerController.highestCombo.ToString();
    //    gameScoreText.text = ScoreSystem.instance.GetCurrentScore().ToString();
    //    timeBonusText.text = "+" + timeBonus();
    //    totalScoreNumText.text = sumOfScore().ToString();

    //    if (sumOfScore() >= 1000000) rankIcons.GetChild(0).gameObject.SetActive(true);
    //    if (sumOfScore() < 1000000 && sumOfScore() >= 800000) rankIcons.GetChild(1).gameObject.SetActive(true);
    //    if (sumOfScore() < 800000 && sumOfScore() >= 400000) rankIcons.GetChild(2).gameObject.SetActive(true);
    //    if (sumOfScore() < 400000) rankIcons.GetChild(3).gameObject.SetActive(true);

    //    GameIsPaused = true;
    //    Time.timeScale = 0f;
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //}

    //public int sumOfScore()
    //{
    //    int sum = ScoreManager.instance.GetCurrentScore() + timeBonus();
    //    return sum;
    //}

    //int timeBonus()
    //{
    //    float time = CountupTimer.instance.GetCurrentTime();
    //    int timeBonusF = Mathf.FloorToInt(time * 1000);
    //    return timeBonusF;
    //}

    
}
