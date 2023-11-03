using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shop : MonoBehaviour
{
    private bool playerInShopArea = false;
    private bool playerClicked = false;
    private Vector3 lastDestination;

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
                
            }
            playerInShopArea = true;
        }
    }
}
