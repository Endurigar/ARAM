using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private List<ItemInfo> items;
    public IItem SelectedItem;
    private bool playerInShopArea = false;
    private bool playerClicked = false;
    private Vector3 lastDestination;
    private Hero hero;

    public List<ItemInfo> Items => items;

    private void Start()
    {
       InitItems(shopGrid, items);
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
                InitItems(inventoryGrid, hero.Bag);
                shopMenu.SetActive(true);
            }
            playerInShopArea = true;
        }
    }
    
    private void InitItems(Transform grid, List<IItem> items)
    {
        foreach (ItemInfo t in items)
        {
            var newLevelButton = Instantiate(t.Icon, grid); 
            newLevelButton.GetComponent<ItemIcon>().SetItemInfo(t,this);
        }
    }
    private void InitItems(Transform grid, List<ItemInfo> items)
    {
        foreach (ItemInfo t in items)
        {
            var newLevelButton = Instantiate(t.Icon, grid); 
            newLevelButton.GetComponent<ItemIcon>().SetItemInfo(t,this);
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
        var newLevelButton = Instantiate(SelectedItem.Icon, inventoryGrid); 
        newLevelButton.GetComponent<ItemIcon>().SetItemInfo(SelectedItem,this);
        hero.AddItem(SelectedItem);
    }
    public void BuyItem(IItem item)
    {
        var newLevelButton = Instantiate(SelectedItem.Icon, inventoryGrid); 
        newLevelButton.GetComponent<ItemIcon>().SetItemInfo(SelectedItem,this);
        hero.AddItem(SelectedItem);
    }

    public void SellItem()
    {
        hero.RemoveItem(SelectedItem);
    }

    private void OnTriggerExit(Collider other)
    {
        shopMenu.SetActive(false);
    }
}
