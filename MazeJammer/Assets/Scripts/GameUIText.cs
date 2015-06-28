using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUIText : MonoBehaviour 
{
    [SerializeField]
    private Text m_LevelText;
    [SerializeField]
    private Text m_DeathCounterText;
    [SerializeField]
    private Text m_TimerText;

    [SerializeField]
    private GameController m_GameManager;
    [SerializeField]
    private GameStats.levelStats m_LevelStats;

	void Start () 
    {
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameController>();
        m_LevelStats = m_GameManager.getLevel();
	}

	void Update () 
    {

	}

    void updateTimer()
    {

    }
}
