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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth()
    {
        //playerHealthComponent.TakeDamage(1);
        healthText.text = "Health: " + playerHealthComponent.GetCurrentHealth().ToString();
    }

    public void UpdateTicketCountText()
    {
        ticketPickupCountText.text = "Tickets: " + ScoreManager.instance.GetTicketCountTotal();

    }

    public void UpdateTotalScoreText()
    {
        totalScoreText.text = "Score: " + ScoreManager.instance.GetTotalScore();

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
