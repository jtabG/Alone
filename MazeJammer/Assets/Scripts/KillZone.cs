using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour
{

    void OnTriggerEnter(Collider aCollider)
    {
        if (aCollider.gameObject.CompareTag(StringConsts.PLAYER_TAG))
        {
            Debug.Log("KILL ZONE");
            // call game respawn
        }
    }
}
