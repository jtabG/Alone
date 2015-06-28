using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackToStartMenu : MonoBehaviour 
{

    [SerializeField]
    private string m_PreviousLevel;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.LoadLevel (m_PreviousLevel);
		}
	}
}
