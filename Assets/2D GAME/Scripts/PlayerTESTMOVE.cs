using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTESTMOVE : MonoBehaviour
{
    public float movementSpeed;
    bool facingRight = true;

    public float jumpForce=20f;
    public int extraJumps = 1;
    int jumpCount = 0;
    public bool isGrounded;
    float mx;
    float JumpCoolDown;

    public LayerMask groundLayers;
    public Transform feets;
    public Rigidbody2D rb;

    //Animasyon
    Animator playerAnimator;

    


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
   
    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CheckGrounded();
       
        //Yön Değişme
        if (rb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }

        else if (rb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
    }


    private void FixedUpdate()
    {  
            rb.velocity = new Vector2(mx * movementSpeed, rb.velocity.y);
            playerAnimator.SetFloat("playerSpeed", Mathf.Abs(rb.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void Jump()
    {
        if(isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
        
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feets.position, 0.5f, groundLayers))
        {
            isGrounded=true;
            jumpCount = 0;
            JumpCoolDown = Time.time + 0.2f;
            playerAnimator.SetBool("isGroundedAnim", isGrounded);
        }
        else if (Time.time < JumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    

}
