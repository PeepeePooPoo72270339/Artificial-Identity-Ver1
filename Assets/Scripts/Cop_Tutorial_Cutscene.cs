using UnityEngine;
using UnityEngine.InputSystem;

public class Cop_Tutorial_Cutscene : MonoBehaviour
{
    public bool IsTutorialOver;
    public GameObject TutorialChar;
    public GameObject DisplayedDialogue;
    public GameObject GameManager;
    public GameObject LetSelfIn;
    public int DialogueLength;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TutorialChar = GameObject.Find("Cop");
        TutorialChar = this.gameObject;
        DialogueLength = TutorialChar.GetComponent<NPCScript>().EnteringDialogue.Count;
        TutorialChar.GetComponent<NPCScript>().IsAI = false;
        DisplayedDialogue = GameObject.FindGameObjectWithTag("DialogueBox");
        LetSelfIn = GameObject.Find("Let_In");
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        int CurrentLine = DisplayedDialogue.GetComponent<NPCText>().Text_Line;
        if (CurrentLine == DialogueLength - 1)
        {          
            if (DisplayedDialogue.GetComponent<NPCText>().ParseText.triggered)
            {
                EndTutorial();

            }
        }

        
    }
    public void EndTutorial()
    {
        print("EnterPressed");
        LetSelfIn.GetComponent<LetPersonInScript>().LetNPCIn();
        GameManager.GetComponent<GameManagerScript>().IsTutorialOver = true;
    }
}
