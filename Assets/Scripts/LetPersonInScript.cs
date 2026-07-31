using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LetPersonInScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject NewNPCToAdd;
    public GameObject NPCTXT;
    public GameObject MidPoint;
    public Button LetInButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count > 0)
        {
            NewNPCToAdd = GameManager.GetComponent<GameManagerScript>().NPCSEntering[0];
            NPCMidpointStuff();
            
        }
              
    }
    public void NPCMidpointStuff()
    {
        float NPCxPos = NewNPCToAdd.transform.position.x;
        float MidPointXpos = MidPoint.transform.position.x;
        int NPCRounded = Mathf.FloorToInt(NPCxPos);
        int MidPointRounded = Mathf.FloorToInt(MidPointXpos);
        bool IsActive = NPCRounded == MidPointXpos;
        if (IsActive == true)
        {
            LetInButton.interactable = true;
        }
        else
        {
            LetInButton.interactable = false;
        }
        return;

    }

    public void LetNPCIn()
    {
        print("Letguy in");
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count > 0)
        {
            NewNPCToAdd.GetComponent<NPCScript>().IsLetIn = true;
            NewNPCToAdd.tag = "InTown";
            //GameManager.GetComponent<GameManagerScript>().NPCSEntering[NewNPCToAdd].GetComponent<NPCScript>().IsLetIn = true;
            GameManager.GetComponent<GameManagerScript>().NPCSInTown.Add(NewNPCToAdd);
            if (NewNPCToAdd.GetComponent<NPCScript>().IsAI == false)
            {
                GameManager.GetComponent<GameManagerScript>().NonAINPCS.Add(NewNPCToAdd);
            }
            
            GameManager.GetComponent<GameManagerScript>().NPCSEntering.Remove(NewNPCToAdd);
            NPCTXT.GetComponent<NPCText>().ResetTXT();
            StartCoroutine(Delay());
            
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1.5f);
            GameManager.GetComponent<GameManagerScript>().Timer = 0;
        }    


    }
}
