using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MapButtonsScript : MonoBehaviour
{
    public GameObject Self;
    public Vector2 SelfPos;
    public LayerMask ButtonLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
        //print(mouseRay);
        //print(Self.transform.position);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, ButtonLayer))
        {
            print("hit");
        
        }
    }
}
