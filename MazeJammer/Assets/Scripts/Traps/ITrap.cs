using UnityEngine;
using System.Collections;
using BrainCloud;

public interface ITrap  
{
    void OnTriggerEnter(Collider other);
    void TrapDetected();
    void ResetTraps();

    Vector3 GetWorldPosition();
}
