using System.Collections.Generic;
using System.Linq;
using Character.Properties;
using Quests;

namespace Character
{
    public class DecisionMaker
    {
        private CharSheet _charSheet;
        private CharStateManager _charStateManager;
        private QuestManager _questManager;
        
        public DecisionMaker(CharSheet charSheet, CharStateManager charStateManager, QuestManager questManager)
        {
            _charSheet = charSheet;
            _charStateManager = charStateManager;
            _questManager = questManager;
        }

        public IQuest PickAQuest()
        {
            return null;
        }

        public IProperty GetBiggestNeed()
        {
            var needs = _charStateManager.GetNeeds();
            
            return needs.Aggregate((curMin, x) => (x.GetNormalizedValue() < curMin.GetNormalizedValue()
                ? x
                : curMin));
        }
    }
}