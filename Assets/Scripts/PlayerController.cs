using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    Vector2 moveInput;
    [SerializeField]
    private bool _ismoving = false;
    public bool IsMoving { get
        {
            return _ismoving;


        }
        private set
        {
            _ismoving = value;
            animator.SetBool("isMoving", value);
        }
    }
    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning
    {    
          

           get
          {

            return _isRunning;
        
          } 
          set
        {
            _isRunning = value;
            animator.SetBool("isRunning", value );
        }
     }
    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
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





}


