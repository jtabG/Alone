using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackToStartMenu : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.LoadLevel (1);
		}
	}
}
