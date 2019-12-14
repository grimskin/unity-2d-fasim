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