using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUIText : MonoBehaviour 
{
    [SerializeField]
    private Text m_DisplayText;

    [SerializeField]
    private GameController m_GameManager;
    [SerializeField]
    private GameStats.levelStats m_LevelStats;

	void Start () 
    {
        m_DisplayText = GetComponent<Text>();
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameController>();
        m_LevelStats = m_GameManager.getLevel();
	}

	void Update () 
    {
        int level = (int)m_GameManager.m_CurrentLevel;
        if (m_GameManager == null)
        {
            level = 1;
        }
        m_DisplayText.text = "Level" + level.ToString("00");
	}
}
