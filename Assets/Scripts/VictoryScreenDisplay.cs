using UnityEngine;

public class VictoryScreenDisplay : MonoBehaviour
{
    public HumanVictorySreenCounter HumanCounter;
    public BotVictoryScreenCounter BotCounter;
    private int Humans;
    private int Bots;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Humans = HumanCounter.GetComponent<HumanVictorySreenCounter>().HumanCount;
        Bots = BotCounter.GetComponent<BotVictoryScreenCounter>().AICount;
        if (Humans > Bots)
        {
            WinScreen.SetActive(true);

        }
        else
        {
            WinScreen.SetActive(false);
        
        }
    }
}
