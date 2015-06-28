using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    float m_MovingTurnSpeed = 360;
    [SerializeField]
    float m_StationaryTurnSpeed = 180;

    [SerializeField]
    float m_RespawnTime = 1.0f;

    [SerializeField]
    private Animator m_Animator;
    [SerializeField]
    private Rigidbody m_Rigidbody;

    private Transform m_Cam;
    private Vector3 m_CamForward;  

    private Vector3 m_LocalVelocity = Vector3.zero;

    private float m_ForwardMovement = 0.0f;
    private float m_RightMovement = 0.0f;
    [SerializeField]
    private float m_Speed = 0.1f;
    private float m_TurnAmount = 0.0f;
    private Vector3 m_GroundNormal;

    private bool m_Command = false;
    private bool m_Death = false;
    private bool m_FallDeath = false;

    private GameController m_GameController;

	void Start () 
    {
        if (m_Animator == null)
        {
            m_Animator = GetComponent<Animator>();
        }

        if (m_Rigidbody == null)
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }
        
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}
	
	
	void Update () 
    {
        updateGroundMovement();
        updateAnimations();
	}

    void updateGroundMovement()
    {
        m_ForwardMovement = Input.GetAxis("Vertical");
        m_RightMovement = Input.GetAxis("Horizontal");

        float forwardMotion = m_ForwardMovement * (m_ForwardMovement > 0 ? (m_Speed + m_Speed) : (m_Speed));

        m_Rigidbody.AddForce(transform.forward * forwardMotion, ForceMode.Acceleration);


        // rotation
        transform.Rotate(0, m_RightMovement * m_StationaryTurnSpeed * Time.deltaTime, 0);

        updateAnimations();
    }

    IEnumerator<YieldInstruction> RespawnDelay(float aDuration)
    {
        float time = 0.0f;
        while (time < aDuration)
        {
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        if (m_GameController != null)
        {
            m_GameController.RespawnPlayer();
        }
    }

    void updateAnimations()
    {
        m_Animator.SetFloat(ConstValues.PLAYER_ANIMATION_MOVEMENT, m_ForwardMovement + m_ForwardMovement);
    }

    public void PlayAnimation(PlayerAnimation aAnimation, bool aState = true)
    {
        switch (aAnimation)
        {
            case PlayerAnimation.COMMAND:
                m_Animator.SetBool(ConstValues.PLAYER_ANIMATION_COMMAND, aState);
                break;
            
            case PlayerAnimation.DEATH:
                m_Animator.SetBool(ConstValues.PLAYER_ANIMATION_DEATH, aState);
                break;
            
            case PlayerAnimation.FALL:
                m_Animator.SetBool(ConstValues.PLAYER_ANIMATION_FALL, aState);
                break;
            
            default:
                Debug.Log("Invalid animation enum.");
                break;
        }
    }

    public void OnDeath()
    {
        PlayAnimation(PlayerAnimation.DEATH, true);
        StartCoroutine(RespawnDelay(m_RespawnTime));
    }

    public void ResetAnimationState()
    {
        PlayAnimation(PlayerAnimation.COMMAND, false);
        PlayAnimation(PlayerAnimation.DEATH, false);
        PlayAnimation(PlayerAnimation.FALL, false);
    }

    public GameController GameController
    {
        set { m_GameController = value; }
    }
}
