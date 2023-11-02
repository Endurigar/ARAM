using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Pawn : MonoBehaviour, IPawn
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public float Mana { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    public float MagicDamage { get; set; }
    public float Armor { get; set; }
    public float MagicResist { get; set; }
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 targetPoint)
    {
        navMeshAgent.destination = targetPoint;
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
    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }
}
