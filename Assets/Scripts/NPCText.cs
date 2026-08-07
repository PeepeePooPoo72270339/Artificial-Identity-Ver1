using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NPCText : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject NPC;
    public TMP_Text Dialogue;
    public int Text_Line;
    public InputAction ParseText;
    public AudioSource EnterSFX; //Source: https://pixabay.com/sound-effects/film-special-effects-button-click-vintage-sound-fx-541135/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParseText.Enable();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count > 0)
        {
            NPC = GameManager.GetComponent<GameManagerScript>().NPCSEntering[0];
            Dialogue.text = NPC.GetComponent<NPCScript>().EnteringDialogue[Text_Line];

        }
        else
        {
            Dialogue.text = "";
        }
        ParseText.performed += ctx => ParseLine();
        ParseText.performed += ctx => EnterSFX.Play();

    }
    public void ParseLine()
    { 
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count >0)
        {
            if (Text_Line < NPC.GetComponent<NPCScript>().EnteringDialogue.Count - 1)
            {
                Text_Line++;                
            }
        }  
    
    }
    public void ResetTXT()
    {
        Text_Line = 0;
    
    }
    public void Blank()
    {
        Dialogue.text = "";
    
    
    }
}
