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
    public float timeBatlle;
    public float spawnNext;
    public int tt;

    public int levelBattle;
    
    public void SetUpPointSpawn()
    {
        timeBatlle +=levelBattle*0.1f;
        spawnNext = timeBatlle;
    }
    
    public void SpawnEnemy()
    {
        timeBatlle -= Time.deltaTime*1;
        if (timeBatlle > 0)
        {
            if (spawnNext >= timeBatlle)
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
                    tt = 1;
                spawnNext -= timeSpawn;
            }
        }
    }
    
}
