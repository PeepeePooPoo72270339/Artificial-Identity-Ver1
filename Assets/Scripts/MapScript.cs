using Unity.VisualScripting;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public SpriteRenderer MapPicture;
    public bool IsMapOpen;
    public GameObject Camera;
    public Vector2[] CamPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MapPicture.enabled = IsMapOpen;
        
    }
    public void ToggleMap()
    {
        if (IsMapOpen == false)
        {
            IsMapOpen = true;
        }
        else 
        {
            IsMapOpen = false;
        }  
    }
    public void Warp(int WarpLocation)
    {
        print(WarpLocation);
        Camera.transform.position = new Vector3(CamPos[WarpLocation].x, CamPos[WarpLocation].y, Camera.transform.position.z);
    
    
    }
}
