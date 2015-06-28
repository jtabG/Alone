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
            Debug.LogWarning("
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void updateAnimations()
    {

    }

    public void OnTriggerEnter()
    {
     	
    }
}
