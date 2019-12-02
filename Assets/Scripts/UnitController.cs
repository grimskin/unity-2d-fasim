using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UnitController {

	public const string STATE_IDLE = "STATE_IDLE";
	public const string STATE_MOVING = "STATE_MOVING";

	public int column;

	public int row;

	public string state;

	// here is where prefab copy is stored
	public GameObject avatar;

	// animator controller
	private Animator animator;

	public string name;

	private Vector3 movingTo;

	private float movingTime;

	private float inverseMoveTime;

	public void Start () {
		// position our guy at the initial location
		avatar.transform.position = new Vector3 (column, row, 0f);
		state = STATE_IDLE;
		if (name == null) {
			name = NameGenerator.fullName();
		}

		animator = avatar.GetComponent<Animator>();

		movingTime = 0.5f;
		inverseMoveTime = 1f / movingTime;

		log ("came to this world");
	}

	public void Update () {
		if (state == STATE_MOVING) {
			continueMoving ();
			return;
		}
	}

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
        }
    }

	public void moveTo(Vector2 target) {
		state = STATE_MOVING;

		movingTo = new Vector3 (target.x, target.y, 0f);

		setMovingAnimation (target, avatar.transform.position);

		GameManager.instance.StartCoroutine (SmoothMovement (movingTo));

		log ("Started movement to " + movingTo.x.ToString() + ", " + movingTo.y.ToString());
	}

	protected void continueMoving() {
		float sqrRemainingDistance = (avatar.transform.position - movingTo).sqrMagnitude;

		if (sqrRemainingDistance <= float.Epsilon) {
			state = STATE_IDLE;
			stopMovingAnimation ();
			avatar.transform.position.Set (movingTo.x, movingTo.y, 0f);

			log (
				"finished movement at " 
				+ avatar.transform.position.x.ToString() 
				+ ", " 
				+ avatar.transform.position.y.ToString()
			);
		}
	}

	//Co-routine for moving units from one space to next, takes a parameter end to specify where to move to.
	protected IEnumerator SmoothMovement (Vector3 end)
	{
		//Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
		//Square magnitude is used instead of magnitude because it's computationally cheaper.
		float sqrRemainingDistance = (avatar.transform.position - end).sqrMagnitude;

		Rigidbody2D rb2D = avatar.GetComponent<Rigidbody2D> ();

		//While that distance is greater than a very small amount (Epsilon, almost zero):
		while(sqrRemainingDistance > float.Epsilon)
		{
			//Find a new position proportionally closer to the end, based on the moveTime
			Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

			//Call MovePosition on attached Rigidbody2D and move it to the calculated position.
			rb2D.MovePosition (newPostion);

			//Recalculate the remaining distance after moving.
			sqrRemainingDistance = (avatar.transform.position - end).sqrMagnitude;

			//Return and loop until sqrRemainingDistance is close enough to zero to end the function
			yield return null;
		}
	}

	protected void setMovingAnimation (Vector2 target, Vector2 source)
	{
		stopMovingAnimation ();

		float dx = target.x - source.x;
		float dy = target.y - source.y;

		if (Math.Abs (dx) >= Math.Abs (dy)) {
			if (dx > 0.0) {
				animator.SetBool ("move_right", true);
			} else {
				animator.SetBool ("move_left", true);
			}
		} else {
			if (dy > 0.0) {
				animator.SetBool ("move_up", true);
			} else {
				animator.SetBool ("move_down", true);
			}
		}
	}

	protected void stopMovingAnimation ()
	{
		animator.SetBool ("move_right", false);
		animator.SetBool ("move_left", false);
		animator.SetBool ("move_up", false);
		animator.SetBool ("move_down", false);
	}

	protected void log (string message)
	{
		GameLogger.Log (name + ' ' + message);
	}
}
