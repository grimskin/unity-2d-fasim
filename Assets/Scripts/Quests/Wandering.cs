using System.Collections.Generic;
using Character.Properties;

namespace Quests
{
    public class Wandering: BaseQuest
    {
        public override List<IProperty> GetBenefits()
        {
            return new List<IProperty>
            {
                PropFactory.GetPropByName("Boredom")
            };
        }
    }
}
