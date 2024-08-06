using System;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    public bool isFacingLeft;
    private float horizontal;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
            collider.isTrigger = false;
        }
        
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            collider.isTrigger = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
        Flip();
        
        animator.SetBool("IsRunning", horizontal != 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingLeft && horizontal > 0f || !isFacingLeft && horizontal < 0f)
        {
            isFacingLeft = !isFacingLeft;
            if (isFacingLeft)
                transform.position += new Vector3(-0.5f, 0f, 0f);
            else
                transform.position += new Vector3(0.5f, 0f, 0f);
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            
        }
    }
}
