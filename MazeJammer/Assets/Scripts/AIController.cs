using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_FloaterPrefab;

    [SerializeField]
    private GameObject m_RunnerPrefab;

    private List<GameObject> m_AIs;
    private GameController m_GameController;


	void Start ()
    {
        m_AIs = new List<GameObject>();
	}
	
	void Update ()
    {
	    
	}

    public void SpawnCreature(AIType aType, int aNum)
    {
        for (int i = 0 ; i < aNum ; ++i)
        {
            GameObject gO;

            switch (aType)
            {
                case AIType.FLOATY_FRED:
                    gO = Instantiate(m_FloaterPrefab);
                    break;

                case AIType.SUICIDE_SAM:
                    gO = Instantiate(m_RunnerPrefab);
                    break;

                default:
                    Debug.Log("BAD AITYPE, assigning RUNNER_TYPE");
                    gO = Instantiate(m_RunnerPrefab);
                    break;
            }

            m_AIs.Add(gO);

            IAIBehaviour aIBehaviour = gO.GetComponent(typeof(IAIBehaviour)) as IAIBehaviour;

            aIBehaviour.AssignPlayerReference(m_GameController.GetPlayerReference());
        }
    }



    public GameController GameController
    {
        set { m_GameController = value; }
    }
}
