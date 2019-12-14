using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	public GameObject unitTemplate;

	public GameManager gameManager;

	// probably later change this to List<CharacterController>
	public List<NpcController> units;

	// Use this for initialization
	void Start () {
		units = new List<NpcController> ();

		var unitAvatar = Instantiate (unitTemplate);

		var charState = new CharState();
		charState.SetBoredom(30);
		charState.SetFatigue(20);
		
		NpcController controller = new NpcController ()
		{
			column = 2, 
			row = 2,
			charSheet = new CharSheet(),
			charState = charState,
			questManager = new QuestManager(),
			avatar = unitAvatar
		};
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
