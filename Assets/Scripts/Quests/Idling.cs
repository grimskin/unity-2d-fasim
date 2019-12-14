using System.Collections.Generic;
using Character.Properties;

namespace Quests
{
    public class Idling : BaseQuest
    {
        public override List<IProperty> GetCharacterEffects()
        {
            return new List<IProperty>
            {
                new Fatigue { Value = -5 },
                new Boredom { Value = 1 }
            };
        }
    }
}