using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

enum State
{
    Busy,Battle
}
public class GameController : MonoBehaviour
{
    [SerializeField] private List<HeroUnit> heroUnits;
    [SerializeField] private SpamEnemy spamEnemy;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Button statrBattle;
    private State state;

    private void Awake()
    {
        statrBattle.onClick.AddListener(BattleBegin);
        state = State.Busy;
    }

    private void Update()
    {
        if (state == State.Battle)
        {
            for (int i = 0; i < heroUnits.Count; i++)
            {
                heroUnits[i].UpdateUnit();
            }
            if(spamEnemy.timeBatllCurent >= 0)
                spamEnemy.SpawnEnemy();
            if (spamEnemy.timeBatllCurent <= 0)
            {
                GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemys.Length <= 0)
                {
                    BattleEnd();
                }
            }
        }
        else if (state == State.Busy)
        {
            // Busy
        }
    }

    void BattleEnd()
    {
        state = State.Busy;
        uiManager.UiBusy();
        
    }

    void BattleBegin()
    {
        state = State.Battle;
        spamEnemy.SetUpPointSpawn();
        uiManager.UiBattle();
    }
    
}
