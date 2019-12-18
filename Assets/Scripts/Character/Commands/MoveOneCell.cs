using UnityEngine;

namespace Character.Commands
{
    public class MoveOneCell: BaseCommand
    {
        private Vector2 _direction;
        private Vector2 _moveTarget;
        private IControlledCharacter _character;
        private bool _isInProgress;
        
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public override bool IsCompleted()
        {
            return _character.GetState() == CharState.StateIdle;
        }

        public override void invokeOn(IControlledCharacter character)
        {
            if (_isInProgress)
            {
                character.ContinueMovement();
                return;
            }

            _character = character;
            
            var currentPosition = _character.GetPosition();
            _moveTarget = new Vector2 { x = currentPosition.x + _direction.x, y = currentPosition.y + _direction.y};
            
            _character.MoveTo(_moveTarget);
            _character.SetState(CharState.StateMoving);
            _isInProgress = true;
        }
    }
}