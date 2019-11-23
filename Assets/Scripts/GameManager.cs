using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 


public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	protected BoardManager boardManager;

	protected UnitManager unitManager;

	protected QuestManager questManager;

	public BoardManager getBoardMananger()
	{
		return boardManager;
	}

	public QuestManager getQuestManager()
	{
		return questManager;
	}

	public UnitManager getUnitManager()
	{
		return unitManager;
	}

	//Awake is always called before any Start functions
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad(gameObject);

		// have to us GetComponent because these two are MonoBeh descendants
		boardManager = GetComponent<BoardManager> ();
		unitManager = GetComponent<UnitManager> ();
		unitManager.gameManager = this;
		questManager = new QuestManager ();

		InitGame();
	}

	void InitGame()
	{
		boardManager.SetupScene();
		unitManager.gameManager = this;
	}
}
