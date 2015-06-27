using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text counterText;
	
	private float seconds, minutes;

	void Start() 
	{
		counterText = GetComponent<Text> () as Text;
	}

	void Update() {

		minutes = (int)(Time.timeSinceLevelLoad / 60f); //Divide the guiTime by sixty to get the minutes.
		seconds = (int)(Time.timeSinceLevelLoad % 60f);//Use the euclidean division for the seconds.
		counterText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
	}
}