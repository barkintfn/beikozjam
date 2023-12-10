using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    Vector2 moveInput;

    private bool isMoving = false;
    bool isright = true;
  
    

    Rigidbody2D rb;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigidanimcontrol();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    void rigidanimcontrol()
    {
        if(rb.velocity.x<0 || rb.velocity.x > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else if(rb.velocity.x == 0)
        {
            animator.SetBool("isMoving", false);
        }

        if(rb.velocity.x<0 && isright)
        {
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y);
            isright = false;
        }
        else if(rb.velocity.x > 0 && !isright)
        {
            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y);
            isright = true;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
    }
}