﻿using System.Collections.Generic;
using Character;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcController : UnitController, IHasCharSheet {
	private float _boredom;
	private float _boredomInc;
	private float _boredomDec;
	public CharState charState;
	public CharSheet charSheet;
	public QuestManager questManager;
	private DecisionMaker _decisionMaker;
	private const float Epsilon = 0.01f;

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

	public new void Update () {
		if (state == STATE_MOVING) {
			continueMoving ();
			CheerUp ();
			return;
		}

        OnMouseDown();

		DoIdle ();
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
	    GameLogger.Log("Biggest need is " + _decisionMaker.GetBiggestNeed().GetName());
		
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