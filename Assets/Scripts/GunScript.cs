using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{
    public GameObject Self;
    public GameObject ShellsOutline;
    public GameObject Outline;
    public InputAction MouseClick;
    public LayerMask ButtonLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MouseClick.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Mouse.current.position.ReadValue();
        Ray mouseray = Camera.main.ScreenPointToRay(mousepos);

        if (Physics.Raycast(mouseray, out RaycastHit hit, Mathf.Infinity, ButtonLayer))
        {
            if (hit.collider.gameObject == Self)
            {
                Outline.GetComponent<SpriteRenderer>().enabled = true;
                ShellsOutline.GetComponent<SpriteRenderer>().enabled = true;
                if (MouseClick.WasPressedThisFrame())
                {
                    Self.GetComponent<ShootScript>().Kill();

                }

            }
        }
        else
        {
            Outline.GetComponent<SpriteRenderer>().enabled = false;
            ShellsOutline.GetComponent<SpriteRenderer>().enabled = false;

        }
        
    }
}
