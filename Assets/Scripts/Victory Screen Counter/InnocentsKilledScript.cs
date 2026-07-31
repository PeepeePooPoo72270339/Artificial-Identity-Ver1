using UnityEngine;

public class InnocentsKilledScript : MonoBehaviour
{
    public int HumansDied;
    public GameObject GameManager;
    public GameObject Gun;
    public TMPro.TextMeshPro InnocentsKilledTXT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HumansDied = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HumansDied = Gun.GetComponent<ShootScript>().InnocentsKilled;
        InnocentsKilledTXT.text = HumansDied.ToString();
    }
}
