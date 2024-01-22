using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] int ticketCountTotal;
    [SerializeField] int totalScore;
    [SerializeField] int totalPies;


    private void Awake()
    {
        instance = this;

        ticketCountTotal = 0;
        totalScore = 0;
        totalPies = 0;
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

    public void IncrementScore(int amount)
    {
        totalScore += amount;
        UIManager.instance.UpdateTotalScoreText();
    }

    public void DecrementScore()
    {
        totalScore--;
        UIManager.instance.UpdateTotalScoreText();
    }

    public void IncrementPies()
    {
        totalPies++;
        UIManager.instance.UpdatePieText();
    }

    public void DecrementPies()
    {
        totalPies--;
        UIManager.instance.UpdatePieText();

    }

    public int GetTicketCountTotal()
    {
        return ticketCountTotal;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public int GetTotalPies()
    {
        return totalPies;
    }
}
