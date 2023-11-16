using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private List<ItemInfo> items;
    private bool playerInShopArea = false;
    private bool playerClicked = false;
    private Vector3 lastDestination;
    private Hero hero;

    public List<ItemInfo> Items => items;

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
                shopMenu.SetActive(true);
            }
            playerInShopArea = true;
        }
    }

    public void BuyItem(IItem item)
    {
        hero.AddItem(item);
    }

    private void OnTriggerExit(Collider other)
    {
        shopMenu.SetActive(false);
    }
}
