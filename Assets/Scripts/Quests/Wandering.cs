using System.Collections.Generic;
using Character;
using Character.Commands;
using Character.Properties;
using UnityEngine;

namespace Quests
{
    public class Wandering: BaseQuest
    {
        private bool _isCompleted;
        private const int BoredomEffect = -5;
        private const int FatigueEffect = 2;
        
        public override List<IProperty> GetCharacterEffects ()
        {
            return new List<IProperty>
            {
                new Boredom { Value = BoredomEffect },
                new Fatigue { Value = FatigueEffect }
            };
        }

        public override bool IsCompleted()
        {
            return _isCompleted;
        }

        public override void Finalize(IControlledCharacter character)
        {
            var manager = character.GetCharStateManager();
            manager.ChangeProperty(new Boredom { Value = BoredomEffect });
            manager.ChangeProperty(new Fatigue { Value = FatigueEffect });
        }

        public override ICommand GetCommand(IControlledCharacter character)
        {
            var moveTarget = new Vector2();

            float randX = Random.Range (0, 3);
            moveTarget.x = randX < 2 ? 1f : -1f;

            float randY = Random.Range (0, 3);
            moveTarget.y = randY < 2 ? 1f : -1f;

            var result = new MoveOneCell();
            result.SetDirection(moveTarget);

            _isCompleted = true;
            
            return result;
        }
    }
}
