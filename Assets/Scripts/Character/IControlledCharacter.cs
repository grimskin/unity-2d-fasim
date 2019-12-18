using UnityEngine;

namespace Character
{
    public interface IControlledCharacter
    {
        string GetState();
        void SetState(string newState);

        void MoveTo(Vector2 moveTarget);

        void ContinueMovement();

        CharStateManager GetCharStateManager();
        
        Vector2 GetPosition();
    }
}