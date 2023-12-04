using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private const string SpeedName = "speed";
    private const string AttackName = "attack";
    private const string DeathName = "death";
    private const string QSkillName = "qSkill";
    private const string WSkillName = "wSkill";
    private const string ESkillName = "eSkill";
    private const string RSkillName = "rSkill";

    public void SetSpeed(float speed)
    {
        animator.SetFloat(SpeedName,speed);
    }

    public void Attack()
    {
        animator.SetTrigger(AttackName);
    }
    
    public void Death()
    {
        animator.SetTrigger(DeathName);
    }
    
    public void QSkill()
    {
        animator.SetTrigger(QSkillName);
    }
    
    public void WSkill()
    {
        animator.SetTrigger(WSkillName);
    }
    
    public void ESkill()
    {
        animator.SetTrigger(ESkillName);
    }
    
    public void RSkill()
    {
        animator.SetTrigger(RSkillName);
    }
}
