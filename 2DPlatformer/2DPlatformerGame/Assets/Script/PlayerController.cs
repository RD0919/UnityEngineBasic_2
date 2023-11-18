using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float RunSpeed = 8;
    [SerializeField] private float airWalkSpeed = 5;
    [SerializeField] private float airRunSpeed = 5;
    [SerializeField] private float JumpImpulse = 10;
    Vector2 moveinput;


    public float CurrentMoveSpeed
    {
        get
        {
            if (CanMove)
            {
                if (IsMoving && !touchingdirections.IsOnWall)
                {
                    if (touchingdirections.isGrounded)
                    {
                        if (IsRunning)
                        {
                            return RunSpeed;
                        }
                        else
                        {
                            return walkSpeed;
                        }
                    }
                    else
                    {
                        if (IsRunning)
                        {
                            return airRunSpeed;
                        }
                        else
                        {
                            return airWalkSpeed;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    private bool _isMoving = false;

        public bool IsMoving
        {
            get { return _isMoving; }
            set
            {
                _isMoving = value;
                animator.SetBool("IsMoving", _isMoving);
            }
        }

        private bool _isRunning = false;

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                _isRunning = value;
                animator.SetBool("IsRunning", _isRunning);
            }
        }

    private bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    
    }

    public bool CanMove
    {
        get 
        { 
            return animator.GetBool("CanMove"); 
        }
    }
    Vector2 moveInput;
    Animator animator;
    TouchingDirections touchingdirections;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingdirections = GetComponent<TouchingDirections>();
    }
    
    //Event
    //

    public  void OnMove(InputAction.CallbackContext context)
    {
        
        moveinput = context.ReadValue<Vector2>();
        IsMoving = moveinput != Vector2.zero;
        SetFacingDirection(moveinput);
    }
    // Update is called once per frame
    //void Update()
    //{
        //if (Input.GetKey(KeyCode.A))
        //{
            //moveinput.x = -1;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
            //moveinput.x = 1;
        //}
        //else
        //{
           // moveinput.x = 0;
        //}

    //}

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context) 
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void Onjump(InputAction.CallbackContext context) 
    {
        if (context.started && touchingdirections.isGrounded)
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpImpulse);
        }
    }

    public void Onfire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger("Attack");
        }
    }

        private void FixedUpdate()
    {
        Debug.Log(CurrentMoveSpeed);//0ÀÌ ¾È³ª¿È
        rb.velocity = new Vector2(moveinput.x * CurrentMoveSpeed, rb.velocity.y);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
}
