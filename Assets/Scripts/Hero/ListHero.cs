using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ListHero : MonoBehaviour
{
    [SerializeField] private List<AllHero> allHeros;

    public List<AllHero> AllHeroes
    {
        get { return allHeros; }
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
}
