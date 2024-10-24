using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    public Bullet Bullet { get; set; }
    public HeroBase HeroBase { get; set; }
    public int Level { get; set; }

    public Hero(HeroBase heroBase,int level)
    {
        HeroBase = heroBase;
        Level = level;
    }

    public float Attack
    {
        get { return Level * HeroBase.Coeffcent + HeroBase.Attack; }
    }
    public float PriceCurre
    {
        get { return Level * HeroBase.PriceUp + HeroBase.Attack; }
    }
}
