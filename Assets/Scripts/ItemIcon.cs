using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Button iconButton;
    private IItem item;
    private Shop shopMenu;

    private void Start()
    {
        iconButton.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        shopMenu.BuyItem(item);
    }

    public void SetItemInfo(IItem item, Shop shopMenu)
    {
        this.shopMenu = shopMenu;
        this.item = item;
        itemName.text = this.item.Name;
    }
}
