using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController {

	public int column;

	public int row;

	public GameObject avatar;


	public void Start () {
		// position our guy at the initial location
		avatar.transform.position = new Vector3 (column, row, 0f);
	}
	

	public void Update () {
		
	}
}
