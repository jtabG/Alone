using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour 
{
    public class levelStats
    {
        private float m_TimeToCompleteLevel = 0.0f;
        public float TimeToCompleteLevel
        {
            get { return m_TimeToCompleteLevel; }
            set { m_TimeToCompleteLevel = value; }
        }

        private int m_NumberDeathsOverall = 0;
        public int NumberDeaths
        {
            get { return m_NumberDeathsOverall; }
            set { m_NumberDeathsOverall = value; }
        }

        private int m_CurrentNumberDeaths = 0;
        public int CurrentNumberDeaths
        {
            get { return m_CurrentNumberDeaths; }
            set { m_CurrentNumberDeaths = value; }
        }

        private float m_BestTimeToCompleteLevel = 0.0f;
        public float BestTimeToCompleteLevel
        {
            get { return m_BestTimeToCompleteLevel; }
            set { m_BestTimeToCompleteLevel = value; }
        }
    }

    // statistics
    private levelStats m_Level1;
    private levelStats m_Level2;
    private levelStats m_Level3;

    public void incrementDeath(levelStats level)
    {
        level.NumberDeaths++;
    }

    public void incrementCurrentDeaths(levelStats level)
    {
        level.CurrentNumberDeaths++;
    }

    public void resetLevelDeaths(levelStats level)
    {
        level.CurrentNumberDeaths = 0;
    }

    // update player personal record for time
    public void updateBestTime(levelStats level)
    {
        if (level.TimeToCompleteLevel <= level.BestTimeToCompleteLevel)
        {
            level.BestTimeToCompleteLevel = level.TimeToCompleteLevel;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        if (m_Level1 == null)
        {
            m_Level1 = new levelStats();
        }
        if (m_Level2 == null)
        {
            m_Level2 = new levelStats();
        }
        if (m_Level3 == null)
        {
            m_Level3 = new levelStats();
        }
    }

    public levelStats Level1
    {
        get { return m_Level1; }
        set { m_Level1 = value; }
    }
    public levelStats Level2
    {
        get { return m_Level2; }
        set { m_Level2 = value; }
    }
    public levelStats Level3
    {
        get { return m_Level3; }
        set { m_Level3 = value; }
    }  
}
