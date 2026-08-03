using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{
    [Header ("Important Game Vars")]
    public int Day;
    public int TimeOfDay;
    public bool IsTutorialOver;

    [Header ("Inputs")]
    public InputAction OpenMap;
    public InputAction ParseDialogue;

    [Header("NPC Instantiate ForDay")]
    public int PeopleEnteringToday;
    public int PeopleLeaving;
    public int PeopleEnteringMin;
    public int PeopleEnteringMax;
    public GameObject PeoplePrefab;

    [Header("Other GameObjects")]
    public GameObject Map;
    public GameObject GameCamera;
    public GameObject UImanager;
    private bool DayOverBool;
    [SerializeField]

    [Header("Non Randomized Spawn")]
    public List<GameObject> DaysToGrab;
    public GameObject CurrentDay;
    public List<GameObject> TownPositions;
    public List<Vector3> TownPosScale;

    [Header("Spawned NPC Manager")]
    public List<GameObject> NPCSEntering;
    public List<GameObject> NPCSInTown;
    public List<GameObject> DeadNPCS;
    public List<GameObject> NonAINPCS;

    [Header("NPC Spawn and Lerp stuff")]
    public Vector2 SpawnPos;
    public Vector2 MidPos;
    private Quaternion Rotation;
    public GameObject SpawnerObject;
    public GameObject Middle;
    public float Timer;
    public float Duration;
    public GameObject NPCSList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPos = SpawnerObject.transform.position;
        MidPos = Middle.transform.position;
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
            Vector2 NewPos = new Vector2(MidPos.x, NPCSEntering[0].GetComponent<NPCScript>().transform.position.y);
            NPCSEntering[0].transform.position = Vector2.Lerp(SpawnPos, NewPos, t);
            Timer += Time.deltaTime;
        }
        if (NPCSEntering.Count <= 0 && TimeOfDay != 18)
        {
            OpenMap.Enable();

        }
        else 
        {
            if (TimeOfDay == 18 && NPCSEntering.Count <= 0)
            { 
                Map.GetComponent<MapScript>().Warp(2);
            
            }
            OpenMap.Disable();        
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
            TimeOfDay = 9;
            DayOverBool = false;

        }
        
        Day++;
        if (TimeOfDay == 18)
        {
            PeopleEnteringToday = DaysToGrab[Day].GetComponent<NPCList>().npcIDs.Count;
            NonRandomizedSpawn();

        }

        
        //PeopleEnteringToday = Random.Range(PeopleEnteringMin, PeopleEnteringMax);
        //SpawnPeople();
        
        
    }
    public void NonRandomizedSpawn()
    {
        for (int i = 0; i < PeopleEnteringToday; i++)
        {
            int NPCID = i;
            //Vector3 NewSpawnPos = new Vector3(SpawnPos.x, SpawnPos.y - 1.2f, 0);
            
            GameObject Person = DaysToGrab[Day].GetComponent<NPCList>().npcIDs[i];
            float NewY = Person.GetComponent<NPCScript>().transform.position.y;
            Vector3 NewSpawnPos = new Vector3(SpawnPos.x, NewY, 0);
            Instantiate(Person, NewSpawnPos, Rotation);
            print("Spawned " + Person.name + " at " + Person.transform.position);

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
            int NPCWantLocation = NPCSInTown[i].GetComponent<NPCScript>().TownPostioning;
            Vector2 TownPositioning = TownPositions[NPCWantLocation].transform.position;
            NPCSInTown[i].transform.position = TownPositioning;
        
        
        }
    
    
    }

}
