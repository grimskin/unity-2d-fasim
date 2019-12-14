using System;
using Character.Properties;
using System.Collections.Generic;
using System.Linq;

namespace Quests
{
    public abstract class BaseQuest: IQuest
    {
        public List<IProperty> GetCharacterBenefits()
        {
            return (
                from effect 
                    in GetCharacterEffects() 
                where (!effect.IsInverted() && effect.GetValue() > 0) 
                      || (effect.IsInverted() && effect.GetValue() < 0)
                select effect
                ).ToList();
        }

        public List<IProperty> GetCharacterDrawbacks()
        {
            return (
                from effect 
                    in GetCharacterEffects() 
                where (!effect.IsInverted() && effect.GetValue() < 0) 
                      || (effect.IsInverted() && effect.GetValue() > 0)
                select effect
                ).ToList();
        }

        public abstract List<IProperty> GetCharacterEffects();

        public int GetBenefitForNeedAbs(IProperty need)
        {
            return (
                from effect
                    in GetCharacterBenefits()
                where effect.GetName() == need.GetName()
                select Math.Abs(effect.GetValue())
                ).DefaultIfEmpty(0).First();
        }
    }
}