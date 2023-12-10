using System.Collections;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 10f;  // Zýplama kuvveti
    public LayerMask groundLayer;   // Zeminin layer'ý
    public Transform groundCheck;   // Zeminin var olup olmadýðýný kontrol etmek için bir nokta

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Zeminde mi kontrolü
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Zýplama kontrolü
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
