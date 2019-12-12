using Character.Properties;
using System.Collections.Generic;

namespace Quests
{
    public abstract class BaseQuest: IQuest
    {
        public abstract List<IProperty> GetBenefits();
    }
}