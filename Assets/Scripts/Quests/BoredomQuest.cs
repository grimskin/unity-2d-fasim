using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredomQuest : BaseQuest {

	override public bool isDoable(GameManager gameManager, NpcController character) 
	{
		List<IBenefit> desiredBenefits = new List<IBenefit> ();
		desiredBenefits.Add (new BoredomBenefit ());

		List<IQuest> possibleQuests = gameManager.getQuestManager ().getQuests (desiredBenefits);

		bool result = (possibleQuests.Count > 0) ? true : false;

		return result;
	}
}
