using Character.Properties;
using System.Collections.Generic;

namespace Quests
{
    public interface IQuest
    {
        List<IProperty> GetBenefits();
    }
}