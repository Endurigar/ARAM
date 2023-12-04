using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public abstract class Skill : MonoBehaviour, ISkill
{
    public int ManaCost { get; set; }
    public float Countdown { get; set; }
    public Texture2D Image { get; set; }
    public string Description { get; set; }
    public int SkillLevel { get; set; }
    public int MaxSkillLevel { get; set; }
    
    public virtual void UseSkill(IPawn pawn)
    {
        throw new System.NotImplementedException();
    }
}
