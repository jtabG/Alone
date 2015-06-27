using UnityEngine;
using System.Collections;

public class AIFloaterBehaviour : MonoBehaviour, IAIBehaviour
{
    private GameObject m_Player;

    [SerializeField]
    private float m_MoveSpeed = 2.0f;

    [SerializeField]
    private float m_DistanceFromPlayer = 3.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AssignPlayerReference(GameObject aPlayer)
    {
        m_Player = aPlayer;
    }

    public void Reset()
    {
        // do reset
    }

    public void UpdateState()
    {

    }
}
