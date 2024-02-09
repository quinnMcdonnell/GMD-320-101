using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    public float horizontal;
    public float speed = 8f;
    public float jumpingpower = 100f;

    //Random Stuff
    public float auto = 0f;

    public bool isFacingRight = true;
    private Vector2 saved;

    void Awake()
    {
        //RNG();
    }
    
    
    void Update()
    {   
        
        if(isGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        float absolute = -rb.velocity.y;

        var ratio = Mathf.Clamp01(absolute / 3);

        const float minDrag = 0f;
        const float maxDrag = 1f;

        rb.drag = Mathf.Lerp(minDrag, maxDrag, ratio);

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
        if(rb.gravityScale > 0)
        {
            if (context.performed && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower / rb.gravityScale);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower / rb.gravityScale * 0.5f);
            }
        } else if(rb.gravityScale < 0)
            {
            if (context.performed && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower / rb.gravityScale);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingpower / rb.gravityScale * 0.5f);
            }
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

    public void RNG()
    {
        
        speed = Generator();
        jumpingpower = Generator();

        if(Squares(5))
        {
            rb.gravityScale = -1;
            groundCheck.localPosition = new Vector3(0.0f,0.5f,0.0f);
        } else
        {
            rb.gravityScale = 1;
            groundCheck.localPosition = new Vector3(0.0f, -0.5f, 0.0f);
        }
    }

    private float Generator()
    {
        int RNG = Random.Range(2, 20);
        return (float)RNG;
    }

    private bool Squares(int modular) //if six then RNG % 6 == true; out of 20
    {
        bool returnal;
        int RNG = Random.Range(0, 20);

        if (RNG % modular == 0)
        {
            returnal = true;
        }
        else
        {
            returnal = false;
        }

        return returnal;
    }
}
