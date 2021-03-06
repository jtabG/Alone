﻿using UnityEngine;
using System.Collections;

public class PitfallTrapBehaviour : MonoBehaviour , ITrap
{
    [SerializeField]
    private TrapState m_State = TrapState.IDLE;

    private Renderer m_Renderer;
    [SerializeField]
    private Material m_Mat1;
    [SerializeField]
    private Material m_Mat2;
    private float m_DetectedTimer = 0.0f;

    private float m_ResetTimer = 3.0f;

    private GameObject m_Parent;

    private bool m_IsDetected = false;

	void Start () 
    {
        m_Parent = transform.parent.gameObject;
        m_Renderer = m_Parent.GetComponent<Renderer>();
        m_Renderer.material = m_Mat1;
	}
	
	void Update () 
    {
        checkState();
        m_DetectedTimer -= Time.deltaTime;
        //m_Renderer.material.Lerp(m_Mat1, m_Mat2, Time.deltaTime);
        if (m_DetectedTimer <= 0.0f)
        {
            m_IsDetected = false;
            m_DetectedTimer = m_ResetTimer;
            m_Renderer.material = m_Mat1;
        }
	}

    void checkState()
    {
        switch (m_State)
        {
            case TrapState.ACTIVE:
                // Make Block Fall / Disappear
                //Debug.Log("PITFALLLLLL");
                m_Parent.GetComponent<MeshRenderer>().enabled = false;
                m_Parent.GetComponent<BoxCollider>().enabled = false;
                m_State = TrapState.DISABLED;
                break;
            case TrapState.DISABLED:
                // Pitfall forever
                break;
            case TrapState.IDLE:
                break;
            case TrapState.RESETTING:
                m_Parent.GetComponent<MeshRenderer>().enabled = true;
                m_Parent.GetComponent<BoxCollider>().enabled = true;
                m_State = TrapState.IDLE;
                break;
            case TrapState.TRIGGERED:
                m_State = TrapState.ACTIVE;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (m_State == TrapState.IDLE)
        {
            GameObject gO = other.gameObject;
            if (gO.CompareTag(ConstValues.PLAYER_TAG))
            {
                //TODO: Kill Player
                PlayerController playerControl = gO.GetComponent<PlayerController>();
                if (playerControl != null)
                {
                    playerControl.OnDeath();
                }
                m_State = TrapState.TRIGGERED;
            }
            else if (gO.CompareTag(ConstValues.AI_RUNNER_TAG))
            {
                //TODO: Kill Runner
                AIRunnerBehaviour aiBehav = gO.GetComponent<AIRunnerBehaviour>();
                if (aiBehav != null)
                {
                    aiBehav.Kill();
                }
                m_State = TrapState.TRIGGERED;
            }
        }
    }

    public void ResetTraps()
    {
        m_State = TrapState.RESETTING;
    }

    public void TrapDetected()
    {
        m_DetectedTimer = m_ResetTimer;
        if (!m_IsDetected)
        {
            m_IsDetected = true;
            detected();
        }
    }

    void detected()
    {
        m_Renderer.material = m_Mat2;
    }


    public Vector3 GetWorldPosition()
    {
        return transform.position;
    }

    public TrapState GetTrapState()
    {
        return m_State;
    }
}
