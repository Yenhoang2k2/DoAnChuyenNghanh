using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] private GameObject health;
    
    public void SetHp()
    {
        health.transform.localPosition = new Vector3(0,0.4f);
        health.transform.localScale = new Vector3(0.5f,0.05f);
    }

    public void UpdateHp(float hpCurrent)
    {
        health.transform.localPosition = new Vector3((0.5f-(hpCurrent*0.5f))/2,0.4f);
        health.transform.localScale = new Vector3(hpCurrent*0.5f,0.05f);
    }
}
