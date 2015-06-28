using UnityEngine;
using System.Collections;

public class SpikeTrapBehaviour : MonoBehaviour, ITrap 
{
    [SerializeField]
    private Animator m_SpikeAnimator;

    private TrapState m_State = TrapState.IDLE;

	// Use this for initialization
	void Start () 
    {
        m_SpikeAnimator = GetComponentInChildren<Animator>();
        if (m_SpikeAnimator == null)
        {
            Debug.LogWarning("Spike Animator is NULL!");
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        // this could b more efficient but ... w/e
	    switch(m_State)
        {
            case TrapState.ACTIVE:
            case TrapState.DISABLED:
            case TrapState.IDLE:
            case TrapState.RESETTING:
            case TrapState.TRIGGERED:
            default:
                Debug.LogError("Default trapstate???");
                break;
        }
	}

    void updateAnimations()
    {
        //m_SpikeAnimator
    }

    public void OnTriggerEnter()
    {
     	
    }


    public void TrapDetected()
    {
     	
    }
}
