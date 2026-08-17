using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenRandomizer : MonoBehaviour
{
    public SpriteRenderer titleScreenIm;
    public List<Sprite> TitleScreens;
    public int TitleToShow;
    public Vector2 NewSpriteSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewSpriteSize = new Vector2(1.85f, 1.85f);

        TitleToShow = Random.Range(0,2);
        titleScreenIm.sprite = TitleScreens[TitleToShow];
        print(TitleToShow);
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleToShow == 1)
        {
            transform.localScale = NewSpriteSize;

        }

    }
}
