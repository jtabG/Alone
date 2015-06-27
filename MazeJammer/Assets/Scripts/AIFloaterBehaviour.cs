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
        Vector3 targetPosition = transform.position;
        targetPosition.x += m_DistanceFromPlayer * Mathf.Sin(Time.deltaTime);
        targetPosition.z += m_DistanceFromPlayer * Mathf.Cos(Time.deltaTime);
	}

    public void AssignPlayerReference(GameObject aPlayer)
    {
        m_Player = aPlayer;
    }

    public void Reset()
    {
        transform.position = m_Player.transform.position + (m_Player.transform.right * m_DistanceFromPlayer);
    }

    public void UpdateState()
    {

    }
}
