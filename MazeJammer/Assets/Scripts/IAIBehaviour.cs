using UnityEngine;
using System.Collections;

public interface IAIBehaviour 
{
    void AssignPlayerReference(GameObject aPlayer);
    void Reset();

    void UpdateState();

    AIType GetAIType();
    AIState GetState();
}
