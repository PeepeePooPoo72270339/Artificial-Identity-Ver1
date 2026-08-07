using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickOnList : MonoBehaviour
{
    public GameObject Self;
    public GameObject Outline;
    public SpriteRenderer OutlineRender;
    public LayerMask ButtonLayer;
    public bool IsMouseOver;
    public float LargeScale;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OutlineRender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousepos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, ButtonLayer))
        {
            if (hit.collider.gameObject == Self)
            {
                IsMouseOver = true;
                //OutlineRender.enabled = true;
                print("Mouse is over " + gameObject.name);
                print(IsMouseOver);

            }
            else
            {
                IsMouseOver = false;
                //OutlineRender.enabled = false;
            }

        }

    }
}
