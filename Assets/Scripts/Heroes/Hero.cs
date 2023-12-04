using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public abstract class Hero : Pawn, IInventory
{
    [SerializeField] private Skill qSkill;
    [SerializeField] private Skill wSkill;
    [SerializeField] private Skill eSkill;
    [SerializeField] private Skill rSkill;
    public float gold = 1000;
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
        qSkill.UseSkill(this);
        baseAnimator.QSkill();
    }
    
    protected virtual void OnPressW()
    {
        wSkill.UseSkill(this);
        baseAnimator.WSkill();
    }
    
    protected virtual void OnPressE()
    {
        eSkill.UseSkill(this);
        baseAnimator.ESkill();
    }
    
    protected virtual void OnPressR()
    {
        rSkill.UseSkill(this);
        baseAnimator.RSkill();
    }

    public void UpSkill(ESkillHotKey skillHotKey)
    {
        switch (skillHotKey)
        {
            case ESkillHotKey.Q:
                qSkill.SkillLevel++;
                break;
            case ESkillHotKey.W:
                wSkill.SkillLevel++;
                break;
            case ESkillHotKey.E:
                eSkill.SkillLevel++;
                break;
            case ESkillHotKey.R:
                rSkill.SkillLevel++;
                break;
        }
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
