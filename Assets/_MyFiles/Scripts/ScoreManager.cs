using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] int ticketCountTotal;
    [SerializeField] int totalScore;

    private void Awake()
    {
        instance = this;

        ticketCountTotal = 0;
        totalScore = 0;

    }


    void Start()
    {

    }

    void Update()
    {

    }

    public void IncrementTicketCount()
    {
        ticketCountTotal++;
        UIManager.instance.UpdateTicketCountText();
    }

    public void DecrementTicketCount()
    {
        ticketCountTotal--;
        UIManager.instance.UpdateTicketCountText();
    }

    public void IncrementScore()
    {
        totalScore++;
        UIManager.instance.UpdateTotalScoreText();
    }

    public void DecrementScore()
    {
        totalScore--;
        UIManager.instance.UpdateTotalScoreText();
    }


    public int GetTicketCountTotal()
    {
        return ticketCountTotal;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
