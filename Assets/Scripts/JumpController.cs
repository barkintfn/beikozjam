using System.Collections;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 10f;  // Z�plama kuvveti
    public LayerMask groundLayer;   // Zeminin layer'�
    public Transform groundCheck;   // Zeminin var olup olmad���n� kontrol etmek i�in bir nokta

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Zeminde mi kontrol�
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Z�plama kontrol�
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            JumpAction();
        }
    }

    void JumpAction()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
