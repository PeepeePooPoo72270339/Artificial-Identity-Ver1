using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public InputAction OpenMap;
    public int PeopleEnteringToday;
    public int PeopleLeaving;
    public int PeopleEnteringMin;
    public int PeopleEnteringMax;
    public GameObject PeoplePrefab;
    public GameObject Map;
    private bool DayOverBool;
    [SerializeField]
    public List<GameObject> NPCSEntering;
    public List<GameObject> NPCSInTown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenMap.Enable();
        NewDay();
        DayOverBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        OpenMap.performed += ctx => ShowMap();
    }
    

    void ShowMap()
    {
        print("Map");
        Map.GetComponent<MapScript>().ToggleMap();
        

    }

    public void NewDay()
    {
        if (DayOverBool == true)
        {
            StartCoroutine(KillCheck());

            DayOverBool = false;

        }
        
        PeopleEnteringToday = Random.Range(PeopleEnteringMin, PeopleEnteringMax);
        SpawnPeople();
        
    }
    public void SpawnPeople()
    {
        for (int i = 0; i < PeopleEnteringToday; i++)
        {
            Instantiate(PeoplePrefab);
            //NPCSEntering.Add(PeoplePrefab);
            

        }
        for (int i = 0; i < PeopleEnteringToday; i++)
        {
            NPCSEntering.Add(GameObject.FindGameObjectsWithTag("NPC")[i]);
        
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



}
