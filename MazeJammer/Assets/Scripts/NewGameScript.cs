using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameScript : MonoBehaviour {

	public Canvas startMenu;
	public Button newGame;
	public Button howToPlay;
	public Button leaderboards;

    [SerializeField]
    private string Level1;
    [SerializeField]
    private string PauseMenu;
    [SerializeField]
    private string HowToPlay;
    [SerializeField]
    private string Leaderboard;

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
		Application.LoadLevel (Level1);
	}

	public void viewControls()
	{
		Application.LoadLevel (HowToPlay);
	}

    public void onLeaderboardButtonClick()
    {
        Application.LoadLevel(Leaderboard);
    }

	// Update is called once per frame
	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.LoadLevel (PauseMenu);
		}
	}
}
