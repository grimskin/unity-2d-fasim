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
                where effect.Value > 0 
                select PropFactory.GetPropByName(effect.Key)
                ).ToList();
        }

        public List<IProperty> GetCharacterDrawbacks()
        {
            return (
                from effect 
                    in GetCharacterEffects() 
                where effect.Value < 0 
                select PropFactory.GetPropByName(effect.Key)
                ).ToList();
        }

        public abstract Dictionary<string, int> GetCharacterEffects();
    }
}