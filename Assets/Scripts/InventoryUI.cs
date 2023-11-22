using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Hero hero;
    void Start()
    {
        hero.OnAddItem += ItemAdded;
    }

    private void ItemAdded(IItem item)
    {
        Instantiate(item.Icon, transform);
    }
}
