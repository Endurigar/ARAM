using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Pawn : MonoBehaviour, IPawn
{
    [SerializeField] private NotificationList notificationList;
    [SerializeField] protected BaseAnimator baseAnimator;
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public float MaxMana { get; set; }
    public float CurrentMana { get; set; }
    public float Mana { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    public float MagicDamage { get; set; }
    public float Armor { get; set; }
    public float MagicResist { get; set; }
    public float Experience { get; set; }
    public uint Level { get; set; }
    public NavMeshAgent MeshAgent { get; private set; }

    private void Start()
    {
        Level = 1;
        MeshAgent = GetComponent<NavMeshAgent>();
    }

    protected void Update()
    {
        baseAnimator.SetSpeed(Speed);
    }

    public void Move(Vector3 targetPoint)
    {
        MeshAgent.destination = targetPoint;
    }

    public void TakeDamage(float damage, float magicDamage)
    {
        CurrentHealth -= damage - Armor;
        CurrentHealth -= magicDamage - MagicResist;
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    public void Attack(IPawn target)
    {
        target.TakeDamage(Damage,MagicDamage);
        baseAnimator.Attack();
    }

    public void Death()
    {
        baseAnimator.Death();
    }

    public void AddExperience(float experience)
    {
        Experience += experience;
    }
    
    public void LevelUp()
    {
        if(Level > LevelsDictionary.Levels.Count-1) return;
        if (Experience >= LevelsDictionary.Levels[Level + 1])
        {
            Level++;
            NotificationService.OnMessage(notificationList.GetNotificationByName("LevelUp"));
        }
    }
}
