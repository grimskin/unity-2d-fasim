using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuest 
{
	bool isDoable(GameManager gameManager, NPCController character);
}

public abstract class BaseQuest: IQuest
{

	protected List<IBenefit> benefits;

	public bool repeatable = false;

	public bool isRepeatable() {
		return repeatable;
	}

	public abstract bool isDoable(GameManager gameManager, NPCController character);
}
