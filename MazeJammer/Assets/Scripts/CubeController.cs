using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class CubeController : MonoBehaviour
{
    [SerializeField]
    private TrapType m_TrapType = TrapType.NONE;

    private TrapState m_TrapState = TrapState.IDLE;


	void Start ()
    {
	
	}

    void OnTriggerEnter(Collider aCollider)
    {
        if (aCollider.gameObject.CompareTag(StringConsts.PLAYER_TAG))
        {
            Debug.Log("TRAP TRIGGERED");
            GameObject gO = aCollider.gameObject;
            aCollider.isTrigger = true; //this works for the pitfall
        }
    }
}
