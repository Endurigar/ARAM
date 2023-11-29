using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public abstract class Hero : Pawn, IInventory
{
    protected float gold = 1000;
    private List<IItem> bag = new List<IItem>();
    List<IItem> IInventory.Bag
    {
        get => bag;
        set => bag = value;
    }
    public List<IItem> Bag => bag;

    public Action<IItem> OnAddItem { get; set; }
    public Action<IItem> OnRemoveItem { get; set; }
    public Action<IItem> OnUseItem { get; set; }

    public bool AddItem(IItem item)
    {
        if (item.Cost <= gold && bag.Count < 6)
        {
            OnAddItem(item);
            bag.Add(item);
            item.OwnedByPlayer = true;
            gold -= item.Cost;
            return true;
        }
        return false;
    }

    public void RemoveItem(IItem item)
    {
        gold += item.Cost / 2;
        bag.Remove(item);
    }

    void IInventory.UseItem(IItem item)
    {
        item.UseItem();
    }

    protected virtual void OnPressQ()
    {
        
    }
    
    protected virtual void OnPressW()
    {
        
    }
    
    protected virtual void OnPressE()
    {
        
    }
    
    protected virtual void OnPressR()
    {
        
    }

    protected virtual void OnMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
        {
            Move(hit.point);
            if (hit.transform.TryGetComponent<Shop>(out var shop))
            {
                shop.OnPlayerClicked(MeshAgent.destination);
            }
        }
    }
}
