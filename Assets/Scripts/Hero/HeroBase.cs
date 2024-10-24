using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero",menuName = "Hero/Create new hero")]
public class HeroBase : ScriptableObject
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private string name;
    [TextArea]
    [SerializeField] private string desciption;

    [SerializeField] private Sprite sprite;

    [SerializeField] private float price;
    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float bulletSpeed;
    
    [SerializeField] private float coeffcent;
    [SerializeField] private int priceUp;

    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return desciption; }
    }
    public float Price
    {
        get { return price; }
    }
    public float Attack
    {
        get { return attack; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
    }
    public float Coeffcent
    {
        get { return coeffcent; }
    }
    public int PriceUp
    {
        get { return priceUp; }
    }

    public Sprite Sprite
    {
        get { return sprite; }
    }

    public float BulletSpeed
    {
        get { return bulletSpeed; }
    }
}
