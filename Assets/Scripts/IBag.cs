using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBag
{
    protected List<IItem> Bag { get; set; }

    protected void AddItem(IItem item);
    protected void RemoveItem(IItem item);
    protected void UseItem(IItem item);
}
