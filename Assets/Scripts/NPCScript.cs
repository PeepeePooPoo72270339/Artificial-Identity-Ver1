using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public bool IsAI;
    public string Name;
    public Vector2 StartPos;
    public Vector2 EndPos;
    public bool IsLetIn;
    public float Timer;
    public float Duration;
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
        print(IsAI);

        
    }

    public void AIKill()
    {
        print("Game Over");
    
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLetIn == true)
        {
            if (Timer < Duration)
            {
                float t = Timer / Duration;
                transform.position = Vector2.Lerp(StartPos, EndPos, t);
                Timer += Time.deltaTime;

            }
        }

        

    }
}
