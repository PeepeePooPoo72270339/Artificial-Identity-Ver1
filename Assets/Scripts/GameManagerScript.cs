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

    }

    void ShowMap()
    {
        print("Map");

    }
    [SerializeField]
    public List<GameObject> NPC;
    public void NewDay()
    {
        PeopleEnteringToday = Random.Range(PeopleEnteringMin, PeopleEnteringMax);
    }
        

}
