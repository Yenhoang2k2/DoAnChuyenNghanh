using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class TowerUnit : MonoBehaviour
{
    [SerializeField] private Image health;
    [SerializeField] private Text healthText;
    private int hp;
    private float hpCurrent;
    [SerializeField] private int level;
    [SerializeField] private int price;

    private void Start()
    {
        hpCurrent = MaxHp;
        UpdateHp();
    }

    public int Level
    {
        get { return level; }
    }

    public float MaxHp
    {
        get { return hp + ( level * 200); }
    }
    public int Price
    {
        get { return price + ( level * 200); }
    }

    public void UpdateHp()
    {
        health.fillAmount = hpCurrent / MaxHp;
        healthText.text = hpCurrent.ToString();
    }

    public bool TakeDame(float dame)
    {
        hpCurrent -= dame;
        UpdateHp();
        if (hpCurrent <= 0)
        {
            hpCurrent = 0;
            healthText.text = hpCurrent.ToString();
            return true;
        }

        return false;
    }
}