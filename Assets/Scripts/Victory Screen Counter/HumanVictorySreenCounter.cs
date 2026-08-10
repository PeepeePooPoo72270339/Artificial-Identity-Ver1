using System.Collections.Generic;
using UnityEngine;

public class HumanVictorySreenCounter : MonoBehaviour
{
    public GameObject GameManager;
    public List<GameObject> NPCSList;
    public TMPro.TextMeshPro HumanCounterText;
    public int HumanCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HumanCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCSList = GameManager.GetComponent<GameManagerScript>().NPCSInTown;
        HumanCounterText.text = HumanCount.ToString();
    }
    public void HumanCounter()
    {
        for (int i = 0; i < NPCSList.Count; i++)
        {
            if (NPCSList[i].GetComponent<NPCScript>().IsAI == false)
            {
                HumanCount++;

            }

        }

    }
}
