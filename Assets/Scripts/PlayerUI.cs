using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image mpBar;
    private void Update()
    {
        goldText.text = hero.gold.ToString();
        hpBar.fillAmount = hero.CurrentHealth/hero.MaxHealth;
        mpBar.fillAmount = hero.CurrentMana/hero.MaxMana;
    }
}
