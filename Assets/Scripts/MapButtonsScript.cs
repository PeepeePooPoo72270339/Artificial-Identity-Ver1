using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MapButtonsScript : MonoBehaviour
{
    public GameObject Self;
    public GameObject MapParent;
    public SpriteRenderer SelfSprite;
    public InputAction MouseClick;
    public Vector2 SelfPos;
    public LayerMask ButtonLayer;
    private Vector2[] Locations;
    public int LocationID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MouseClick.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        SelfSprite.enabled = MapParent.GetComponent<MapScript>().IsMapOpen;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, ButtonLayer))
        {
            if (MouseClick.WasPressedThisFrame() && hit.collider.gameObject == Self)
            {
                //print("hit" + hit.collider.gameObject.name);
                //Camera.main.transform.position = new Vector3(Locations[LocationID].x, Locations[LocationID].y, Camera.main.transform.position.z);
                MapParent.GetComponent<MapScript>().IsMapOpen = false;
                MapParent.GetComponent<MapScript>().Warp(LocationID);

            }
        
        }
    }
}
