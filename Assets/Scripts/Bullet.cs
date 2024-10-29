using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private int timeX;
    private List<TagetvsRange> tagets;
    private GameObject taget;
    private Vector3 tagetPos;
    private float timeBegin;
    
    public float DameBullet { get; set; }
    public float BulletSpeed { get; set; }
    
    private void Awake()
    {
        tagets = new List<TagetvsRange>();
        BulletTo();
    }

    private void Update()
    {
        BulletMove();
        RunDetroy();
    }

    public void BulletMove()
    {
        if (taget != null)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, taget.transform.position, BulletSpeed * Time.deltaTime);
            tagetPos = taget.transform.position;
            DetroyBullet();
        }
        else
        {
            transform.position =
                Vector3.MoveTowards(transform.position, tagetPos, BulletSpeed * Time.deltaTime);
        }
    }
    public void BulletTo()
    {
        float closestDistance = Mathf.Infinity;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length != 0)
        {
            foreach (var enemy in enemys)
            {
 
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                TagetvsRange tagetvsRange = new TagetvsRange(enemy, distanceToEnemy);
                tagets.Add(tagetvsRange);
            }
            // hàm sắp xếp có sẵn
            tagets.Sort((a, b) => a.DistanceToEnemy.CompareTo(b.DistanceToEnemy));
            int ran = tagets.Count >= 3 ? Random.Range(0, 3) : 0;
            taget = tagets[ran].Taget;
        }
    }
    public void DetroyBullet()
    {
        if (Vector3.Distance(transform.position, tagetPos) <= 0.1f)
        {
            Destroy(gameObject);
            if (taget != null)
            {
                taget.GetComponent<EnemyUnit>().TakeDame(DameBullet);
            }
        }
    }

    public void RunDetroy()
    {
        timeBegin += Time.deltaTime;
        if (timeBegin >= timeX)
        {
            Destroy(gameObject);
        }
    }
    public Sprite Sprite
    {
        get { return sprite; }
    }
}

class TagetvsRange
{
    public GameObject Taget { get; set; }
    public float DistanceToEnemy { get; set; }

    public TagetvsRange(GameObject taget,float distanceToEnemy)
    {
        Taget = taget;
        DistanceToEnemy = distanceToEnemy;
    }
    
}
