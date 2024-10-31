using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInformation : MonoBehaviour
{
    public static UiInformation intance;
    [SerializeField] Image avatar;
    [SerializeField] Text nameText;
    [SerializeField] Text priceText;
    [SerializeField] Text levelText;
    
    public Image Avatar
    {
        get { return avatar; }
    }
    
    public Text NameText
    {
        get { return nameText; }
    }
    public Text PriceText
    {
        get { return priceText; }
    }
    public Text LevelText
    {
        get { return levelText; }
    }
}
