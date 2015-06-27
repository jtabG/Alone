using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private GameController m_GameController;

    void Start()
    {
        if (m_GameController == null)
        {
            Debug.Log("GameController not assigned");
            this.enabled = false;
        }
    }

    void OnTriggerEnter(Collider aCollider)
    {
        if (aCollider.gameObject.CompareTag(StringConsts.PLAYER_TAG))
        {
            Debug.Log("KILL ZONE");
            aCollider.isTrigger = false;
            // call game respawn
            m_GameController.RespawnPlayer();
        }
    }
}
