using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    Vector2 moveInput;

    public float CurrentMoveSpeed { get
        {
            if(IsMoving)
            {
                if(IsRunning)
                {
                    return runSpeed;
                }
                else
                {
                   return walkSpeed; 
                }
                
            }
            else
            {
                return 0;
            }

        }
    }

    [SerializeField]
    private bool _IsMoving = false;

    public bool IsMoving { get
        {
            return _IsMoving;
        } 
        private set
        {
            _IsMoving = value;
            animator.SetBool("isMoving", value);
        }
    }

    [SerializeField]
    private bool _IsRunning = false;

    public bool IsRunning { get
        {
            return _IsRunning;
        } 
        private set
        {
            _IsRunning = value;
            animator.SetBool("isRunning", value);
        }
    }

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y ); 
    }

    public void OnMove(InputAction.CallbackContext context ) 
    {
        moveInput = context.ReadValue<Vector2>();
        
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    /*private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0)
        {
            face
        }
        else if(moveInput < 0)
        {
            face
        }
    }*/

    public void OnRun(InputAction.CallbackContext context ) 
    {
        if(context.started)
        {
            IsRunning = true;
        }
        else if(context.canceled)
        {
            IsRunning = false;
        }
    }
}
