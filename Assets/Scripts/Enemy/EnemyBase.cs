using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy",fileName = "Enemy/Create new enemy")]
public class EnemyBase : ScriptableObject
{
    // base
    [SerializeField] private string name;
    [TextArea] [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float hp;
    [SerializeField] private float attack;
    [SerializeField] private float speed;
    [SerializeField] private float attackSpeed;

    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public Sprite Sprite
    {
        get { return sprite; }
    }
    public float Hp
    {
        get { return hp; }
    }
    public float Attack
    {
        get { return attack; }
    }
    public float Speed
    {
        get { return speed; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
    }
    
    public float AttackCurrent(int level)
    {
        return Attack + (level*0.1f);
    }
    public float HpCurrent(int level)
    {
         return Hp + (level * 1f);
    }
}
