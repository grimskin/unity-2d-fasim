using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.

public class BoardManager : MonoBehaviour
{
	// Using Serializable allows us to embed a class with sub properties in the inspector.
	[Serializable]
	public class Count
	{
		public int minimum;             //Minimum value for our Count class.
		public int maximum;             //Maximum value for our Count class.


		//Assignment constructor.
		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}


	public int columns = 10;                                         //Number of columns in our game board.
	public int rows = 10;                                            //Number of rows in our game board.
	public GameObject[] floorTiles;                                 //Array of floor prefabs.

	private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.

	//Sets up the outer walls and floor (background) of the game board.
	void BoardSetup ()
	{
		//Instantiate Board and set boardHolder to its transform.
		boardHolder = new GameObject ("Board").transform;

		for (int x = 0; x < columns; x++) {
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for (int y = 0; y < rows; y++) {
				GameObject toInstantiate = Resources.Load<GameObject> ("Prefabs/TerrainTile");

				GameObject goInstance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

				Sprite[] sprites = Resources.LoadAll<Sprite> ("Sprites/Terrain/terrain_1");

				goInstance.GetComponent<SpriteRenderer> ().sprite = sprites [47];

				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
				goInstance.transform.SetParent (boardHolder);
			}
		}
	}
		
	//SetupScene initializes our level and calls the previous functions to lay out the game board
	public void SetupScene ()
	{
		//Creates the outer walls and floor.
		BoardSetup ();
	}
}
