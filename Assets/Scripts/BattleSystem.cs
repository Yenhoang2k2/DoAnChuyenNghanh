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
    [SerializeField] private HeroUnit heroUnit;
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
            heroUnit.UpdateUnit();
            if(spamEnemy.timeBatlle >= 0)
                spamEnemy.SpawnEnemy();
        }
    }
}
