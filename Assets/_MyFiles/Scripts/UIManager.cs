using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] HealthComponent playerHealthComponent;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI ticketPickupCountText;
    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] TextMeshProUGUI pieText;
    [SerializeField] TextMeshProUGUI groundSlamText;


    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject winMenuUI;
    [SerializeField] GameObject loseMenuUI;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateHealth();
        UpdateTicketCountText();
        UpdateTotalScoreText();
        UpdatePieText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth()
    {
        healthText.text = "" + playerHealthComponent.GetCurrentHealth().ToString();
    }

    public void UpdateTicketCountText()
    {
        ticketPickupCountText.text = "" + ScoreManager.instance.GetTicketCountTotal();

    }

    public void UpdateTotalScoreText()
    {
        totalScoreText.text = "" + ScoreManager.instance.GetTotalScore();

    }

    public void UpdatePieText()
    {
        pieText.text = "" + AmmoComponent.instance.GetAmmo();

    }
    public void UpdateGroundSlamText()
    {
        groundSlamText.text = "" + GroundSlamComponent.instance.GetGroundSlamAmount();

    }

    public void ActivatePauseMenuUI(bool pause)
    {
        pauseMenuUI.SetActive(pause);
    }

    public void ActivateWinMenuUI()
    {
        winMenuUI.SetActive(true);
    }

    public void ActivateLoseMenuUI()
    {
        loseMenuUI.SetActive(true);
    }

}
