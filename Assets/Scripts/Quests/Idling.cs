using System.Collections.Generic;
using Character;
using Character.Commands;
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

        public override bool IsCompleted()
        {
            throw new System.NotImplementedException();
        }

        public override void Finalize(IControlledCharacter character)
        {
            throw new System.NotImplementedException();
        }

        public override ICommand GetCommand(IControlledCharacter character)
        {
            throw new System.NotImplementedException();
        }
    }
}