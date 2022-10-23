using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sr;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;

    void Update()
    {
        if (horizontal > 0f)
        {
            sr.flipX = true;
        }
        else if (horizontal < 0f)
        {
            sr.flipX = false;
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpingPower, ForceMode2D.Impulse);
        }
        /*
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * fallMultiplier);
        }
        */
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        animator.SetFloat("horizontal", horizontal);
    }
}