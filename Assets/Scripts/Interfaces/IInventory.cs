using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public interface IInventory
{
    protected List<IItem> Bag { get; set; }
    public Action<IItem> OnAddItem{ get; set; }
    public Action<IItem> OnRemoveItem{ get; set; }
    public Action<IItem> OnUseItem{ get; set; }
    
    public void AddItem(IItem item);
    protected void RemoveItem(IItem item);
    protected void UseItem(IItem item);
}
