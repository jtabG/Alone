using UnityEngine;
using System.Collections;

public class AIFloaterBehaviour : MonoBehaviour, IAIBehaviour
{
    private GameObject m_Player;

    [SerializeField]
    private float m_MoveSpeed = 2.0f;

    [SerializeField]
    private float m_DetectionRange = 2.0f;

    [SerializeField]
    private float m_yOffset = 0.5f;

    [SerializeField]
    private float m_DistanceFromPlayer = 3.0f;

    private float m_RotationAmount = 0.0f;
	// Use this for initialization
	void Start ()
    {
	
	}

	// Update is called once per frame
	void Update ()
    {
        UpdatePostionRotation();
	}

    void FixedUpdate()
    {
        CheckForTraps();
    }

    private void UpdatePostionRotation()
    {
        if (m_Player == null) { return; }
        
        Vector3 targetPosition = m_Player.transform.position;
        targetPosition.y += m_yOffset + (Mathf.Sin(Time.time));

        m_RotationAmount += Time.deltaTime + m_MoveSpeed;

        if (m_RotationAmount > 360.0f) { m_RotationAmount = 0.0f; }

        float rotationRad = m_RotationAmount * Mathf.Deg2Rad;

        targetPosition.x += m_DistanceFromPlayer * Mathf.Sin(rotationRad);
        targetPosition.z += m_DistanceFromPlayer * Mathf.Cos(rotationRad);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * m_MoveSpeed);

        transform.Rotate(transform.right, (Mathf.Cos(Time.time)));
    }

    private void CheckForTraps()
    {
        Vector3 checkPoint = transform.position;
        checkPoint.y = 0.5f;
        Collider[] hitColliders = Physics.OverlapSphere(checkPoint, m_DetectionRange);
        int i = 0;
        
        while (i < hitColliders.Length)
        {
            ITrap foundTrap = hitColliders[i].GetComponent(typeof(ITrap)) as ITrap;
            if (foundTrap != null)
            {
                foundTrap.TrapDetected();
            }
                
            i++;
        }
    }


    public void AssignPlayerReference(GameObject aPlayer)
    {
        m_Player = aPlayer;
    }

    #region IAIBEHAVIOUR
    public void Reset()
    {
        transform.position = m_Player.transform.position + (m_Player.transform.right * m_DistanceFromPlayer);
        transform.position += new Vector3(0.0f, m_yOffset, 0.0f);
    }

    public void UpdateState()
    {

    }

    public AIType GetAIType()
    {
        return AIType.FLOATY_FRED;
    }

    public AIState GetState()
    {
        return AIState.ACTIVE;
    }
    #endregion

}
