using System.Collections.Generic;
using Character;
using Character.Commands;
using Character.Properties;

namespace Quests
{
    public class Idling : BaseQuest
    {
        private const int BoredomEffect = 1;
        private const int FatigueEffect = -5;

        public override List<IProperty> GetCharacterEffects()
        {
            return new List<IProperty>
            {
                new Fatigue { Value = FatigueEffect },
                new Boredom { Value = BoredomEffect }
            };
        }

        public override bool IsCompleted()
        {
            return true;
        }

        public override void Finalize(IControlledCharacter character)
        {
            var manager = character.GetCharStateManager();
            manager.ChangeProperty(new Boredom { Value = BoredomEffect });
            manager.ChangeProperty(new Fatigue { Value = FatigueEffect });
        }

        public override ICommand GetCommand(IControlledCharacter character)
        {
            var result = new DoNothing();

            result.SetDuration(30);

            return result;
        }
    }
}