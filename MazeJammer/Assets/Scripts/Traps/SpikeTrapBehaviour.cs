using UnityEngine;
using System.Collections;

public class SpikeTrapBehaviour : MonoBehaviour, ITrap 
{
    private TrapState m_State = TrapState.IDLE;

    private Vector3 m_StartPos;
    private Vector3 m_EndPos;

    private GameObject m_Spikes;

    private float m_Timer = 0.0f;
    private float m_ResetTimer = 3.0f;
    private Vector3 m_Increment;
    private Vector3 m_Decrement;

	void Start () 
    {
        m_StartPos = transform.position;
        m_EndPos = new Vector3(transform.position.x, 1.0f, transform.position.z);
        m_Spikes = transform.GetChild(0).gameObject;
        m_Timer = m_ResetTimer;
        m_Increment = new Vector3(0.0f, 0.1f, 0.0f);
        m_Decrement = new Vector3(0.0f, -0.1f, 0.0f);
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
                // raise spikes
                updateSpikes(true);
                // timer for raising spikes then lowering spikes
                m_Timer -= Time.deltaTime;
                if (m_Timer <= 0.0f)
                {
                    m_State = TrapState.DISABLED;
                    m_Timer = m_ResetTimer;
                }           
                break;
            case TrapState.DISABLED:
                updateSpikes(false);
                m_Timer -= Time.deltaTime;
                if (m_Timer <= 0.0f)
                {
                    m_State = TrapState.RESETTING;             
                }   
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

    void updateSpikes(bool raise)
    {
        if (raise)
        {
            if (m_Spikes.transform.position.y <= 1.0f)
            {
                m_Spikes.transform.position = m_Spikes.transform.position + m_Increment;
            }
        }
        else
        {
            if (m_Spikes.transform.position.y > 0.0f)
            {
                Debug.Log("Lowering");
                m_Spikes.transform.position = m_Spikes.transform.position + m_Decrement;
            }
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
        Debug.Log("Spike Trap Detected!!");
    }

    public void ResetTraps()
    {
        m_State = TrapState.RESETTING;
    }
}
