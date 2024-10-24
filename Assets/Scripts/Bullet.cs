using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Bullet : MonoBehaviour
{
    
    private GameObject taget;
    private Vector3 tagetPos;
    
    public float DameBullet { get; set; }
    public float BulletSpeed { get; set; }
    
    private void Awake()
    {
        BulletTo();
    }

    private void Update()
    {
        DetroyBullet();
        BulletMove();
    }

    public void BulletMove()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, tagetPos, BulletSpeed * Time.deltaTime);
    }
    public void BulletTo()
    {
        float closestDistance = Mathf.Infinity;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys != null)
        {
            foreach (var enemy in enemys)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy <= closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    taget = enemy;
                    tagetPos = taget.transform.position;
                }
            }
            if (taget == null)
            {
                Destroy(gameObject);
            }
        }
    }
    public void DetroyBullet()
    {
        if (Vector3.Distance(transform.position, tagetPos) <= 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
