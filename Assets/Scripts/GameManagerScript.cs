using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
    public InputAction OpenMap;
    public int PeopleEnteringToday;
    public int PeopleLeaving;
    public int PeopleEnteringMin;
    public int PeopleEnteringMax;
    public GameObject PeoplePrefab;
    [SerializeField]
    public List<GameObject> NPCSEntering;
    public List<GameObject> NPCSInTown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenMap.Enable();
        NewDay();
    }

    // Update is called once per frame
    void Update()
    {
        OpenMap.performed += ctx => ShowMap();
        if (NPCSEntering.Count <= 0)
        {
        
        
        }

    }

    void ShowMap()
    {
        print("Map");
        

    }

    public void NewDay()
    {
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

        

}
