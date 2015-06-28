using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    [SerializeField]
    private GameObject m_PlayerSpawnLocation;

    [SerializeField]
    private GameObject m_PlayerPrefab;

    [SerializeField]
    private CameraFollow m_CameraController;

    [SerializeField]
    private AIController m_AIController;


    private GameObject m_ActivePlayer;

    public LevelEnum m_CurrentLevel;

    [SerializeField]
    private GameStats m_GameStats;


    void Start()
    {
        m_GameStats = GameObject.FindGameObjectWithTag("GameStats").GetComponent<GameStats>();

        if (m_PlayerPrefab != null)
        {
            m_ActivePlayer = Instantiate(m_PlayerPrefab);
            RespawnPlayer();

            if (m_CameraController != null)
            {
                m_CameraController.SetTarget(m_ActivePlayer);
                PlayerController playerControl = m_ActivePlayer.GetComponent<PlayerController>();
                if (playerControl != null)
                {
                    playerControl.GameController = this;
                }
            }
        }

        if (m_AIController == null)
        {
            m_AIController = GetComponent<AIController>();
        }
        
        if (m_AIController != null)
        {
            m_AIController.GameController = this;

            m_AIController.SpawnCreature(AIType.FLOATY_FRED, ConstValues.FLOATY_FRED_MAX_COUNT);
            m_AIController.SpawnCreature(AIType.SUICIDE_SAM, ConstValues.SUICIDE_SAM_MAX_COUNT);
        }
    }


    public void RespawnPlayer()
    {
        if (m_ActivePlayer == null) { return; }
        if (m_PlayerSpawnLocation == null) { return; }

        m_ActivePlayer.transform.position = m_PlayerSpawnLocation.transform.position;

        //reset animation
        PlayerController playerControl = m_ActivePlayer.GetComponent<PlayerController>();
        if (playerControl != null)
        {
            playerControl.ResetAnimationState();
        }
    }
	
    public GameObject GetPlayerReference()
    {
        return m_ActivePlayer;
    }

    public GameStats.levelStats getLevel()
    {
        switch (m_CurrentLevel)
        {
            case LevelEnum.LEVEL1:
                return m_GameStats.Level1;
            case LevelEnum.LEVEL2:
                return m_GameStats.Level2;
            case LevelEnum.LEVEL3:
                return m_GameStats.Level3;
            default:
                return null;
        }
    }
}
