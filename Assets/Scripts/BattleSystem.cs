using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

enum State
{
    Busy,Battle
}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] private List<HeroUnit> heroUnits;
    [SerializeField] private SpamEnemy spamEnemy;
    private State state;

    private void Awake()
    {
        spamEnemy.SetUpPointSpawn();
        state = State.Battle;
    }

    private void Update()
    {
        if (state == State.Battle)
        {
            for (int i = 0; i < heroUnits.Count; i++)
            {
                heroUnits[i].UpdateUnit();
            }
            if(spamEnemy.timeBatlle >= 0)
                spamEnemy.SpawnEnemy();
        }
    }
}
