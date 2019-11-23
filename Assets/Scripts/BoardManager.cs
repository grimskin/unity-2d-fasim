using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.

public class BoardManager : MonoBehaviour
{
	public GameObject[,] tiles;

	protected int columns;                                         //Number of columns in our game board.
	protected int rows;                                            //Number of rows in our game board.

	private Transform boardHolder; //A variable to store a reference to the transform of our Board object.

	void BoardSetup ()
	{
		//Instantiate Board and set boardHolder to its transform.
		boardHolder = new GameObject ("Board").transform;
		tiles = new GameObject[columns, rows];

		for (int x = 0; x < columns; x++) {
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for (int y = 0; y < rows; y++) {
				GameObject toInstantiate = Resources.Load<GameObject> ("Prefabs/TerrainTile");

				GameObject goInstance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

				Sprite[] sprites = Resources.LoadAll<Sprite> ("Sprites/Terrain/terrain_1");

				goInstance.GetComponent<SpriteRenderer> ().sprite = sprites [47];

				tiles [x, y] = goInstance;

				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
				goInstance.transform.SetParent (boardHolder);
			}
		}
	}
		
	public void SetupScene ()
	{
		columns = Config.getBoardWidth ();
		rows = Config.getBoardHeight ();
		//Creates the outer walls and floor.
		BoardSetup ();
	}
}
