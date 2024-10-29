using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] private HpBar hpBar;
    private Vector3 towerPos;
    bool isMoving = true;
    private float hpCurrent;

    public float EnemyAttack { get; set; }
    public float AttackSpeed { get; set; }
    public float EnemyMaxHp { get; set; }
    public float EnemySpeed { get; set; }

    private void Start()
    {
        hpCurrent = EnemyMaxHp;
        hpBar.SetHp();
    }

    private void Update()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        if (isMoving)
            transform.position = new Vector3(transform.position.x - EnemySpeed * Time.deltaTime, transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            isMoving = false;
        }
    }

    public void TakeDame(float dame)
    {
        hpCurrent -= dame;
        if (hpCurrent <= 0)
        {
            hpCurrent = 0;
            Destroy(gameObject);
            return;
        }

        hpBar.UpdateHp(hpCurrent / EnemyMaxHp);
    }
}
