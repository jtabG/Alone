﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIRunnerBehaviour : MonoBehaviour, IAIBehaviour
{
    private GameObject m_Player;

    [SerializeField]
    private float m_MoveSpeed = 2.0f;

    [SerializeField]
    private float m_DistanceFromPlayer = 2.0f;

    [SerializeField]
    private float m_DetectionRange = 5.0f;

    private GameObject m_Target;
    private bool m_Activated;

    [SerializeField]
    private float m_RespawnTime;

    [SerializeField]
    private float m_DistanceBuffer;

    private AIState m_State;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_Player == null) { return; }

        if (m_Activated) { return; }

        Vector3 distanceToPlayer = m_Player.transform.position - transform.position;

        if (distanceToPlayer.sqrMagnitude < m_DistanceFromPlayer * m_DistanceFromPlayer)
        {
            return;
        }

        Vector3 direction = distanceToPlayer.normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, m_MoveSpeed * 0.5f);

        Vector3 targetPosition = m_Player.transform.position + (direction * m_DistanceFromPlayer);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * m_MoveSpeed);
	}

    IEnumerator<YieldInstruction> RespawnDelay(float aDuration)
    {
        m_State = AIState.RESETTING;
        float time = 0.0f;
        while (time < aDuration)
        {
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        Reset();
    }

    IEnumerator<YieldInstruction> MoveToTarget(GameObject aTarget)
    {
        float distanceSqrd = (aTarget.transform.position - transform.position).sqrMagnitude;

        while (m_Activated && distanceSqrd < m_DistanceBuffer)
        {
            yield return new WaitForFixedUpdate();
            Vector3 direction = (aTarget.transform.position - transform.position);
            distanceSqrd = direction.sqrMagnitude;

            moveTowardsDirection(direction);
        }
    }

    private void moveTowardsDirection(Vector3 aTargetDireciton)
    {
        Vector3 direction = aTargetDireciton.normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, m_MoveSpeed * 0.5f);

        Vector3 targetPosition = transform.position + (direction * m_MoveSpeed * Time.fixedDeltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * m_MoveSpeed);
    }

    private GameObject FindTarget()
    {
        GameObject foundObject = null;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_DetectionRange);
        int i = 0;

        float distanceToClosestTrap = float.MaxValue;

        while (i < hitColliders.Length)
        {
            ITrap foundTrap = hitColliders[i].GetComponent(typeof(ITrap)) as ITrap;
            if (foundTrap != null)
            {
                //float distanceToTrap = (foundTrap - transform.position).sqrMagnitude;
            }
            i++;
        }



        return foundObject;
    }

    public void AssignPlayerReference(GameObject aPlayer)
    {
        m_Player = aPlayer;
    }

    public void Kill()
    {
        StartCoroutine(RespawnDelay(m_RespawnTime));
    }

    public void SendToTarget()
    {
        m_State = AIState.TRIGGERED;
        m_Target = FindTarget();

        if (m_Target == null)
        {
            m_State = AIState.IDLE;
            return;
        }

        StartCoroutine(MoveToTarget(m_Target));
    }

    #region IAIBEHAVIOUR
    public void Reset()
    {
        transform.position = m_Player.transform.position + (-m_Player.transform.forward * m_DistanceFromPlayer);
        m_Activated = false;
        m_State = AIState.IDLE;
    }

    public void UpdateState()
    {
        
    }

    public AIType GetAIType()
    {
        return AIType.SUICIDE_SAM;
    }

    public AIState GetState()
    {
        return m_State;
    }
    #endregion

}
