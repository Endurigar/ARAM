using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPawn
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public float Mana { get; set; }
    public float Speed { get; set; }
    public float Damage{ get; set; }
    public float MagicDamage { get; set; }
    public float Armor { get; set; }
    public float MagicResist { get; set; }
    public float Experience { get; set; }
    public uint Level { get; set; }

    public void Move(Vector3 targetPoint);
    public void TakeDamage(float damage, float magicDamage);
    public void Attack(IPawn target);
    public void Death();

    public void AddExperience(float experience);
    public void LevelUp();
}
