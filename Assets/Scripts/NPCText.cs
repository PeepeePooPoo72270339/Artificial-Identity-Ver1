using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class NPCText : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject NPC;
    public TMP_Text Dialogue;
    public int Text_Line;
    public InputAction ParseText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count > 0)
        {
            NPC = GameManager.GetComponent<GameManagerScript>().NPCSEntering[0];

        }
        Dialogue.text = NPC.GetComponent<NPCScript>().EnteringDialogue[Text_Line];

    }
}
