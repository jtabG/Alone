﻿using UnityEngine;
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

    private int m_Minutes;
    private int m_Seconds;

	void Start () 
    {
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameController>();
        m_LevelStats = m_GameManager.getLevel();

        if (m_GameManager == null ||
            m_LevelStats == null ||
            m_DeathCounterText == null ||
            m_LevelText == null ||
            m_TimerText == null)
        {
            Debug.LogWarning("Something is NULL");
        }       
	}

	void Update () 
    {
        m_LevelText.text = "LEVEL " + ((int)m_GameManager.m_CurrentLevel).ToString("00");
        updateTimer();
        updateDeathCounter();
	}

    void updateTimer()
    {
        m_Minutes = (int)(Time.timeSinceLevelLoad / 60.0f);
        m_Seconds = (int)(Time.timeSinceLevelLoad % 60.0f);

        m_TimerText.text = m_Minutes.ToString("00") + ":" + m_Seconds.ToString("00");
    }

    void updateDeathCounter()
    {
        m_DeathCounterText.text = m_LevelStats.CurrentNumberDeaths.ToString("00");
    }
}
