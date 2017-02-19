using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterController : UnitController {

	protected float boredom;
	protected float boredomInc;
	protected float boredomDec;

	new public void Start()
	{
		base.Start ();

		boredom = 1.0f;
		boredomInc = 0.3f;
		boredomDec = 0.4f;
	}

	new public void Update () {
		if (state == STATE_MOVING) {
			continueMoving ();
			cheerUp ();
			return;
		}

		doIdle ();
	}

	protected void cheerUp()
	{
		boredom -= boredomDec;

		if (boredom < 0f) {
			boredom = 0f;
		}
	}

	protected void doIdle()
	{
		boredom += boredomInc;

		log ("Bored up to " + boredom.ToString());

		float randomMove = Random.Range (3, 6);

		if (boredom > randomMove) {
			Vector2 moveTarget = new Vector2 ();
			moveTarget.x = avatar.transform.position.x;
			moveTarget.y = avatar.transform.position.y;

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

			if ((moveTarget.x != avatar.transform.position.x) || (moveTarget.y != avatar.transform.position.y)) {
				moveTo (moveTarget);
			}
		}
	}
}