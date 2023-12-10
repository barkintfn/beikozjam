using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;  
    public LayerMask groundLayer;   
    public Transform groundCheck;   

    private Rigidbody2D rb;
   [SerializeField] private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Dairenin i�indeki t�m objeleri al
        Collider2D[] hedefObjeler = Physics2D.OverlapCircleAll(groundCheck.position, 0.1f, groundLayer);
        bool check = false;
        // Daire i�indeki her bir obje �zerinde i�lem yap
        foreach (Collider2D hedef in hedefObjeler)
        {
            Debug.Log("Daire i�indeki obje: " + hedef.gameObject.name);
            if (hedef.gameObject.tag == "ground")
            {
                check = true;
            }
        }

        if (check)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            JumpAction();
            isGrounded = false;
        }
    }

    void JumpAction()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}