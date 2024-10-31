using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiAttack;
    [SerializeField] private GameObject uiListHero;
    [SerializeField] private GameObject uiInformation;

    public void UiBattle()
    {
        uiAttack.SetActive(false);
        uiListHero.SetActive(false);
        uiInformation.SetActive(false);
    }

    public void UiBusy()
    {
        uiAttack.SetActive(true);
        uiListHero.SetActive(true);
        uiInformation.SetActive(true);
    }
}
