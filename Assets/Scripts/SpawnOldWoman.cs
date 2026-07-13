using System.Collections.Generic;
using UnityEngine;

public class SpawnOldWoman : MonoBehaviour
{
    public List<GameObject> StartingNPCs;
    public GameManagerScript GameManager;
    private Quaternion Rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < StartingNPCs.Count; i++)
        {
            Vector2 SpawnPos = new Vector2(20, 200);
            int NPCID = i;
            GameObject Person = StartingNPCs[i];
            Instantiate(Person, SpawnPos, Rotation);
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
