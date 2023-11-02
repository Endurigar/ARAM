using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Pawn, IBag
{
    protected float gold;
    private List<IItem> bag;
    List<IItem> IBag.Bag
    {
        get => bag;
        set => bag = value;
    }

    void IBag.AddItem(IItem item)
    {
        if (item.Cost <= gold)
        {
            bag.Add(item);
            gold -= item.Cost;   
        }
    }

    void IBag.RemoveItem(IItem item)
    {
        gold += item.Cost / 2;
        bag.Remove(item);
    }

    void IBag.UseItem(IItem item)
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
        }
    }
}
