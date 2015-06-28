using UnityEngine;
using System.Collections;

public class LevelGoal : MonoBehaviour
{
    private GameStats m_GameStats;


	// Use this for initialization
	void Start ()
    {
	    if (m_GameStats == null)
        {
            m_GameStats = GameObject.Find(ConstValues.GAMESTATS_TAG).GetComponent<GameStats>();
        }
	}


}
