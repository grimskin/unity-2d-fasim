using UnityEngine;

namespace Character.Commands
{
    public class MoveOneCell: BaseCommand
    {
        private Vector2 _direction;
        private Vector2 _moveTarget;
        private IControlledCharacter _character;
        private const float Epsilon = 0.01f;
        private bool _isInProgress;
        
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public override bool IsCompleted()
        {
            return _destinationReached();
        }

        private bool _destinationReached()
        {
            var position = _character.GetPosition();

            return ((System.Math.Abs(_moveTarget.x - position.x) > Epsilon)
                    || (System.Math.Abs(_moveTarget.y - position.y) > Epsilon));
        }

        public override void invokeOn(IControlledCharacter character)
        {
            if (_isInProgress) return;

            _character = character;
            GameLogger.Log("move direction is " + _direction.x + "," + _direction.y);
            
            var currentPosition = _character.GetPosition();
            _moveTarget = new Vector2 { x = currentPosition.x + _direction.x, y = currentPosition.y + _direction.y};
            

            GameLogger.Log("command move to " + _moveTarget.x + "," + _moveTarget.y);
            
            _character.MoveTo(_moveTarget);
            _character.SetState(CharState.StateMoving);
            _isInProgress = true;
        }
    }
}