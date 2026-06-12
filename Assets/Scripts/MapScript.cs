using Unity.VisualScripting;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public SpriteRenderer MapPicture;
    public bool IsMapOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleMap()
    {
        if (IsMapOpen == false)
        {
            MapPicture.enabled = true;
            IsMapOpen = true;
        }
        else 
        {
            MapPicture.enabled = false;
            IsMapOpen = false;
        }

    
    
    
    }
}
