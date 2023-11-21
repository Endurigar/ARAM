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
    [SerializeField] private List<ItemInfo> items;
    private bool playerInShopArea = false;
    private bool playerClicked = false;
    private Vector3 lastDestination;
    private Hero hero;

    public List<ItemInfo> Items => items;

    private void Start()
    {
       InitItems(shopGrid, items);
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
                InitItems(inventoryGrid, hero.GetComponent<Test>().items);
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

    public void BuyItem(ItemInfo item)
    {
        hero.AddItem(item);
    }

    private void OnTriggerExit(Collider other)
    {
        shopMenu.SetActive(false);
    }
}
