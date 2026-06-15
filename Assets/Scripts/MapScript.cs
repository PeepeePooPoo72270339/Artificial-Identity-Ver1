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
}
