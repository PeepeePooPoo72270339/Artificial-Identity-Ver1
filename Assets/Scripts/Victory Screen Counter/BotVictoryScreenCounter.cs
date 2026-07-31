using System.Collections.Generic;
using UnityEngine;

public class BotVictoryScreenCounter : MonoBehaviour
{
    public GameObject GameManager;
    public List <GameObject> NPCSList;
    public TMPro.TextMeshPro AiCounterText;
    private int AICount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AICount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        NPCSList = GameManager.GetComponent<GameManagerScript>().NPCSInTown;
        AiCounterText.text = AICount.ToString();
    }
    public void AICounter()
    {
        for (int i = 0; i < NPCSList.Count; i++)
        {
            if (NPCSList[i].GetComponent<NPCScript>().IsAI == true)
            {
                AICount++;
               
            }

        }
    
    }
}
