using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;  // Corrected variable name
    public float groundDistance = 0.05f;
    CapsuleCollider2D touchingCol;
    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    private bool isGrounded;
    [SerializeField]
    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }
        private set
        {
            isGrounded = value;
            
            // Corrected variable name
        }
    }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the object.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;  // Corrected variable name
    }
}