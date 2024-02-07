using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    public float horizontal;
    public float speed = 8f;
    public float drag = 0f;
    public float jumpingpower = 10f;
    
    public bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    {   
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            flip();
        }
        else if(isFacingRight && horizontal < 0f)
        {
            flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    { 
        if(context.performed && isGrounded())
        {
            rb.velocity = new Vector2(0, jumpingpower / rb.gravityScale);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(0, jumpingpower / rb.gravityScale * 0.5f);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
          horizontal = context.ReadValue<Vector2>().x;
    }
}
