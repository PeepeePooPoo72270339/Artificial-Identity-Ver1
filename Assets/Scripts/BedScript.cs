using UnityEngine;
using UnityEngine.InputSystem;

public class BedScript : MonoBehaviour
{
    public GameObject Self;
    public GameObject GameManager;
    public GameObject PlayerCamera;
    public bool IsDemo;
    public InputAction GoToBed;
    public Vector2 SelfPos;
    public LayerMask ButtonLayer;
    public GameObject BotCounter;
    public GameObject HumanCounter;
    // victory screen pos is 73 x
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsDemo = true;
        GoToBed.Enable();
        
    }
    public void VictoryScreenDemo()
    {
        Vector2 CamPos = new Vector2(74, 0);
        PlayerCamera.transform.position = new Vector3(CamPos.x, CamPos.y, PlayerCamera.transform.position.z);
        BotCounter.GetComponent<BotVictoryScreenCounter>().AICounter();
        HumanCounter.GetComponent<HumanVictorySreenCounter>().HumanCounter();
    
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
                if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count == 0)
                {
                    print("Sleep");
                    //GameManager.GetComponent<GameManagerScript>().NewDay();
                    VictoryScreenDemo();
                }
                else
                {
                    print("People are trying to enter");                
                }           
            
            }
              
        }

    }
}
