using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;


public class NPCScript : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject GameManager;
    public bool IsAI;
    public string Name;
    public Vector2 StartPos;
    public Vector2 EndPos;
    public Vector2 BobUp;
    public Vector2 BobDown;
    public bool IsLetIn;
    public float Timer;
    public float Duration;
    public bool IsDead;
    public List<string> EnteringDialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EndPos = new Vector2(-15f, 0.7f);
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
        if (IsLetIn == false)
        {
            StartPos = transform.position;

        }

        if (IsLetIn == true)
        {
            if (Timer < Duration)
            {
                float t = Timer / Duration;
                Vector2 XLerp = Vector2.Lerp(StartPos, EndPos, t);
                Vector2 YLerp = Vector2.Lerp(StartPos, EndPos, t);
                if (transform.position.y < BobUp.y)
                { 
                
                    
                }
                transform.position = new Vector2(XLerp.x, YLerp.y);
                //transform.position = Vector2.Lerp(StartPos, EndPos, t);
                Timer += Time.deltaTime;

            }
        }

    }
}
