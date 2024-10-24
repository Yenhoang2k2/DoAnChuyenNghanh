using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private Vector3 towerPos;
    
    public float EnemyAttack { get; set; }
    public float AttackSpeed { get; set; }
    public float EnemyHp { get; set; }
    public float EnemySpeed { get; set; }
    private void Awake()
    {
        BulletTo();
    }

    private void Update()
    {
        BulletMove();
    }

    public void BulletMove()
    {
        if (Vector3.Distance(transform.position, towerPos) <= 0.5f)
        {
            // Attack
        }
        else
        {
            //transform.position = new Vector3(transform.position.x-EnemySpeed*Time.deltaTime,transform.position.y);
        }
    }
    public void BulletTo()
    {
        if (tower != null)
        {
            towerPos = tower.transform.position;
        }
    }
}
