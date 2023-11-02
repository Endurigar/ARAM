using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public float Cost { get; set; }
    public void UseItem();
}
