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
        if (aCollider.gameObject.CompareTag(ConstValues.PLAYER_TAG))
        {
            Debug.Log("TRAP TRIGGERED");
            //aCollider.isTrigger = true; //this works for the pitfall
        }
    }
}
