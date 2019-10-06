using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    public float runfastSpeed = 80f;

    float horizontalMove = 0f;
    bool jump = false;


    float fJumpPressedRemember = 0;
    [SerializeField]
    float fJumpPressedRememberTime = 0.25f;

    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDamping = 0.5f;
    

  





    void Update()
    {
        
        bool AccesingRunningRight = ACollider.instance.runningright;
        bool AccesingSpaceScript = SpaceScript.instance.JumpAllowed;
        bool AccesingShiftScript = ShiftScript.instance.RunFastAllowed;
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



        if (AccesingRunningRight == true)
        {
            if ((AccesingShiftScript == true) && (Input.GetKey("left shift")))
            { 
            horizontalMove = Input.GetAxisRaw("Horizontal") * runfastSpeed;
            horizontalMove += Input.GetAxisRaw("RunRight");
            horizontalMove *= Mathf.Pow(1f - fHorizontalDamping, Time.deltaTime * 10f);
            }
            else
            { 
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            horizontalMove += Input.GetAxisRaw("RunRight");
            horizontalMove *= Mathf.Pow(1f - fHorizontalDamping, Time.deltaTime * 10f);
            }
            
        }
        else
        { 
        horizontalMove = Input.GetAxisRaw("RunRight") * runSpeed;
        horizontalMove += Input.GetAxisRaw("RunRight");
        horizontalMove *= Mathf.Pow(1f - fHorizontalDamping, Time.deltaTime * 10f);
        }

        if (AccesingSpaceScript == true)
        { 
            fJumpPressedRemember -= Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                fJumpPressedRemember = fJumpPressedRememberTime;
            }

            if (fJumpPressedRemember > 0) // if the last jump was only 0.25 before gound, jump anyway
            {
                fJumpPressedRemember = 0;
                jump = true;
                animator.SetBool("IsJumping", true);
            }

        }

       

    }

   

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
        StartCoroutine(Example());
        animator.SetBool("HasLanded", true);
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
