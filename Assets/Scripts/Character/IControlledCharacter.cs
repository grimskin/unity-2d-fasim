using UnityEngine;

namespace Character
{
    public interface IControlledCharacter
    {
        string GetState();
        void SetState(string newState);
        
        Vector2 GetPosition();
    }
}