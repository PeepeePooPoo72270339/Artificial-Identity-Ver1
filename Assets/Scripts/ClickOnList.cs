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
    public float SmallScale;
    public InputAction MouseClick;
    private Vector2 UpClosePos;
    private Vector2 FarawayPos;
    public bool IsReading;
    public GameObject XButton;
    public Collider XButtonCollider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SmallScale = 0.244688779f;
        FarawayPos = Self.transform.position;
        UpClosePos = new Vector2(-0.37f, 0.2f);
        OutlineRender.enabled = false;
        MouseClick.Enable();
        IsReading = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 XButtonScaleLarge = new Vector3(1.2f, 1.2f, 1.2f);
        Vector3 XButtonScaleSmall = new Vector3(1f, 1f, 1f);
        Vector3 mousepos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousepos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, ButtonLayer))
        {
            if (hit.collider.gameObject == Self)
            {
                IsMouseOver = true;
                if (IsReading == false)
                {
                    OutlineRender.enabled = true;
                }
                //print("Mouse is over " + gameObject.name);
                print(IsMouseOver);
                

            }
            else
            {
                IsMouseOver = false;
                OutlineRender.enabled = false;
            }
            if (hit.collider.gameObject == XButton)
            {
                if (MouseClick.WasPressedThisFrame())
                {
                    IsReading = false;
                }
                XButton.transform.localScale = XButtonScaleLarge;     
            }
            else
            {
                XButton.transform.localScale = XButtonScaleSmall;
            }

        }
        else
        {
            IsMouseOver = false;
            OutlineRender.enabled = false;
        }
        if (IsMouseOver && MouseClick.WasPressedThisFrame())
        {
            IsReading = true;    
        }
        if (IsReading)
        {
            transform.position = Vector2.Lerp(transform.position, UpClosePos, 0.1f);
            transform.localScale = new Vector3(LargeScale, LargeScale, LargeScale);
            XButton.SetActive(true);

        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, FarawayPos, 0.1f); 
            transform.localScale = new Vector3(SmallScale,SmallScale,SmallScale);
            XButton.SetActive(false);
        }
    }
}
