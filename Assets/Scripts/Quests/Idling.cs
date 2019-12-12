using System.Collections.Generic;
using Character.Properties;

namespace Quests
{
    public class Idling: BaseQuest
    {
        public override Dictionary<string, int> GetCharacterEffects ()
        {
            return new Dictionary<string, int>
            {
                {"Fatigue", 2}
            };
        }

        public List<IProperty> GetBenefits()
        {
            return new List<IProperty>
            {
                PropFactory.GetPropByName("Fatigue")
            };
        }
    }
}