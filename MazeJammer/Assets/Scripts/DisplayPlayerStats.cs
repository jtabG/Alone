using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPlayerStats : MonoBehaviour 
{
    [SerializeField]
    private GameStats m_GameStats;

    [SerializeField]
    private Text m_StatText;

	void Start () 
    {
        m_StatText = GetComponent<Text>();
        m_GameStats = GameObject.FindGameObjectWithTag("GameStats").GetComponent<GameStats>();
        if (m_GameStats == null)
        {
            Debug.Log("GameStats is NULL!");
        }
        m_GameStats.ReadStatistics();

        
	}

	void Update () 
    {
        showStats();
	}

    private void showStats()
    {
        m_StatText.text = "Total Deaths: " + m_GameStats.TotalDeaths + 
            "\n\nLevel 1 Time: " + m_GameStats.Level1.BestTimeToCompleteLevel.ToString("#.00") +
            "\nLevel 1 Deaths: " + m_GameStats.Level1.NumberDeaths;
    }
}
