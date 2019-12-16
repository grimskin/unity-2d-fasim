using UnityEngine;

namespace Character.Commands
{
    public class MoveOneCell: BaseCommand
    {
        private Vector2 _direction;

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public override bool IsCompleted()
        {
            throw new System.NotImplementedException();
        }

        public override void invokeOn(IControlledCharacter character)
        {
            throw new System.NotImplementedException();
        }
    }
}