using System.Collections.Generic;
using Character;
using Character.Commands;
using Character.Properties;
using UnityEngine;

namespace Quests
{
    public class Wandering: BaseQuest
    {
        private bool _isCompleted = false;
        
        public override List<IProperty> GetCharacterEffects ()
        {
            return new List<IProperty>
            {
                new Boredom { Value = -5 },
                new Fatigue { Value = 2 }
            };
        }

        public override bool IsCompleted()
        {
            return _isCompleted;
        }

        public override void Finalize(IControlledCharacter character)
        {
            throw new System.NotImplementedException();
        }

        public override ICommand GetCommand(IControlledCharacter character)
        {
            var moveTarget = new Vector2();

            float randX = Random.Range (0, 4);
            if (randX < 1) {
                moveTarget.x = 1f;
            } else if (randX > 2) {
                moveTarget.x = 1f;
            }

            float randY = Random.Range (0, 4);
            if (randY < 1) {
                moveTarget.y = 1f;
            } else if (randX > 2) {
                moveTarget.y = 1f;
            }

            var result = new MoveOneCell();
            result.SetDirection(moveTarget);

            _isCompleted = true;
            
            return result;
        }
    }
}
