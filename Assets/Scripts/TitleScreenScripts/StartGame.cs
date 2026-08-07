using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public AudioSource ButtonClickSFX;
    public AudioSource HoverClickSFX; //Source = https://pixabay.com/sound-effects/film-special-effects-clickselect2-92097/
    public Vector3 ScaleLarge;
    public bool IsMouseOver;
    public LayerMask ButtonLayer;
    public InputAction Click;
    public GameObject Self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Click.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousepos);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, ButtonLayer))
        {
            if (hit.collider.gameObject == Self)
            {
                IsMouseOver = true;
                Self.transform.localScale = new Vector3(ScaleLarge.x, ScaleLarge.y, ScaleLarge.z);
                print("Mouse is over " + gameObject.name);
                print(IsMouseOver);

            }
                  
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            IsMouseOver = false;
            print(IsMouseOver);

        }
        if (IsMouseOver == true)
        {
            HoverClickSFX.enabled = true;
        }
        else
        {
            HoverClickSFX.enabled = false;
        }
        if (Click.WasPressedThisFrame() && IsMouseOver == true)
        {
            StartTheGame();
        }
    }
    public void StartTheGame()
    {
        //SceneManager.LoadScene("SampleScene");
        ButtonClickSFX.Play();
        StartCoroutine(Delay());
         
    
    }
    public IEnumerator Delay()
    { 
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("OpeningCutscene");

    }

}
