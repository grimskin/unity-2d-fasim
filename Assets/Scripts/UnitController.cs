using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController {

	public const string STATE_IDLE = "STATE_IDLE";
	public const string STATE_MOVING = "STATE_MOVING";

	public int column;

	public int row;

	public string state;

	public GameObject avatar;

	public string name;

	private Vector3 movingTo;

	private float movingSpeed;


	public void Start () {
		// position our guy at the initial location
		avatar.transform.position = new Vector3 (column, row, 0f);
		state = STATE_IDLE;
		if (name == null) {
			name = NameGenerator.fullName();
		}

		Debug.Log (name + " came to this world");
	}

	public void Update () {
		if (state == STATE_MOVING) {
			continueMoving ();
			return;
		}
	}

	void continueMoving() {
	}
}
