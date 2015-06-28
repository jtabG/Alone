using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameScript : MonoBehaviour {

	public Canvas startMenu;
	public Button newGame;
	public Button howToPlay;
	public Button leaderboards;

	// Use this for initialization
	void Start () 
	{
		startMenu.GetComponent<Canvas> ();
		newGame = newGame.GetComponent<Button> ();
		howToPlay = howToPlay.GetComponent<Button> ();
		leaderboards = leaderboards.GetComponent<Button> ();
	}

	public void newGamePress()
	{
		Application.LoadLevel (2);
	}

	public void viewControls()
	{
		Application.LoadLevel (1);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.LoadLevel (0);
		}
	}
}
