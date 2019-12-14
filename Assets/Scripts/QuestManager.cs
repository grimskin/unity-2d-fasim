using System.Collections.Generic;
using System.Linq;
using Character.Properties;
using Quests;

public class QuestManager {

	protected GameManager gameManager;

	private List<IQuest> _baseQuests;
	
	private void _loadBaseQuests()
	{
		if (!ReferenceEquals(_baseQuests, null)) return;
		
		_baseQuests = new List<IQuest>
		{
			new Idling(),
			new Wandering()
		};
	}

	public List<IQuest> GetQuestsForNeed(IProperty need)
	{
		// @todo this should be called somewhere else 
		_loadBaseQuests();
		
		return (
			from quest
				in _baseQuests
				where quest.GetBenefitForNeedAbs(need) != 0
				select quest
		).ToList();
	}
}
