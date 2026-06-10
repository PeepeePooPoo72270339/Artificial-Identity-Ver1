using UnityEngine;

public class LetPersonInScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject NewNPCToAdd;

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

        }
        

    }

    public void LetNPCIn()
    {
        print("Letguy in");
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count > 0)
        {
            GameManager.GetComponent<GameManagerScript>().NPCSEntering[0].GetComponent<NPCScript>().IsLetIn = true;
            GameManager.GetComponent<GameManagerScript>().NPCSInTown.Add(NewNPCToAdd);
            GameManager.GetComponent<GameManagerScript>().NPCSEntering.Remove(NewNPCToAdd);
        }



    }
}
