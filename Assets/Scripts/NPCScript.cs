using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public bool IsAI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int RandomNumberGen = Random.Range(1, 10);
        if (RandomNumberGen > 6)
        {
            IsAI = true;

        }
        else
        {
            IsAI = false;
        
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
