using System.Collections.Generic;
using System.Linq;

namespace HsMercenaryStrategy
{
    public interface IStrategy
    {
        List<BattleTarget> GetBattleTargets(List<Mercenary> mercenaries,List<Target> targets);
        
        string Name();
    }

    public static class StrategyUtils
    {

        /**
         * 根据名称找佣兵
         */
        public static Mercenary FindMercenaryForName(string name,List<Mercenary> mercenaries)
        {
            return mercenaries.Find(m => m.Name.Contains(name) || name.Contains(m.Name));
        }
        
        /**
         * 根据名称找技能
         */
        public static Skill FindSkillForName(string name,Mercenary mercenary)
        {
            return mercenary.Skills.Find(s => s.Name.Contains(name) || name.Contains(s.Name));
        }

        /**
         * 找到速度最慢的敌人
         */
        public static Target FindSlowestTarget(List<Target> targetEntities)
        {
            if (targetEntities.Count == 0)
            {
                return null;
            }
            var speed = targetEntities.Max(i=>i.Speed);
            return targetEntities.Find(i => i.Speed == speed);
        }

        /**
         * 找到声明最高的敌人
         */
        public static Target FindMaxHealthTarget(List<Target> targetEntities)
        {
            if (targetEntities.Count == 0)
            {
                return null;
            }
            var health = targetEntities.Max(i=>i.Health);
            return targetEntities.Find(i => i.Health == health);
        }
    }

    public class Target
    {
        public int Id = -1;

        public string Name;

        public int Health;

        public int Speed;
    }


    public class BattleTarget
    {
        public int TargetId = -1;

        public int SkillId = -1;
    }

    public class Mercenary
    {
        public int Id = -1;

        public string Name;

        // ReSharper disable once CollectionNeverUpdated.Global
        public List<Skill> Skills;
    }

    public class Skill
    {
        public int Id = -1;
        
        public string Name;

        public int Speed;
    }  
}