using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float m_DistanceOffset = -5.0f;

    [SerializeField]
    private float m_yOffset = 1.0f;

    private GameObject m_Target;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	    if (m_Target != null)
        {
            //float x = m_Target.transform.position.x;
            //float z = m_Target.transform.position.z + m_DistanceOffset;
            //
            //Vector3 targetPostition = new Vector3(x, transform.position.y, z);
            //transform.position = Vector3.Lerp(transform.position, targetPostition, Time.deltaTime + Time.deltaTime + Time.deltaTime);

            Vector3 targetPostition = m_Target.transform.position + (m_Target.transform.forward * m_DistanceOffset);
            targetPostition.y += m_yOffset;

            transform.position = Vector3.Lerp(transform.position, targetPostition, Time.deltaTime + Time.deltaTime + Time.deltaTime);
            transform.LookAt(m_Target.transform.position);
        }
	}

    public void SetTarget (GameObject aTarget)
    {
        m_Target = aTarget;
    }
}
