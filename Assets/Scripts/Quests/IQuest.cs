using System;
using Character.Properties;
using System.Collections.Generic;
using Character;
using Character.Commands;

namespace Quests
{
    public interface IQuest
    {
        List<IProperty> GetCharacterBenefits();
        List<IProperty> GetCharacterDrawbacks();

        List<IProperty> GetCharacterEffects();

        int GetBenefitForNeedAbs(IProperty need);

        ICommand GetCommand(IControlledCharacter character);

        bool IsCompleted();

        void Finalize(IControlledCharacter character);
    }
}