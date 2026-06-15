using UnityEngine;
using UnityEngine.InputSystem;

public class BedScript : MonoBehaviour
{
    public GameObject Self;
    public GameObject GameManager;
    public InputAction GoToBed;
    public Vector2 SelfPos;
    public LayerMask ButtonLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoToBed.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, ButtonLayer))
        {
            if (GoToBed.WasPressedThisFrame() && hit.collider.gameObject == Self)
            {
                print("Sleep");
            
            
            }
        
        
        }

    }
}
