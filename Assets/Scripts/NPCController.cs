using Character;
using Character.Commands;
using Quests;
using UnityEngine;

public class NpcController : UnitController, IHasCharSheet, IControlledCharacter {
	public CharState charState;
	public CharSheet charSheet;
	public QuestManager questManager;
	private CharStateManager _charStateManager;
	private DecisionMaker _decisionMaker;

	private IQuest _currentQuest;
	private ICommand _currentCommand;
	
	public CharSheet GetCharSheet()
	{
		return charSheet;
	}

	public new void Start()
	{
		base.Start ();

		_charStateManager = new CharStateManager(charState);
		_decisionMaker = new DecisionMaker(charSheet, _charStateManager, questManager);
	}

	public string GetState()
	{
		return state;
	}

	public void SetState(string newState)
	{
		state = newState;
	}

	public Vector2 GetPosition()
	{
		return avatar.transform.position;
	}

	public void Update () {
		if (_currentQuest == null)
		{
			PickAQuest();
		}

		if (_currentCommand == null)
		{
			_currentCommand = _currentQuest.GetCommand(this);
		}
		
		_currentCommand.invokeOn(this);

		if (_currentCommand.IsCompleted())
		{
			_currentCommand = null;

			if (_currentQuest.IsCompleted())
			{
				_currentQuest.Finalize(this);
				GameLogger.Log(name + " finished quest for " + _currentQuest.GetType().Name);
				_currentQuest = null;
			}
		}
		
        OnMouseDown();
	}

	private void PickAQuest()
	{
		_currentQuest = _decisionMaker.PickAQuest(_decisionMaker.GetBiggestNeed());
		GameLogger.Log(name + " picked a quest for " + _currentQuest.GetType().Name
		               + " with need of " + _currentQuest.GetBenefitForNeedAbs(_decisionMaker.GetBiggestNeed()));
	}

    public CharStateManager GetCharStateManager()
    {
	    return _charStateManager;
    }
}