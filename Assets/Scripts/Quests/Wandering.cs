using System.Collections.Generic;
using Character.Properties;

namespace Quests
{
    public class Wandering: BaseQuest
    {
        public override Dictionary<string, int> GetCharacterEffects ()
        {
            return new Dictionary<string, int>
            {
                {"Boredom", 1}
            };
        }
    }
}
