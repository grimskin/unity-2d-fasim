using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	public GameObject unitTemplate;

	// probably later change this to List<CharacterController>
	public List<CharacterController> units;

	// Use this for initialization
	void Start () {
		units = new List<CharacterController> ();

		GameObject unitAvatar = Instantiate (unitTemplate) as GameObject;

		CharacterController controller = new CharacterController () { column = 2, row = 2, avatar = unitAvatar };
		controller.Start ();
		controller.moveTo (new Vector2(4, 5));

		units.Add (controller);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < units.Count; i++) {
			units [i].Update ();
		}
	}
}
