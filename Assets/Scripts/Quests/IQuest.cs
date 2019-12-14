using Character.Properties;
using System.Collections.Generic;

namespace Quests
{
    public interface IQuest
    {
        List<IProperty> GetCharacterBenefits();
        List<IProperty> GetCharacterDrawbacks();

        List<IProperty> GetCharacterEffects();

        int GetBenefitForNeedAbs(IProperty need);
    }
}