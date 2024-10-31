using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class ListHero : MonoBehaviour
{
    [SerializeField] private List<AllHero> allHeros;
    [SerializeField] private GameObject uiInformation;
    [SerializeField] private UiInformation information;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject heroBar;

    private void Start()
    {
        SetListHero();
    }

    public List<AllHero> AllHeroes
    {
        get { return allHeros; }
    }

    public void SetListHero()
    {
        foreach (var hero in allHeros)
        {
            var temporary = Instantiate(heroBar, container.transform);
            var sheetHero = temporary.GetComponent<SheetHero>();
            sheetHero.NameText.text = hero.HeroBase.Name;
            sheetHero.LevelText.text = hero.Level.ToString();
            sheetHero.PriceText.text = "Price : " + hero.PriceCurre();
            sheetHero.Avatar.sprite = hero.HeroBase.Sprite;
            sheetHero.Button.onClick.AddListener(()=>CheckClickButton(hero));
            Debug.Log("alo");
        }
    }

    public void CheckClickButton(AllHero hero)
    {
        
        uiInformation.SetActive(true);
        information.Avatar.sprite = hero.HeroBase.Sprite;
        information.LevelText.text = hero.Level.ToString();
        information.NameText.text = hero.HeroBase.Name;
        information.PriceText.text = hero.PriceCurre().ToString();
    }
}

[System.Serializable]
public class AllHero
{
    [SerializeField] private HeroBase heroBase;
    [SerializeField] private int level;
    
    public HeroBase HeroBase
    {
        get { return heroBase; }
    }
    public int Level
    {
        get { return level; }
    }
    public float PriceCurre()
    {
        if (Level == 0)
        {
            return HeroBase.PriceUp;
        }
        else
        {
            return Level * HeroBase.PriceUp + HeroBase.PriceUp;
        }

        
    }
}
