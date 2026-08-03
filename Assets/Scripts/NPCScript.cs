using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;


public class NPCScript : MonoBehaviour
{
    public float YOffset;
    public GameObject SpawnPoint;
    public GameObject GameManager;    
    public List<Sprite> FakeSprites;
    public Sprite RealSprite;
    public SpriteRenderer SelfSpriteRenderer;
    public bool IsAI;
    public string Name;
    public Vector2 StartPos;
    public Vector2 EndPos;
    public Vector2 BobUp;
    public Vector2 BobDown;
    public Vector3 MainPos;
    public bool IsLetIn;
    public float Timer;
    public float Duration;
    public bool IsDead;
    public List<string> EnteringDialogue;
    public List<string> Day1Dialogue;
    public List<string> Day2Dialogue;
    public int TownPostioning;
    public InputAction MouseClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StartCoroutine(Delay());       
    }
    void Start()
    {
        EndPos = new Vector2(-15f, 0.7f);
        IsLetIn = false; 
        int RandomNumberGen = Random.Range(1, 10);
        MouseClick.Enable();
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
        //Set sprite for real and fake
        if (IsAI == true)
        {
           int RandomNumberMax = FakeSprites.Count;
           int FakeSpriteID = Random.Range(0, RandomNumberMax -1);
           SelfSpriteRenderer.sprite = FakeSprites[FakeSpriteID];
           
           
        }
        else
        { 
        
        }
        
        
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
        
        if (GameManager.GetComponent<GameManagerScript>().TimeOfDay != 18)
        {
            CheckIfCursorOver();
        }
        
        if (IsLetIn == false)
        {
            StartPos = transform.position;
            MainPos = transform.position;
        }

        if (IsLetIn == true)
        {
            if (Timer < Duration)
            {
                float t = Timer / Duration;
                Vector2 XLerp = Vector2.Lerp(StartPos, EndPos, t);
                Vector2 Ylerper = new Vector2(MainPos.x, MainPos.y -3);
                Vector2 YLerp = Vector2.Lerp(MainPos, Ylerper, Mathf.PingPong(Time.time * 0.35f, 0.2f));
                transform.position = new Vector2(XLerp.x, YLerp.y);

                //transform.position = Vector2.Lerp(StartPos, EndPos, t);
                Timer += Time.deltaTime;
            }
        }
    }
    public void CheckIfCursorOver()
    {
        Vector3 mousepos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousepos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (MouseClick.WasPressedThisFrame())
                {
                    print("Mouse is over " + gameObject.name);
                }                
            }
        }

    }
    public IEnumerator Delay()
    {       
        yield return new WaitForSeconds(0.1f);
        
        BobUp = new Vector2(0, MainPos.y + 0.56f);
        BobDown = new Vector2(0, MainPos.y - 1.2f);
    }
}
