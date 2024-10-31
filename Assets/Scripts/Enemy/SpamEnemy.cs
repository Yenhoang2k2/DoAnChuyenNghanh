using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SpamEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyUnit;
    [SerializeField] private List<EnemyBase> enemyBases;
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private int timeSpawn;
    [SerializeField] private float timeBatlle;
    public float timeBatllCurent;
    public float spawnNext;
    private int tt;

    public int levelBattle;
    public float TimeBatlle
    {
        get { return timeBatlle +(levelBattle*0.2f); }
    }
    
    public void SetUpPointSpawn()
    {
        tt = 0;
        timeBatllCurent = TimeBatlle;
        spawnNext = TimeBatlle;
    }
    
    public void SpawnEnemy()
    {
        timeBatllCurent -= Time.deltaTime*1;
        if (timeBatllCurent > 0)
        {
            if (spawnNext >= timeBatllCurent)
            {
                for (int i = 0; i < spawnPoints.Count -1; i++)
                {
                    var temporary = Instantiate(enemyUnit, spawnPoints[i].transform);
                    EnemyUnit enemyUnitCurrent = temporary.GetComponent<EnemyUnit>();
                    SpriteRenderer spriteRenderer = temporary.GetComponent<SpriteRenderer>();
                    enemyUnitCurrent.AttackSpeed = enemyBases[tt].AttackSpeed;
                    enemyUnitCurrent.EnemyAttack = enemyBases[tt].AttackCurrent(levelBattle);
                    enemyUnitCurrent.EnemySpeed = enemyBases[tt].Speed;
                    enemyUnitCurrent.EnemyMaxHp = enemyBases[tt].HpCurrent(levelBattle);
                    spriteRenderer.sprite = enemyBases[tt].Sprite;
                }
                tt++;
                if (tt >= enemyBases.Count)
                    tt = 0;
                spawnNext -= timeSpawn;
            }
        }
    }
}
