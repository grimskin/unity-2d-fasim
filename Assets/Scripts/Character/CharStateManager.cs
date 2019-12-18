using Character.Properties;
using System.Collections.Generic;

namespace Character
{
    public class CharStateManager
    {
        private readonly CharState _stateSheet;
        
        public CharStateManager(CharState stateSheet)
        {
            _stateSheet = stateSheet;
        }

        public void ChangeProperty(IProperty relativeChange)
        {
            if (relativeChange.GetName() == "Boredom")
            {
                _stateSheet.Boredom.Value += relativeChange.GetValue();
                GameLogger.Log(relativeChange.GetName() + " level now is " + _stateSheet.Boredom.GetValue());
            }
            if (relativeChange.GetName() == "Fatigue")
            {
                _stateSheet.Fatigue.Value += relativeChange.GetValue();
                GameLogger.Log(relativeChange.GetName() + " level now is " + _stateSheet.Fatigue.GetValue());
            }
        }

        public List<IProperty> GetNeeds()
        {
            return new List<IProperty>
            {
                _stateSheet.Boredom,
                _stateSheet.Fatigue
            };
        }
    }
}