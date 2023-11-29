using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public interface IInventory
{
    public List<IItem> Bag { get; set; }
    public Action<IItem> OnAddItem{ get; set; }
    public Action<IItem> OnRemoveItem{ get; set; }
    public Action<IItem> OnUseItem{ get; set; }
    
    public bool AddItem(IItem item);
    public void RemoveItem(IItem item);
    protected void UseItem(IItem item);
}
