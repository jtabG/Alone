using UnityEngine;
using System.Collections;

public class PitfallTrapBehaviour : MonoBehaviour , ITrap
{
    [SerializeField]
    private TrapState m_State = TrapState.IDLE;

    private GameObject m_Parent;

	void Start () 
    {
        m_Parent = transform.parent.gameObject;    
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
                // Make Block Fall / Disappear
                //Debug.Log("PITFALLLLLL");
                m_Parent.GetComponent<MeshRenderer>().enabled = false;
                m_Parent.GetComponent<BoxCollider>().enabled = false;
                m_State = TrapState.DISABLED;
                Debug.Log(m_State);
                break;
            case TrapState.DISABLED:
                // Pitfall forever
                break;
            case TrapState.IDLE:
                break;
            case TrapState.RESETTING:
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
        Debug.Log("Pitfall Trap Detected");
    }

    public void ResetTraps()
    {
        m_State = TrapState.RESETTING;
    }
}
