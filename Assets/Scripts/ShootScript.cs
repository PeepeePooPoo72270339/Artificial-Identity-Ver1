using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject NPC;
    //public List<GameObject> NPCS;
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
        
    }
    public void Kill()
    {
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count > 0)
        {
            Destroy(NPC);
            //GameManager.GetComponent<GameManagerScript>().NPCSEntering.RemoveAt(0);
            GameManager.GetComponent<GameManagerScript>().NPCSEntering.Remove(NPC);

        }
        print("ShotGuy");
    }
}
