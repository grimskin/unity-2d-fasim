using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	public GameObject unitTemplate;

	public GameManager gameManager;

	// probably later change this to List<CharacterController>
	public List<NPCController> units;

	// Use this for initialization
	void Start () {
		units = new List<NPCController> ();

		GameObject unitAvatar = Instantiate (unitTemplate) as GameObject;

		NPCController controller = new NPCController () { column = 2, row = 2, avatar = unitAvatar };
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
