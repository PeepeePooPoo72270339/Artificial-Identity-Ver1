using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OpeningSceneTXT : MonoBehaviour
{
    public List<string> TXT;
    public TMP_Text LineToShow;
    private int CurrentLine;
    public InputAction Parse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Parse.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        LineToShow.text = TXT[CurrentLine];
        Parse.performed += ctx => Dialogue();
        
    }
    public void Dialogue()
    {
        if (CurrentLine < TXT.Count -1)
        {
            CurrentLine++;
            if (CurrentLine == TXT.Count - 1)
            {   
                SceneManager.LoadScene("SampleScene");
            }
        }

    
    }
}
