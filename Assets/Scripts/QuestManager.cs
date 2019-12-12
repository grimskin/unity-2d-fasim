using System.Collections.Generic;
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
}
