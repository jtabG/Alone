using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    [SerializeField]
    private GameObject m_PlayerSpawnLocation;

    [SerializeField]
    private GameObject m_PlayerPrefab;

    private GameObject m_ActivePlayer;

    void Start()
    {
        if (m_PlayerPrefab != null)
        {
            m_ActivePlayer = Instantiate(m_PlayerPrefab);
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        if (m_ActivePlayer == null) { return; }
        if (m_PlayerSpawnLocation == null) { return; }

        m_ActivePlayer.transform.position = m_PlayerSpawnLocation.transform.position;
    }
	
}
