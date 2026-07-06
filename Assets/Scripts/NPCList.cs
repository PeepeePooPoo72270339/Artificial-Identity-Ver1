using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NPCList : MonoBehaviour
{
    public int Day_Number;
    public int ListLength;
    public List<GameObject> npcIDs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListLength = npcIDs.Count;
        
    }
}
