using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 


public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

	public BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.

	//Awake is always called before any Start functions
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad(gameObject);

		//Get a component reference to the attached BoardManager script
		boardScript = GetComponent<BoardManager>();

		InitGame();
	}

	void InitGame()
	{
		boardScript.SetupScene();
	}

	//Update is called every frame.
	void Update()
	{

	}
}
