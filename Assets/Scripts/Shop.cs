using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Utilities;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private Transform shopGrid; 
    [SerializeField] private Transform inventoryGrid;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private NotificationList notificationList;
    [SerializeField] private List<ItemInfo> items;
    public IItem SelectedItemInShop;
    public IItem SelectedItemInInventory;
    private bool playerInShopArea = false;
    private bool playerClicked = false;
    private Vector3 lastDestination;
    private Hero hero;

    public List<ItemInfo> Items => items;

    private void Start()
    {
       InitItems(shopGrid, items, EInventoryType.ShopListType);
       buyButton.onClick.AddListener(BuyItem);
       sellButton.onClick.AddListener(SellItem);
    }

    public void OnPlayerClicked(Vector3 currentDestination)
    {
        lastDestination = currentDestination;
        playerClicked = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out var hero))
        {
            if (lastDestination == hero.MeshAgent.destination && playerClicked)
            {
                this.hero = hero;
                ClearGrid(inventoryGrid);
                InitItems(inventoryGrid, hero.Bag, EInventoryType.ShopInventoryType);
                shopMenu.SetActive(true);
            }
            playerInShopArea = true;
        }
    }
    
    private void InitItems(Transform grid, List<IItem> items, EInventoryType type)
    {
        foreach (ItemInfo t in items)
        {
            var newLevelButton = Instantiate(t.Icon, grid); 
            newLevelButton.GetComponent<ItemIcon>().SetItemInfo(t,this, type);
        }
    }
    private void InitItems(Transform grid, List<ItemInfo> items, EInventoryType type)
    {
        foreach (ItemInfo t in items)
        {
            var newLevelButton = Instantiate(t.Icon, grid); 
            newLevelButton.GetComponent<ItemIcon>().SetItemInfo(t,this, type);
        }
    }

    private void ClearGrid(Transform grid)
    {
        for (int i = 0; i<grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
    }

    public void BuyItem()
    {
        if(SelectedItemInShop==null)        
        {
            NotificationService.OnMessage(notificationList.GetNotificationByName("NotSelected"));
            return;
        }
        if (!hero.AddItem(SelectedItemInShop))
        {
            NotificationService.OnMessage(notificationList.GetNotificationByName("FailedToPurchase"));
            return;
        }
        var newLevelButton = Instantiate(SelectedItemInShop.Icon, inventoryGrid); 
        newLevelButton.GetComponent<ItemIcon>().SetItemInfo(SelectedItemInShop,this, EInventoryType.ShopInventoryType);
        NotificationService.OnMessage(notificationList.GetNotificationByName("SuccessfulPurchase"));
    }

    public void SellItem()
    {
        if (SelectedItemInInventory == null)
        {
            NotificationService.OnMessage(notificationList.GetNotificationByName("NotSelected"));
            return;
        }
        hero.RemoveItem(SelectedItemInInventory);
        SelectedItemInInventory = null;
        ClearGrid(inventoryGrid);
        InitItems(inventoryGrid, hero.Bag, EInventoryType.ShopInventoryType);
        NotificationService.OnMessage(notificationList.GetNotificationByName("SuccessfulSold"));
    }

    private void OnTriggerExit(Collider other)
    {
        shopMenu.SetActive(false);
        SelectedItemInShop = null;
        SelectedItemInInventory = null;
    }
}
