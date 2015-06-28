using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;

public class GameStats : MonoBehaviour 
{
    public void ReadStatistics()
    {
        BrainCloudWrapper.GetBC().PlayerStatisticsService.ReadAllPlayerStats(StatsSuccess_Callback, StatsFailure_Callback, null);
    }

    public void SaveStatisticsToBrainCloud()
    {
        Dictionary<string, object> stats = new Dictionary<string, object>{
            {"timeToCompleteLevel1", m_Level1.BestTimeToCompleteLevel},
            {"totalNumberDeaths", m_TotalDeaths},
            {"numberDeathsLevel1", m_Level1.NumberDeaths}
        };

        BrainCloudWrapper.GetBC().PlayerStatisticsService.IncrementPlayerStats(stats, StatsSuccess_Callback, StatsFailure_Callback, null);
    }

    private void StatsSuccess_Callback(string responseData, object cbObject)
    {
        JsonData jsonData = JsonMapper.ToObject(responseData);
        JsonData entries = jsonData["data"]["statistics"];

        m_Level1.BestTimeToCompleteLevel = float.Parse(entries["timeToCompleteLevel1"].ToString());
        m_Level1.NumberDeaths = int.Parse(entries["numberDeathsLevel1"].ToString());
        m_TotalDeaths = int.Parse(entries["totalNumberDeaths"].ToString());
    }

    private void StatsFailure_Callback(int statusCode, int reasonCode, string statusMessage, object cbObject)
    {
        Debug.Log("Failure to save stats");
    }

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

    private int m_TotalDeaths = 0;
    public int TotalDeaths
    {
        get { return m_TotalDeaths; }
        set { m_TotalDeaths = value; }
    }

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
