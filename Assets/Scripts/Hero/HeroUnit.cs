using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroUnit : MonoBehaviour
{
    [SerializeField] private HeroBase heroBase;
    [SerializeField] private int level;
    
    [SerializeField] private GameObject poitShoot;
    [SerializeField] private GameObject bullet;
    private GameObject[] enemys;
    public float timeWait;
    public Hero Hero { get; set; }
    private void Start()
    {
        SetUnit();
        SpriteRenderer image = GetComponent<SpriteRenderer>();
        image.sprite = Hero.HeroBase.Sprite;
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
            FindEnemyAndShoot();
            timeWait = 0f;
        }
    }
    public void FindEnemyAndShoot()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length != 0)
        {
            var temporary = Instantiate(bullet, poitShoot.transform);
            Bullet a = temporary.GetComponent<Bullet>();
            SpriteRenderer spriteRenderer = temporary.GetComponent<SpriteRenderer>();
            var bu = Hero.HeroBase.Bullet;
            spriteRenderer.sprite = bu.GetComponent<SpriteRenderer>().sprite;
            a.DameBullet = Hero.Attack;
            a.BulletSpeed = heroBase.BulletSpeed;
        }
    }
}
