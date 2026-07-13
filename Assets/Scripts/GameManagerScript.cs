using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public int Day;
    public float Timer;
    public float Duration;
    public InputAction OpenMap;
    public InputAction ParseDialogue;
    
    public int PeopleEnteringToday;
    public int PeopleLeaving;
    public int PeopleEnteringMin;
    public int PeopleEnteringMax;
    public GameObject PeoplePrefab;
    public GameObject Map;
    public GameObject GameCamera;
    public GameObject UImanager;
    private bool DayOverBool;
    [SerializeField]
    public List<GameObject> DaysToGrab;
    public GameObject CurrentDay;
    public List<GameObject> NPCSEntering;
    public List<GameObject> NPCSInTown;
    public List<GameObject> DeadNPCS;
    public List<GameObject> NonAINPCS;
    //SpawnPos stuff
    public Vector2 SpawnPos;
    public Vector2 MidPos;
    private Quaternion Rotation;
    public GameObject SpawnerObject;
    public GameObject Middle;
    public GameObject NPCSList;
    public bool IsTutorialOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPos = SpawnerObject.transform.position;
        MidPos = Middle.transform.position;
        OpenMap.Enable();
        NewDay();
        DayOverBool = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenMap.performed += ctx => ShowMap();
        NPCTownPOS();
        if (Timer < Duration && NPCSEntering.Count > 0)
        {
            float t = Timer / Duration;
            NPCSEntering[0].transform.position = Vector2.Lerp(SpawnPos, MidPos, t);
            Timer += Time.deltaTime;
        }
        CurrentDay = DaysToGrab[Day];
    }
    

    void ShowMap()
    {
        print("Map");
        Map.GetComponent<MapScript>().ToggleMap();
        UImanager.GetComponent<UIElementsList>().Toggle();
        

    }

    public void NewDay()
    {
        if (DayOverBool == true)
        {
            StartCoroutine(KillCheck());

            DayOverBool = false;

        }
        
        Day++;
        PeopleEnteringToday = DaysToGrab[Day].GetComponent<NPCList>().npcIDs.Count;
        NonRandomizedSpawn();
        
        //PeopleEnteringToday = Random.Range(PeopleEnteringMin, PeopleEnteringMax);
        //SpawnPeople();
        
        
    }
    public void NonRandomizedSpawn()
    {
        for (int i = 0; i < PeopleEnteringToday; i++)
        {
            int NPCID = i;
            GameObject Person = DaysToGrab[Day].GetComponent<NPCList>().npcIDs[i];
            Instantiate(Person, SpawnPos, Rotation);

        }
        for (int i = 0; i < PeopleEnteringToday; i++)
        {
            NPCSEntering.Add(GameObject.FindGameObjectsWithTag("NPC")[i]);
            //bugfix this part of the code

        }

    }
    
    public void SpawnPeople()
    {
        
        for (int i = 0; i < PeopleEnteringToday; i++)
        {
            int NPCID = Random.Range(0, 12);
            GameObject Person = NPCSList.GetComponent<NPCList>().npcIDs[NPCID];
            Instantiate(Person, SpawnPos, Rotation);
            //NPCSEntering.Add(PeoplePrefab);
            

        }
        for (int i = 0; i < PeopleEnteringToday; i++)
        {
            NPCSEntering.Add(GameObject.FindGameObjectsWithTag("NPC")[i]);
            //bugfix this part of the code
        
        }
    
    }
    public IEnumerator KillCheck()
    {
        for (int i = 0; i < NPCSInTown.Count; i++)
        {
            if (NPCSInTown[i].GetComponent<NPCScript>().IsAI == true)
            {
                NPCSInTown[i].GetComponent<NPCScript>().AIKill();
            }
            if (i == NPCSInTown.Count - 1)
            {
                DayOverBool = true;
            
            }
        }

        yield return null;
    }
    public void NPCTownPOS()
    {
        for (int i = 0; i < NPCSInTown.Count; i++)
        {
            NPCSInTown[i].transform.position = new Vector2(0f, 0f);
        
        
        }
    
    
    }



}
