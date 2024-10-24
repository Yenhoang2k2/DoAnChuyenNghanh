using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUnit : MonoBehaviour
{
    [SerializeField] private HeroBase heroBase;
    [SerializeField] private int level;
    
    [SerializeField] private GameObject poitShoot;
    [SerializeField] private GameObject bullet;
    
    public float timeWait;
    public Hero Hero { get; set; }
    private void Start()
    {
        SetUnit();
        Sprite image = GetComponent<Sprite>();
        image = Hero.HeroBase.Sprite;
    }

    public void SetUnit()
    {
        Hero = new Hero(heroBase, level);
    }
    public void UpdateUnit()
    {
        ResetWaitAttack();
    }

    public void ResetWaitAttack()
    {
        timeWait += Time.deltaTime;
        if (timeWait > Hero.HeroBase.AttackSpeed)
        {
            FindEnemy();
            timeWait = 0f;
        }
    }
    public void FindEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys != null)
        {
            var temporary = Instantiate(bullet, poitShoot.transform);
            Bullet a = temporary.GetComponent<Bullet>();
            a.DameBullet = Hero.Attack;
            a.BulletSpeed = heroBase.BulletSpeed;
        }
    }
}
