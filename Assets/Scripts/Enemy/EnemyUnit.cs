using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] private HpBar hpBar;
    
    private TowerUnit _towerUnit;
    private bool _isInRange;
    private bool _isMoving = true;
    private float _hpCurrent;
    private float _timeWait;
    private Transform _enemyTo;

    public float EnemyAttack { get; set; }
    public float AttackSpeed { get; set; }
    public float EnemyMaxHp { get; set; }
    public float EnemySpeed { get; set; }

    private void Start()
    {
        _enemyTo = transform;
        _hpCurrent = EnemyMaxHp;
        hpBar.SetHp();
    }

    private void Update()
    {
        EnemyMove();
        _timeWait += Time.deltaTime;
        if (_isInRange && _timeWait >= AttackSpeed)
        {
            _towerUnit.TakeDame(EnemyAttack);
            _timeWait = 0;
        }
    }

    public void EnemyMove()
    {
        if (_isMoving)
            _enemyTo.position = new Vector3(_enemyTo.position.x - Time.deltaTime * EnemySpeed, _enemyTo.position.y);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            _isMoving = false;
            _towerUnit = other.GetComponent<TowerUnit>();
            _isInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            _isInRange = false;
        }
    }

    public void TakeDame(float dame)
    {
        _hpCurrent -= dame;
        if (_hpCurrent <= 0)
        {
            _hpCurrent = 0;
            Destroy(gameObject);
            return;
        }

        hpBar.UpdateHp(_hpCurrent / EnemyMaxHp);
    }
}
