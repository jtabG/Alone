﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    [SerializeField]
    private GameObject m_PlayerSpawnLocation;

    [SerializeField]
    private GameObject m_PlayerPrefab;

    [SerializeField]
    private CameraFollow m_CameraController;

    private GameObject m_ActivePlayer;

    void Start()
    {
        if (m_PlayerPrefab != null)
        {
            m_ActivePlayer = Instantiate(m_PlayerPrefab);
            RespawnPlayer();

            if (m_CameraController != null)
            {
                m_CameraController.SetTarget(m_ActivePlayer);
            }
        }
    }

    public void RespawnPlayer()
    {
        if (m_ActivePlayer == null) { return; }
        if (m_PlayerSpawnLocation == null) { return; }

        m_ActivePlayer.transform.position = m_PlayerSpawnLocation.transform.position;
    }
	
}
