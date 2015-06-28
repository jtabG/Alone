using UnityEngine;
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
    private float m_DetectionRange = 2.0f;

    private GameObject m_Target;
    private bool m_Activated;

    [SerializeField]
    private float m_RespawnTime;

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

        Vector3 targetPosition = m_Player.transform.position + (distanceToPlayer.normalized * m_DistanceFromPlayer);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * m_MoveSpeed);
	}

    IEnumerator<YieldInstruction> RespawnDelay(float aDuration)
    {
        float time = 0.0f;
        while (time < aDuration)
        {
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        Reset();
    }

    public void AssignPlayerReference(GameObject aPlayer)
    {
        m_Player = aPlayer;
    }

    public void Reset()
    {
        transform.position = m_Player.transform.position + (-m_Player.transform.forward * m_DistanceFromPlayer);
        m_Activated = false;
    }

    public void UpdateState()
    {
        
    }
}
