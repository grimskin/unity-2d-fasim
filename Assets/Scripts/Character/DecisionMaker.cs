using System;
using System.Collections.Generic;
using System.Linq;
using Character.Properties;
using Quests;

namespace Character
{
    class QuestComparer: IComparer<IQuest>
    {
        public IProperty Need { get; set; }

        public int Compare(IQuest x, IQuest y)
        {
            if (x == null || y == null) return 0;

            return x.GetBenefitForNeedAbs(Need) > y.GetBenefitForNeedAbs(Need) ? 1 : -1;
        }
    }

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

        public IQuest PickAQuest(IProperty need)
        {
            var quests = _questManager.GetQuestsForNeed(need);
            var sorter = new QuestComparer() { Need = need };
            quests.Sort(sorter);
            return Activator.CreateInstance(quests.First().GetType()) as IQuest;
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