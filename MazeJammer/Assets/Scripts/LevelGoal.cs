using UnityEngine;
using System.Collections;

public class LevelGoal : MonoBehaviour
{
    private GameStats m_GameStats;

    [SerializeField]
    private ParticleSystem m_Particles;


	void Start ()
    {
	    if (m_GameStats == null)
        {
            m_GameStats = GameObject.Find(ConstValues.GAMESTATS_TAG).GetComponent<GameStats>();
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstValues.PLAYER_TAG))
        {
            Debug.Log("Win!");
            if (m_Particles != null)
            {
                m_Particles.Play();
            }

            
        }
    }
}
