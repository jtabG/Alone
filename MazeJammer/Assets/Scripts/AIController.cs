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
        m_AIs = new List<IAIBehaviour>();
	}

    // maybe i dont need this...
	//void Update ()
    //{
    //    IEnumerator<IAIBehaviour> iter = m_AIs.GetEnumerator();
    //
    //    while (iter.MoveNext())
    //    {
    //        iter.Current.Update();
    //    }
	//}

    public void SpawnCreature(AIType aType, int aNum)
    {
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

            if (aIBehaviour == null)
            {
                Debug.Log("creature not spawned with IAIBehaviour interface");
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
