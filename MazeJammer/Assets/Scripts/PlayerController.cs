using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    float m_MovingTurnSpeed = 360;
    [SerializeField]
    float m_StationaryTurnSpeed = 180;

    private Animator m_Animator;
    private Rigidbody m_Rigidbody;

    private Transform m_Cam;
    private Vector3 m_CamForward;  

    private Vector3 m_LocalVelocity = Vector3.zero;

    private float m_ForwardMovement = 0.0f;
    private float m_RightMovement = 0.0f;
    private float m_Speed = 0.1f;
    private float m_TurnAmount = 0.0f;
    private Vector3 m_GroundNormal;

    private bool m_Command = false;
    private bool m_Death = false;
    private bool m_FallDeath = false;


	void Start () 
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();

        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
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

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_LocalVelocity = m_ForwardMovement * m_CamForward + m_RightMovement * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_LocalVelocity = m_ForwardMovement * Vector3.forward + m_RightMovement * Vector3.right;
        }

        if (m_LocalVelocity.magnitude > 1.0f)
        {
            m_LocalVelocity.Normalize();
        }
        m_LocalVelocity = transform.InverseTransformDirection(m_LocalVelocity);    
        m_LocalVelocity = Vector3.ProjectOnPlane(m_LocalVelocity, m_GroundNormal);
        m_TurnAmount = Mathf.Atan2(m_LocalVelocity.x, m_LocalVelocity.z);
        checkGroundStatus();
        applyExtraTurnRotation();

        

        updateAnimations();
    }

    void updateAnimations()
    {

    }

    void applyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_LocalVelocity.z);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }

    void checkGroundStatus()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo))
        {
            m_GroundNormal = hitInfo.normal;
            m_Animator.applyRootMotion = true;
        }
    }
}
