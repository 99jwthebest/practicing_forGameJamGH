using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] int ticketCountTotal;

    private void Awake()
    {
        instance = this;

        ticketCountTotal = 0;
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

    public int GetTicketCountTotal()
    {
        return ticketCountTotal;
    }
}
