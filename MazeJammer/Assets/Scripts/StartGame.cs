using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Button startGame;

	void Start () 
	{
		startGame = startGame.GetComponent<Button> ();
	}
	
	public void newGamePress()
	{
		Application.LoadLevel (1);
	}
}
