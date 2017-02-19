using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	public GameObject unitTemplate;

	public List<UnitController> units;

	// Use this for initialization
	void Start () {
		units = new List<UnitController> ();

		GameObject unitAvatar = Instantiate (unitTemplate) as GameObject;

		UnitController controller = new UnitController () { column = 2, row = 2, avatar = unitAvatar };
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
