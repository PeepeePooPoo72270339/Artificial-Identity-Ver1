using UnityEngine;
using UnityEngine.InputSystem;

public class GameManagerScript : MonoBehaviour
{
    public InputAction OpenMap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenMap.Enable();
        
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

}
