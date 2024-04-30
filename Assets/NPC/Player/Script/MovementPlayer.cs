using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    // REFERENCES
    private CharacterController controller;
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Action();
        //Fight();


        // Action using Trigger 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Jab");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("Strike");
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            anim.SetTrigger("Hook");
        }

    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                // GetKey = apabila menggunakan fungsi tombol tekan dan tahan
                WalkFWD();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                // GetKey = apabila menggunakan fungsi tombol tekan dan tahan
                WalkBWD();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                RunFWD();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                RunBWD();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkL();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkR();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                RunL();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                RunR();
            }

            moveDirection *= moveSpeed;

            if(moveDirection == Vector3.zero && Input.GetKeyDown(KeyCode.Space))
            {
                IdleJump();
            }
            if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
            {
                WalkJumpF();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
            {
                RunJumpF();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
            {
                WalkJumpB();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
            {
                RunJumpB();
            }

        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    
    private void Idle()
    {
        anim.SetBool("WalkF", false);
        anim.SetBool("WalkL", false);
        anim.SetBool("WalkB", false);
        anim.SetBool("WalkR", false);

        anim.SetBool("RunF", false);
        anim.SetBool("RunL", false);
        anim.SetBool("RunB", false);
        anim.SetBool("RunR", false);

        anim.SetBool("Num0", false);
        anim.SetBool("Num1", false);
        anim.SetBool("Num2", false);
        anim.SetBool("Num3", false);
        anim.SetBool("Num4", false);
        anim.SetBool("Num5", false);

        anim.SetBool("Num9", false);
    }
    private void WalkFWD()
    {
        moveSpeed = walkSpeed;
        anim.SetBool("WalkF", true);
        anim.SetBool("RunF", false);
    }
    private void WalkL()
    {
        moveSpeed = walkSpeed;
        anim.SetBool("WalkL", true);
        anim.SetBool("RunL", false);
    }
    private void WalkBWD()
    {
        moveSpeed = walkSpeed;
        anim.SetBool("WalkB", true);
        anim.SetBool("RunB", false);
    }
    private void WalkR()
    {
        moveSpeed = walkSpeed;
        anim.SetBool("WalkR", true);
        anim.SetBool("RunR", false);
    }
    private void RunFWD()
    {
        moveSpeed = runSpeed;
        anim.SetBool("RunF", true);
    }
    private void RunL()
    {
        moveSpeed = runSpeed;
        anim.SetBool("RunL", true);
    }
    private void RunBWD()
    {
        moveSpeed = runSpeed;
        anim.SetBool("RunB", true);
    }
    private void RunR()
    {
        moveSpeed = runSpeed;
        anim.SetBool("RunR", true);
    }

    private void IdleJump()
    {
        anim.SetTrigger("IdleJump");
    }
    private void WalkJumpF()
    {
        anim.SetTrigger("WalkJumpF");
    }
    private void WalkJumpB()
    {
        anim.SetTrigger("WalkJumpB");
    }
    private void RunJumpF()
    {
        anim.SetTrigger("RunJumpF");
    }
    private void RunJumpB()
    {
        anim.SetTrigger("RunJumpB");
    }

    private void Fight()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetBool("CombatIdle", true);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Jab
                anim.SetTrigger("Jab");
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                // Strike
                anim.SetTrigger("Strike");
            }
            else if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                anim.SetTrigger("Hook");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            anim.SetBool("CombatIdle", false);
        }

    }

    // Action Void untuk gerakan tambahan pada player
    private void Action()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            anim.SetBool("Num0", true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            anim.SetBool("Num1", true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            anim.SetBool("Num2", true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            anim.SetBool("Num3", true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            anim.SetBool("Num4", true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            anim.SetBool("Num5", true);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            anim.SetBool("Num9", true);
        }
    }
}
