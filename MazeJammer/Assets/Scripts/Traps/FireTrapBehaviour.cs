using UnityEngine;
using System.Collections;

public class FireTrapBehaviour : MonoBehaviour , ITrap
{
    private TrapState m_State = TrapState.IDLE;

    [SerializeField]
    private float m_ResetTimer = 3.0f;
    private float m_Timer = 0.0f;

    [SerializeField]
    private GameObject m_FireParticles;

	void Start ()
    {
        m_FireParticles = transform.GetChild(0).gameObject;
        m_FireParticles.SetActive(false);
        m_Timer = m_ResetTimer;
	}
	

	void Update () 
    {
        checkState();
	}

    void checkState()
    {
        switch (m_State)
        {
            case TrapState.ACTIVE:
                m_FireParticles.SetActive(true);
                m_Timer -= Time.deltaTime;
                if (m_Timer <= 0.0f)
                {
                    m_FireParticles.SetActive(false);
                    m_State = TrapState.RESETTING;
                }                
                break;
            case TrapState.DISABLED:
                // Fire trap will never be disabled
                break;
            case TrapState.IDLE:
                // waiting for trigger
                break;
            case TrapState.RESETTING:
                m_Timer = m_ResetTimer;
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
                m_State = TrapState.TRIGGERED;
            }
            else if (gO.CompareTag("Runner"))
            {
                //TODO: Kill Runner
                m_State = TrapState.TRIGGERED;
            }
        }
    }

    public void TrapDetected()
    {
        Debug.Log("Fire Trap Detected");
    }

    public void ResetTraps()
    {
        m_State = TrapState.RESETTING;
    }
}
