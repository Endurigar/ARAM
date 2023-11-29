using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Button iconButton;
    [SerializeField] private GameObject frame;
    private EInventoryType inventoryType;
    private IItem item;
    private Shop shopMenu;

    private void Start()
    {
        iconButton.onClick.AddListener(SelectItem);
    }

    private void OnDisable()
    {
        frame.SetActive(false);
    }

    private void SelectItem()
    {
        
        switch (inventoryType)
        {
            case EInventoryType.HeroInventoryType:
                break;
            case EInventoryType.ShopInventoryType:
                frame.SetActive(!frame.activeSelf);
                shopMenu.SelectedItemInInventory = item;
                StartCoroutine(ItemSelected());
                break;
            case EInventoryType.ShopListType:
                frame.SetActive(!frame.activeSelf);
                shopMenu.SelectedItemInShop = item;
                StartCoroutine(ItemSelected());
                break;
        }
    }

    public void SetItemInfo(IItem item, Shop shopMenu, EInventoryType inventoryType)
    {
        this.inventoryType = inventoryType;
        this.shopMenu = shopMenu;
        this.item = item;
        itemName.text = this.item.Name;
    }

    IEnumerator ItemSelected()
    {
        var selectedItem = inventoryType == EInventoryType.ShopListType
            ? shopMenu.SelectedItemInShop
            : shopMenu.SelectedItemInInventory;
        yield return new WaitWhile((() =>
        {
            selectedItem = inventoryType == EInventoryType.ShopListType
                ? shopMenu.SelectedItemInShop
                : shopMenu.SelectedItemInInventory;
            return selectedItem == item;
        }));
        frame.SetActive(selectedItem ==item);
        yield break;
    }
}
