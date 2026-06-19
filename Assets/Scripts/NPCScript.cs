using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public GameObject GameManager;
    public bool IsAI;
    public string Name;
    public Vector2 StartPos;
    public Vector2 EndPos;
    public bool IsLetIn;
    public float Timer;
    public float Duration;
    public bool IsDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsLetIn = false;
        int RandomNumberGen = Random.Range(1, 10);
        GameManager = GameObject.Find("GameManager");
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
        if (GameManager.GetComponent<GameManagerScript>().NonAINPCS.Count > 0)
        {
            int PickRandomInnocent = Random.Range(0, GameManager.GetComponent<GameManagerScript>().NonAINPCS.Count);
            GameObject KilledInnocent = GameManager.GetComponent<GameManagerScript>().NonAINPCS[PickRandomInnocent];
            GameManager.GetComponent<GameManagerScript>().NonAINPCS.Remove(KilledInnocent);
            GameManager.GetComponent<GameManagerScript>().NPCSInTown.Remove(KilledInnocent);
            GameManager.GetComponent<GameManagerScript>().DeadNPCS.Add(KilledInnocent);

        }

    
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
