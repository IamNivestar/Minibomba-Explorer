using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;

    public float speed;

    private Rigidbody2D rb;

    public LayerMask whatIsGround;

    private Animator anim;

    private Transform GroundCheck;

    private bool facingRight = true;

    private bool doublejump = false;

    private bool ground;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        GroundCheck = gameObject.transform.Find("GroundCheck");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (config.pause)
            return;
        bool jumping = false;
        ground = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);
        if (ground)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector2(0, jumpForce));
                doublejump = true;
                jumping = true;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (doublejump)
                {
                    rb.AddForce(new Vector2(0, -50*rb.velocity.y));
                    rb.AddForce(new Vector2(0, 8*jumpForce/10));
                    doublejump = false;
                    jumping = true;
                }
            }

        }
        anim.SetBool("ground", ground);
        anim.SetBool("jump", jumping);
        float h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("run", Mathf.Abs(h));
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
        jumping = false;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
