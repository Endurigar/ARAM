using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public string Name { get; set; }
    public float Cost { get; set; }
    public GameObject Icon { get; set; }
    public bool OwnedByPlayer { get; set; }

    public void UseItem();
}
