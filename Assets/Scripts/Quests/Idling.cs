using System.Collections.Generic;
using Character.Properties;

namespace Quests
{
    public class Idling: BaseQuest
    {
        public override List<IProperty> GetBenefits()
        {
            return new List<IProperty>
            {
                PropFactory.GetPropByName("Fatigue")
            };
        }
    }
}