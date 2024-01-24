using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] float ticketCountTotal;
    [SerializeField] float totalScore;
    [SerializeField] int totalPies;

    int twice;
    int twiceForTicket;

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

    public void IncrementScore(float amount)
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
        //totalPies ;
        UIManager.instance.UpdatePieText();
    }

    public void DecrementPies()
    {
        //totalPies--;
        UIManager.instance.UpdatePieText();

    }

    public float GetTicketCountTotal()
    {
        return ticketCountTotal;
    }

    public float GetTotalScore()
    {
        return totalScore;
    }

    public int GetTotalPies()
    {
        return totalPies;
    }
}
