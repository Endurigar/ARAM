using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class ItemIconSpawner : MonoBehaviour
{
        [SerializeField] private Button itemButton;
        [SerializeField] private Shop shopMenu;

        private void Start()
        {
            ItemSpawner();
        }

        private void ItemSpawner()
        {
            foreach (ItemInfo t in shopMenu.Items)
            {
                var newLevelButton = Instantiate(itemButton, transform); 
                newLevelButton.GetComponent<ItemIcon>().SetItemInfo(t,shopMenu);
            }
        }
}
