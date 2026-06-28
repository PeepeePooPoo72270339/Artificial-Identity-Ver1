using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject NPC;
    private bool CanShoot;
    public GameObject NPCTXT;
    //public List<GameObject> NPCS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanShoot = false;
        StartCoroutine(StartDelay());
        
        
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
        if (GameManager.GetComponent<GameManagerScript>().NPCSEntering.Count > 0 && CanShoot == true)
        {
            CanShoot = false;
            Destroy(NPC);
            //GameManager.GetComponent<GameManagerScript>().NPCSEntering.RemoveAt(0);
            GameManager.GetComponent<GameManagerScript>().NPCSEntering.Remove(NPC);
            NPCTXT.GetComponent<NPCText>().ResetTXT();
            StartCoroutine(Delay());
            

        }
        print("ShotGuy");
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.GetComponent<GameManagerScript>().Timer = 0;
        CanShoot = true;

    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.5f);
        CanShoot = true;
    }
}
