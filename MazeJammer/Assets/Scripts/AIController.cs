using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_FloaterPrefab;

    [SerializeField]
    private GameObject m_RunnerPrefab;

    private List<IAIBehaviour> m_AIs;
    private GameController m_GameController;


	void Start ()
    {
        if (m_AIs == null)
        {
            m_AIs = new List<IAIBehaviour>();
        }

        if (m_FloaterPrefab == null)
        {
            Debug.Log("missing prefab for floaterType");
            this.enabled = false;
        }

        if (m_RunnerPrefab == null)
        {
            Debug.Log("missing prefab for runnerType");
            this.enabled = false;
        }
	}

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            
            if (SendMinion())
            {
                Debug.Log("Minion successfully send");
            }
            else
            {
                Debug.Log("Could not send minion");
            }
        }
	}

    private bool SendMinion()
    {

        return false;
    }

    public void SpawnCreature(AIType aType, int aNum)
    {
        if (m_AIs == null)
        {
            m_AIs = new List<IAIBehaviour>();
        }
        
        for (int i = 0 ; i < aNum ; ++i)
        {
            GameObject gO = null;

            switch (aType)
            {
                case AIType.FLOATY_FRED:
                    gO = Instantiate(m_FloaterPrefab);
                    break;

                case AIType.SUICIDE_SAM:
                    gO = Instantiate(m_RunnerPrefab);
                    break;

                default:
                    Debug.Log("BAD AITYPE, " + aType + ", creature not spawned");
                    return;
            }

            IAIBehaviour aIBehaviour = gO.GetComponent(typeof(IAIBehaviour)) as IAIBehaviour;
            //Object test = aIBehaviour as Object;
            if (aIBehaviour == null)
            {
                Debug.Log("creature not spawned with IAIBehaviour interface");
                return;
            }

            if (m_AIs == null)
            {
                Debug.Log("list null!?");
                return;
            }

            m_AIs.Add(aIBehaviour);
            
            aIBehaviour.AssignPlayerReference(m_GameController.GetPlayerReference());
            aIBehaviour.Reset();
        }
    }



    public GameController GameController
    {
        set { m_GameController = value; }
    }
}
