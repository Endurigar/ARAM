using UnityEngine;

namespace Interfaces
{
    public interface ISkill
    {
        public int ManaCost { get; set; }
        public float Countdown { get; set; }
        public Texture2D Image { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        public int MaxSkillLevel { get; set; }

        public void UseSkill(IPawn pawn);
        
    }
}
