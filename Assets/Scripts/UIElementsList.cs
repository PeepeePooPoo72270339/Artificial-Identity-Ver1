using System.Collections.Generic;
using UnityEngine;

public class UIElementsList : MonoBehaviour
{
    public List<GameObject> UIElem;
    public List <GameObject> DialogueBox;
    public bool ElementsActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ElementsActive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ElementsActive == false)
        {
            foreach (GameObject element in UIElem)
            {
                element.SetActive(false);

            }


        }
        if (ElementsActive == true)
        {
            foreach (GameObject element in UIElem)
            {
                element.SetActive(true);
                

            }

        }
        
    }
    public void Toggle()
    {
        if (ElementsActive == false)
        {
            ElementsActive = true;      
        
        }
        else
        {
            ElementsActive = false;


        }
    
    
    }
}
