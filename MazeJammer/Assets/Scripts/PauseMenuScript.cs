using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	public Canvas pauseMenu;
	public Button resumeGame;
	public Button exit;

	// Use this for initialization
	void Start () 
	{
		pauseMenu.GetComponent<Canvas> ();
		resumeGame = resumeGame.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();

		pauseMenu.enabled = false;
	}

	public void resumePress()
	{
		pauseMenu.enabled = false;
		Time.timeScale = 1;
	}

	public void exitPress()
	{
		Application.LoadLevel (0);
		Time.timeScale = 1;
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("escape")) {
			pauseMenu.enabled = true;
			Time.timeScale = 0;
		} 
	}
}
