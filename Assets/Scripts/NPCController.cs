using System.Collections.Generic;
using Character;
using Character.Commands;
using Quests;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcController : UnitController, IHasCharSheet, IControlledCharacter {
	private float _boredom;
	private float _boredomInc;
	private float _boredomDec;
	public CharState charState;
	public CharSheet charSheet;
	public QuestManager questManager;
	private DecisionMaker _decisionMaker;
	private const float Epsilon = 0.01f;

	private IQuest _currentQuest;
	private ICommand _currentCommand;
	
	public CharSheet GetCharSheet()
	{
		return charSheet;
	}

	public new void Start()
	{
		base.Start ();

		_decisionMaker = new DecisionMaker(charSheet, new CharStateManager(charState), questManager);

		_boredom = 1.0f;
		_boredomInc = 0.03f;
		_boredomDec = 0.4f;
	}

	public string GetState()
	{
		throw new System.NotImplementedException();
	}

	public void SetState(string newState)
	{
		throw new System.NotImplementedException();
	}

	public Vector2 GetPosition()
	{
		throw new System.NotImplementedException();
	}

	public new void Update () {
		if (state == STATE_MOVING) {
			continueMoving ();
			CheerUp ();
			return;
		}

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
				_currentQuest = null;
			}
		}
		
        OnMouseDown();

		DoIdle ();
	}

	private void PickAQuest()
	{
		_currentQuest = _decisionMaker.PickAQuest(_decisionMaker.GetBiggestNeed());
		GameLogger.Log(name + " picked a quest for " + _currentQuest.GetType().Name);
	}

	private void CheerUp()
	{
		_boredom -= _boredomDec;

		if (_boredom < 0f) {
			_boredom = 0f;
		}
	}

    private void DoIdle()
    {
	    _boredom += _boredomInc;

		float randomMove = Random.Range (3, 6);

		if (!(_boredom > randomMove)) return;
		
		log ("Bored up to " + _boredom + " and decided to walk");

		var position = avatar.transform.position;
		var moveTarget = new Vector2
		{
			x = position.x, 
			y = position.y
		};

		float randX = Random.Range (0, 4);
		if (randX < 1) {
			moveTarget.x -= 1f;
		} else if (randX > 2) {
			moveTarget.x += 1f;
		}

		float randY = Random.Range (0, 4);
		if (randY < 1) {
			moveTarget.y -= 1f;
		} else if (randX > 2) {
			moveTarget.y += 1f;
		}

		if ((System.Math.Abs(moveTarget.x - avatar.transform.position.x) > Epsilon)
		    || (System.Math.Abs(moveTarget.y - avatar.transform.position.y) > Epsilon)) {
			moveTo (moveTarget);
		}
	}
}