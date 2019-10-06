using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  
    [SerializeField] private bool m_AirControl = false;                         
    [SerializeField] private LayerMask m_WhatIsGround;                         
    [SerializeField] private Transform m_GroundCheck;                        
    [SerializeField] private Transform m_CeilingCheck;
    private bool wallJumpAllowed;


    const float k_GroundedRadius = .2f;
    private bool m_Grounded;           
    const float k_CeilingRadius = .2f; 
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  
    private Vector3 m_Velocity = Vector3.zero;

    float fGroundedRemember = 0; //grounded Timer etc
    [SerializeField]
    float fGroundedRememberTime = 0.25f;

    private float inairX;

    [SerializeField]
    [Range(0, 1)]
    float fCutJumpHeight = 0.5f;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();


    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }



    }



    void Update()

    {


        fGroundedRemember -= Time.deltaTime;
        if (m_Grounded)
        {
            fGroundedRemember = fGroundedRememberTime;
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (m_Rigidbody2D.velocity.y > 0)
            {
             
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y * fCutJumpHeight);
            }
        }

        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y);
    }



    public void Move(float move, bool jump)
    {


      
        if (m_Grounded || m_AirControl)
        {


        
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
         
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        
            if (move > 0 && !m_FacingRight)
            {
                //flip the player.
                Flip();
            }
        
            else if (move < 0 && m_FacingRight)
            {
                //flip the player.
                Flip();
            }
        }

        if ((fGroundedRemember > 0) && jump) 
        {
           
            m_Grounded = false;
            fGroundedRemember = 0;

            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);
        }
        bool AccesingWScript = WScript.instance.WallJumpAllowed;

        if (((wallJumpAllowed == true) && (AccesingWScript == true))&& (Input.GetKeyDown("w")))
        {
            m_Grounded = false;
            fGroundedRemember = 0;

            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
        {
            wallJumpAllowed = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
        {
            wallJumpAllowed = false;
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
