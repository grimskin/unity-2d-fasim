using System.Collections.Generic;
using Character.Properties;

namespace Quests
{
    public class Wandering: BaseQuest
    {
        public override List<IProperty> GetCharacterEffects ()
        {
            return new List<IProperty>
            {
                new Boredom { Value = -5 },
                new Fatigue { Value = 2 }
            };
        }
    }
}
