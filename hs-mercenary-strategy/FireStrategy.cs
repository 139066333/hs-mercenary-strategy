using System.Collections.Generic;

namespace HsMercenaryStrategy
{
    public class FireStrategy: IStrategy
    {
        public List<BattleTarget> GetBattleTargets(List<Mercenary> mercenaries, List<Target> targets)
        {

            var battleTargetEntities = new List<BattleTarget>();
            
            // 点火攻击血量最高的怪
            Mercenary fireUp = StrategyUtils.FindMercenaryForName("安东尼", mercenaries) ??  
                                     StrategyUtils.FindMercenaryForName("赤精", mercenaries) ??  
                                     StrategyUtils.FindMercenaryForName("巴琳达", mercenaries);
            Target maxHealthTarget = StrategyUtils.FindMaxHealthTarget(targets);
            if (fireUp != null)
            {
                battleTargetEntities.Add( new BattleTarget() {
                    TargetId = maxHealthTarget?.Id ?? -1,
                    SkillId =  StrategyUtils.FindSkillForName("火球", fireUp)?.Id ?? 
                               StrategyUtils.FindSkillForName("烈焰之歌", fireUp)?.Id ??
                               StrategyUtils.FindSkillForName("烈焰之刺", fireUp)?.Id ?? -1
                });
            } 


            // 嘉顿
            // ReSharper disable once IdentifierTypo
            var geddon = StrategyUtils.FindMercenaryForName("迦顿", mercenaries);
            if (geddon != null)
            {
                battleTargetEntities.Add( new BattleTarget() {
                    SkillId =  StrategyUtils.FindSkillForName("地狱火", geddon)?.Id  ?? -1
                });
            }

            // 螺丝
            // ReSharper disable once IdentifierTypo
            var ragnaros = StrategyUtils.FindMercenaryForName("拉格纳罗斯", mercenaries);
                
            if (ragnaros != null)
            {
                battleTargetEntities.Add( new BattleTarget() {
                    SkillId =  StrategyUtils.FindSkillForName("死吧，虫子", ragnaros)?.Id  ?? -1
                });
            }
        
            
            // 如果有水元素，用水元素冻住速度最慢的敌人
            var water = StrategyUtils.FindMercenaryForName("水元素",mercenaries);
            if (water != null)
            {
                // 找到水元素的技能
                var attack = StrategyUtils.FindSkillForName("攻击",water);

                // 找到最慢的敌人
                var slowestTarget = StrategyUtils.FindSlowestTarget(targets);
                
                battleTargetEntities.Add( new BattleTarget() {
                    TargetId = slowestTarget?.Id ?? -1,
                    SkillId =  attack?.Id ?? -1
                });
            }
            
            return battleTargetEntities;
        }

        public string Name()
        {
            return "PVE火焰队策略";
        }
    }
}